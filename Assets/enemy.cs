using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public int MaxHealth = 2;
    public int currentHealth;
    public bool isBoss;

    [SerializeField] EnemyHealthbar healthbar;

    private void Awake()
    {
        healthbar = GetComponentInChildren<EnemyHealthbar>();
    }

    public bool noVisual = false;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth  = MaxHealth;
        healthbar.UpdateHealthbar(currentHealth, MaxHealth);
    }

    private void Update()
    {
        //this.transform.position = new Vector3(this.transform.position.x, 1f, this.transform.position.z);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.UpdateHealthbar(currentHealth, MaxHealth);

        //play hurt animation?
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //Die Animation
        if (!isBoss)
        {
            animator.SetTrigger("isDead 0");
            animator.SetBool("isDead", true);
        }
        //Disable the enemy.
        Debug.Log("Dead " + this.name);
        this.enabled = false;
        
        if (!noVisual) {
            
            this.GetComponent<ScriptMachine>().enabled = false;
        }
        else
        {
            this.GetComponent<RandomMovement>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;   
        }
        //yield return new WaitForSecondsRealtime(5f);
        if (isBoss)
        {
            SceneManager.LoadScene("Victory");
            Debug.Log("Killed Boss");
        }
        
        //Debug.Log("Enemy died");
    }
    
}
