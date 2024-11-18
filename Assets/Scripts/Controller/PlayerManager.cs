using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    //Will handle death, win, collectibles

    public PlayerInput pI;
    public PlayerMovement pM;

    public bool isGameFinished;
    public UnityEvent Death;
    public GameObject deathScreen;
    public GameObject winScreen;

    private void Start()
    {
        deathScreen.SetActive(false);
        winScreen.SetActive(false);
        isGameFinished = false;
    }

    private void Update()
    {
        if(!isGameFinished)
        {
            pI.JumpInput();
            pI.HorizontalInput();
        }

    }

    private void FixedUpdate()
    {
        if (!isGameFinished)
        {
            pM.MoveUpdate();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Deadly")
        {
            
            isGameFinished = true;
            StartCoroutine("DeathAnim");
            Death.Invoke();
            
        }
    }

    IEnumerator DeathAnim()
    {
        yield return new WaitForSeconds(0.5f);
        if (pM.isMirrored == false)
        {
            deathScreen.SetActive(true);
        }
        else
        {
            winScreen.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
