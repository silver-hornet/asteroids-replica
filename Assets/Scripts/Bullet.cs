using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D bulletRB;

    [SerializeField] float bulletSpeed;
    [SerializeField] float destroyBulletDelay;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.AddForce(transform.up * bulletSpeed);
        Destroy(gameObject, destroyBulletDelay);
    }
}