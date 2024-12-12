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
    public bool noVisual;
    public bool isRanged;
    [SerializeField] EnemyHealthbar healthbar;

    private void Awake()
    {
        if ((isBoss))
        {
            healthbar = GetComponentInChildren<EnemyHealthbar>();
        }
    }


    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth  = MaxHealth;
        if ((isBoss))
        {
            healthbar.UpdateHealthbar(currentHealth, MaxHealth);
        }
    }

    private void Update()
    {
        //this.transform.position = new Vector3(this.transform.position.x, 1f, this.transform.position.z);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if ((isBoss))
        {
            healthbar.UpdateHealthbar(currentHealth, MaxHealth);
        }
        

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
            if (!noVisual)
            {
                animator.SetTrigger("isDead 0");
                animator.SetBool("isDead", true);
            
            }
            
        }
        if (isRanged)
        {
            this.GetComponent<RangedEnemy>().enabled = false;
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
