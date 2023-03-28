using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Gun gun;
    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
    private Animator reloadAnimator;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        reloadAnimator = GetComponent<Animator>();
        playerInput.OnFirePressed += FireButtonHandle;
    }


    private void FireButtonHandle()
    {
        playerMovement.SetRotation();
        gun.Fire();
    }

    void Update()
    {
        if (playerInput.reload)
        {
            if (gun.Reload()) reloadAnimator.SetTrigger("Reload");
            //reloadAnimation.SetBool();
            gun.Reload();
        }
    }
}
