using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    private CharacterController characterController; 
    private PlayerInput1 playerInput; 
    private Animator animator; 

    private Camera followCam; 

    public float targetSpeed = 6f;
    public float rotationSpeed = 4f;

   public float currentSpeed 
        => new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;

    void Start()
    {
        //������Ʈ ��������
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput1>();
        animator = GetComponent<Animator>();
        followCam = Camera.main;
    }

    private void FixedUpdate() 
    {
        Rotate();
        Move(playerInput.moveInput);
    }


    void Update()
    {
        UpdateAnimation(playerInput.moveInput);
    }

    public void Move(Vector2 moveInput)
    {
        var moveDirection = Vector3.Normalize(transform.forward * moveInput.y + transform.right * moveInput.x);
        var velocity = moveDirection * targetSpeed;
        characterController.Move(velocity * Time.deltaTime);

    }

    public void Rotate()
    {
        //var targetRotation = followCam.transform.eulerAngles.y;
        //transform.eulerAngles = Vector3.up * targetRotation;

        Vector3 target = playerInput.mousePos;
        target.y = 0;
        Vector3 v = target - transform.position;

        float degree = Mathf.Atan2(v.x, v.z) * Mathf.Rad2Deg;
        float rot = Mathf.LerpAngle(transform.eulerAngles.y, degree, Time.deltaTime * rotationSpeed);
        transform.eulerAngles = new Vector3(0, rot, 0);
    }

     private void UpdateAnimation(Vector2 moveInput)
    {
        animator.SetFloat("Vertical Move", moveInput.y);
        animator.SetFloat("Horizontal Move", moveInput.x);
    }

}
