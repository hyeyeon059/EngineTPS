using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Gun gun;
    private PlayerInput1 playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput1>();
    }


    // Update is called once per frame
    void Update()
    {
        if (playerInput.fire)
        {
            gun.Fire();
        }
        else if (playerInput.reload)
        {
            gun.Reload();
        }
    }
}
