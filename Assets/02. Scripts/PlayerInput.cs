using System.Collections;
using System.Collections.Generic;
using System;
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

    private Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    public Action OnFirePressed = null;

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

        if(fire)
        {
            OnFirePressed?.Invoke();
        }
    }

    public bool GetMouseWorldPosition(out Vector3 point)
    {
        Ray cameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float depth = mainCam.farClipPlane;

        point = Vector3.zero; 

        if (Physics.Raycast(cameraRay, out hit, depth))
        {
            point = hit.point;
            return true;
        }
        else
            return false;
    }
}
