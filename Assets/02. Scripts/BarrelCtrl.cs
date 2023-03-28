using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour, Idamageable
{
    public Texture[] textures;
    private MeshRenderer render;

    public GameObject expEffect;
    private Transform tr;
    private Rigidbody rb;
    private int hitCnt = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        render = GetComponent<MeshRenderer>();
        int idx = Random.Range(0, textures.Length);
        render.material.mainTexture = textures[idx];
    }

    public void OnDamage(float damage, Vector3 hitPosition, Vector3 hitNormal)
    {
        if(++hitCnt == 3)
            ExpBarrel();
        else
            AttackBarrel(damage, hitNormal);
    }

    private void AttackBarrel(float power, Vector3 hitDir)
    {
        rb.AddForce(hitDir * -1 * power, ForceMode.Impulse);
    }

    private void ExpBarrel()
    {
        GameObject exp = Instantiate(expEffect, transform.position, transform.rotation);
        Destroy(exp, 2.0f);

        rb.mass = 1.0f;
        rb.AddForce(Vector3.up * 1500.0f);
        Destroy(gameObject, 2.0f);
    }
}
