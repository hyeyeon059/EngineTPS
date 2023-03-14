using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Horizontal";
    public string rotateAxisName = "Vertical";
    public string fireButtonName = "Fire1";
    public string reloadButtonName = "Reload";

    public Vector2 moveInput { get; private set; }
    public bool fire { get; internal set; }
    public bool reload { get; internal set; }

    void Start()
    { 
        
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxis(moveAxisName), Input.GetAxis(rotateAxisName));
        if (moveInput.sqrMagnitude > 1)
            moveInput = moveInput.normalized;
        fire = Input.GetButtonDown(fireButtonName);
        reload = Input.GetButtonDown(reloadButtonName);
    }
}
