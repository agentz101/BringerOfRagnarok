using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class FMAttack : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    private Animator anim;
    private controlTemp PlayerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private int attackState = 0;
    private Queue<int> myQueue = new Queue<int>();




    //private bool attack1 = false;
    //private bool attack2 = false;
    [SerializeField] private float animation2;
    [SerializeField] private float animation3;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        PlayerMovement = GetComponent<controlTemp>();
        myQueue.Clear();
        myQueue.Enqueue(0);

      

    }

    private void Update()
    {
 
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && PlayerMovement.canAttack() && myQueue.Peek() == 0)
        {
            Attack();
        }
       else 
            if (Input.GetMouseButton(0) && cooldownTimer > animation2 && PlayerMovement.canAttack() && myQueue.Peek() == 1)
            {
                Attack2();
            }
        else 
            if (Input.GetMouseButton(0) && cooldownTimer > animation3 && PlayerMovement.canAttack() && myQueue.Peek() == 2)
            {
                Attack3();
                anim.SetTrigger("notAttacking");
                anim.ResetTrigger("attack");
                anim.ResetTrigger("attack2");
                anim.ResetTrigger("attack3");
            }
        
       
        else if(cooldownTimer > attackCooldown && myQueue.Peek() != 0)
        {
            anim.SetTrigger("notAttacking");
            anim.ResetTrigger("attack");
            anim.ResetTrigger("attack2");
            anim.ResetTrigger("attack3");
            //myQueue.Enqueue(0);
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack3()
    {
        anim.SetTrigger("attack3");
        anim.ResetTrigger("notAttacking");
        attackState = 0;

        myQueue.Clear();
        myQueue.Enqueue(0);

    }
    private void Attack2()
    {
        anim.SetTrigger("attack2");
        anim.ResetTrigger("notAttacking");
        attackState = 2;
        myQueue.Enqueue(2);
        myQueue.Dequeue();
        cooldownTimer = 0f;
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        anim.ResetTrigger("notAttacking");
        attackState = 1;
        myQueue.Enqueue(1);
        myQueue.Dequeue();
        cooldownTimer = 0;
    }

}
