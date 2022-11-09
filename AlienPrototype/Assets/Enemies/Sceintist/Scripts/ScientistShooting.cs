using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistShooting : MonoBehaviour
{
    [Header ("������ ����������")]
    [SerializeField]
    private GameObject bulletPrefab;

    [Header ("����� ������ �������� ����")]
    [SerializeField]
    private Transform gun;

    [Header("�������� ����� ����")]
    [SerializeField]
    private float shootPower;

    [Header ("������� ��������")]
    [SerializeField]
    private float shootDelay;

    [Header("���� �� ����")]
    [SerializeField]
    private float bulletDamage;

    private bool isShooting = false;

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, gun.position, gun.rotation) as GameObject;

        Vector3 _scale = transform.localScale;
        _scale.x *= -shootPower;

        newBullet.GetComponent<Rigidbody2D>().AddForce(_scale);

        newBullet.GetComponent<Damager>().Damage = bulletDamage;

        Destroy(newBullet, 0.75f);
    }

    private void Shooting()
    {
        InvokeRepeating("Shoot", 0.25f, shootDelay);
    }

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (ScientistWalking.Instance.EnemyState)
        {
            case "Stop":

                if (isShooting == false) 
                    Shooting();

                isShooting = true;

                break;

            case "Walk":

                CancelInvoke("Shoot");

                isShooting = false;

                break;
        }
    }

}
