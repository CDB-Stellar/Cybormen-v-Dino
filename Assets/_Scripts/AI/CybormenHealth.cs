using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class CybormenHealth : MonoBehaviour
{
    public GameObject healthBarPrefab;
    public bool startActive;
    public int maxHealth;
    public Vector3 GUIOffset;
    [Header("Death Settings")]
    public float descendRate;
    public float destroyHeight;
    
   
    private HealthBar healthBar;
    private int currentHealth;
    private bool isDead;
    private void Awake()
    {
        if (startActive)
        {
            healthBar = Instantiate(healthBarPrefab, transform.position + GUIOffset, Quaternion.identity, transform).GetComponentInChildren<HealthBar>();
            Debug.Log(healthBar);
        }
    }
    private void Start()
    {
        if (startActive)
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);
        }
    }   
    public void InitalizeHealthBar()
    {        
        healthBar = healthBar = Instantiate(healthBarPrefab, transform.position + GUIOffset, Quaternion.identity, transform).GetComponentInChildren<HealthBar>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }
    public void TakeDamage(int amount)
    {
        if (!IsActive())
        {
            Debug.LogError("HealthBar Has not been initalized");
            return;
        }

        currentHealth = (int)Mathf.Max(0f, currentHealth - amount);
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0f)
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

        FindObjectOfType<AudioManager>().Play("HUMD");
        gameObject.layer = 0;

        //Disable all scripts attached to this gameObject other than this one
        MonoBehaviour[] attachedScripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in attachedScripts)        
            if (!script.Equals(this)) script.enabled = false;       

        // Diable NavMeshAgent if one Exists
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
