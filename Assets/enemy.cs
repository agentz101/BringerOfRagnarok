using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int MaxHealth = 2;
    int currentHealth;


    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth  = MaxHealth;
    }

    private void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, 1f, this.transform.position.z);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //play hurt animation?
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Die Animation
        animator.SetTrigger("isDead 0");
        animator.SetBool("isDead", true);
        //Disable the enemy.
        this.enabled = false;
        this.GetComponent<ScriptMachine>().enabled = false;
        //Debug.Log("Enemy died");
    }
    
}
