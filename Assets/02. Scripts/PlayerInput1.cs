using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput1 : MonoBehaviour
{
    public string moveAxisName = "Horizontal";
    public string rotateAxisName = "Vertical";
    public string fireButtonName = "Fire1";
    public string reloadButtonName = "Reload";

    public Vector2 moveInput { get; private set; }
    public bool fire { get; internal set; }
    public bool reload { get; internal set; }
    public LayerMask whatIsGround;
    public Vector3 mousePos { get; private set; }


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

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float depth = Camera.main.farClipPlane;

        if (Physics.Raycast(cameraRay, out hit, depth, whatIsGround))
        {
            mousePos = hit.point;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(mousePos, 0.5f);
    }
}
