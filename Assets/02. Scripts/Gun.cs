using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum State
    {
        Ready,
        Empty,
        Reloading
    }
    public State state { get; private set; }

    public Transform firePosition; //�Ѿ˳����� ��ġ�� ����
    public ParticleSystem muzzleFlashEffect;
    public float bulletLineEffectTime = 0.03f;

    private LineRenderer bulletLineRenderer;
    public float damage = 25;

    public float fireDistance = 100f; //�߻簡�� �Ÿ�

    public int magCapacity = 30; //źâ �뷮
    public int magAmmo; //���� źâ�� �ִ� ź���
    public float timeBetFire = 0.12f; //ź�� �߻� ����
    public float reloadTime = 1.8f; //������ �ҿ�ð�
    private float lastFireTime; //���� ���������� �߻��� �ð�

    private void Awake()
    {
        bulletLineRenderer = GetComponent<LineRenderer>();
        bulletLineRenderer.positionCount = 2;
    }

    IEnumerator ShotEffect(Vector3 hitPosition)
    {
        muzzleFlashEffect.Play();
        bulletLineRenderer.SetPosition(0, firePosition.position);
        bulletLineRenderer.SetPosition(1, hitPosition);
        bulletLineRenderer.enabled = true;
        yield return new WaitForSeconds(bulletLineEffectTime);

        bulletLineRenderer.enabled = false;
    }

    public IEnumerator ReloadRoutine()
    {
        state = State.Reloading;
        yield return new WaitForSeconds(reloadTime);
        magAmmo = magCapacity;
        state = State.Ready;
    }

    public bool Fire()
    {
        if(state == State.Ready && Time.time >= timeBetFire)
        {
            lastFireTime = Time.time;
            Shot();
        }
        return false;
    }

    private void Shot()
    {
        RaycastHit hit;
        Vector3 hitPosition = Vector3.zero;

        if(Physics.Raycast(firePosition.position, firePosition.right * -1, out hit, fireDistance))
        {
            var target = hit.collider.GetComponent<Damageable>();

            if (target != null)
            {
                target.OnDamage(damage, hit.point, hit.normal);
            }
            hitPosition = hit.point;
        }
        else
            hitPosition = firePosition.position + firePosition.right * -1 * fireDistance;

        StartCoroutine(ShotEffect(hitPosition));
        magAmmo--;

        if(magAmmo <= 0)
        {
            state = State.Empty;
        }
    }

    public bool Reload()
    {
        if (state == State.Reloading || magAmmo >= magCapacity)
            return false;
        StartCoroutine(ReloadRoutine());
        return true;
    }

    void Start()
    {
        magAmmo = magCapacity;
        state = State.Ready;
        lastFireTime = 0f;
    }

    void Update()
    {
        
    }
}
