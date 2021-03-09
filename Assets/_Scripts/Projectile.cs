using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 shootDir;
    public float moveSpeed;
    public Transform target;

    void Update()
    {
        Debug.Log(target);
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
       
        Vector3 lookDir = (target.position - transform.position);
        transform.rotation = Quaternion.LookRotation(lookDir);
        transform.position += lookDir * moveSpeed * Time.deltaTime; //shoot in direction of enemy (tracking)
    }

    public void Setup(Vector3 shootDir, float moveSpeed, Transform target) //get the values from ProjectileSystem
    {
        this.shootDir = shootDir;
        this.moveSpeed = moveSpeed;
        this.target = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == 14)
        {
            Destroy(gameObject); //projectile is destroyed if it hits any other collider
        }
        
    }
}
