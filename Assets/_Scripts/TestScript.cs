using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Transform target;
    private ObjectHealth healthBar;
    private void Start()
    {
        healthBar = target.GetComponent<ObjectHealth>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            healthBar.TakeDamage(1);
        }
    }
}
