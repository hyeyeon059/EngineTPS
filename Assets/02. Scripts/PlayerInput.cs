using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Horizontal";
    public string rotateAxisName = "Vertical";

    public Vector2 moveInput { get; private set; }

    void Start()
    { 
        
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxis(moveAxisName), Input.GetAxis(rotateAxisName));
        if (moveInput.sqrMagnitude > 1)
            moveInput = moveInput.normalized;
    }
}
