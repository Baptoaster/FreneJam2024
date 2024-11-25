using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    PlayerData playerData;

    public PlayerInput pI;
    public PlayerMovement pM;

    public bool isGameFinished { get; set; }
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
        else { pM.rb.velocity = Vector3.zero; pM.rb.Sleep(); }
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
            playerData.playerDeaths++;
        }
        else
        {
            winScreen.SetActive(true);
        }
        gameObject.SetActive(false);
    }

    private void OnApplicationQuit()
    {
        playerData.playerDeaths = 0;
        playerData.playerCoins = 0;
    }
}
