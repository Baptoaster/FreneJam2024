using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    float horizontal;
    float vertical;
    public UnityEvent Jump;

    public float HorizontalInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        return horizontal;
    }

    public void JumpInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump.Invoke();
        }
    }
}
