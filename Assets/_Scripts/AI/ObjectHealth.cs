using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class ObjectHealth : MonoBehaviour
{
    public int maxHealth;
    public float descendRate;
    public float destroyHeight;
   
    private HealthBar healthBar;
    private int currentHealth;
    private bool isDead;
   

    void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
    }
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        
        Debug.Log(currentHealth);
    }
    public void TakeDamage(int amount)
    {        
        currentHealth = (int)Mathf.Max(0f, currentHealth - amount);
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0f)
            StartDeathSequence();
    }
    private void StartDeathSequence()
    {
        isDead = true;
        gameObject.layer = 0;

        //Disable all scripts attached to this gameObject other than this one
        MonoBehaviour[] attachedScripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in attachedScripts)        
            if (!script.Equals(this)) script.enabled = false;       

        // Diable NavMeshAgent if one Exists
        NavMeshAgent navAgent;
        if (TryGetComponent(out navAgent)) navAgent.enabled = false;
    }
    private void Update() 
    {
        if (isDead)
        {
            transform.Translate(new Vector3(0f, -descendRate, 0f));
            if (transform.position.y < destroyHeight)
            {
                Destroy(gameObject);
            }
        }
    }
}
