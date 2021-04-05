using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class ObjectHealth : MonoBehaviour
{
    public GameObject healthBarPrefab;
    public bool startActive;
    public int maxHealth;
    public Vector3 GUIOffset;
    [Header("Death Settings")]
    public float descendRate;
    public float destroyHeight;
    public int CurrentHealth { get; set; } //change set to public to save village health


    private HealthBar healthBar;    
    private bool isDead;
    private void Awake()
    {
        if (startActive)
        {
            healthBar = Instantiate(healthBarPrefab, transform.position + GUIOffset, Quaternion.identity, transform).GetComponentInChildren<HealthBar>();         
        }
    }
    private void Start()
    {
        if (startActive)
        {
            CurrentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(CurrentHealth);
        }
    }   
    public void InitalizeHealthBar()
    {        
        healthBar = healthBar = Instantiate(healthBarPrefab, transform.position + GUIOffset, Quaternion.identity, transform).GetComponentInChildren<HealthBar>();

        CurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(CurrentHealth);
    }
    public void TakeDamage(int amount)
    {
        if (!IsActive())
        {
            InitalizeHealthBar();
        }

        CurrentHealth = (int)Mathf.Max(0f, CurrentHealth - amount);
        healthBar.SetHealth(CurrentHealth);
        if (CurrentHealth <= 0f)
            StartDeathSequence();
    }
    private void StartDeathSequence()
    {
        if (!IsActive())
        {
            Debug.LogError("HealthBar Has not been initalized");
            return;
        }

        isDead = true;

        FindObjectOfType<AudioManager>().Play("FirstImpact");
        gameObject.layer = 0;

        //Disable all scripts attached to this gameObject other than this one
        MonoBehaviour[] attachedScripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in attachedScripts)        
            if (!script.Equals(this)) script.enabled = false;       

        // Diable NavMeshAgent if one Existsp
        NavMeshAgent navAgent;
        if (TryGetComponent(out navAgent)) navAgent.enabled = false;
    }
    private bool IsActive()
    {
        if (healthBar == null) return false;        
        else return true;
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
