using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 shootDir;
    public float moveSpeed;

    void Update()
    {
        transform.position += shootDir * moveSpeed * Time.deltaTime; //shoot in direction of enemy
        transform.rotation = Quaternion.LookRotation(shootDir);
    }

    public void Setup(Vector3 shootDir, float moveSpeed) //get the values from ProjectileSystem
    {
        this.shootDir = shootDir;
        this.moveSpeed = moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); //projectile is destroyed if it hits the level boundary
    }
}
