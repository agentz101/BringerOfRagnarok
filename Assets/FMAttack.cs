using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

//using Unity.PlasticSCM.Editor.WebApi;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class FMAttack : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    private Animator anim;
    private controlTemp PlayerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private float timeSinceLast = Mathf.Infinity;

    private int attackState = 0;
    private Queue<int> myQueue = new Queue<int>();
    private float inAnimation = 0f;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float lastAttack = 0f;

    public int attackDamage = 1;

    public AudioSource audioSource1;


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
    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
 
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && (PlayerMovement.canAttack() || (bool)Variables.ActiveScene.Get("MovementActive?")) && myQueue.Peek() == 0)
        {
            Attack();
        }
       if (Input.GetMouseButton(0) && timeSinceLast < animation2 && (PlayerMovement.canAttack() || (bool)Variables.ActiveScene.Get("MovementActive?")) && myQueue.Peek() == 1)
            {
                Attack2();
            }
        if (Input.GetMouseButton(0) && timeSinceLast < animation3 && (PlayerMovement.canAttack()  || (bool)Variables.ActiveScene.Get("MovementActive?")) && myQueue.Peek() == 2)
            {
                Attack3(); 
            }
        
       
        else if(cooldownTimer > attackCooldown && myQueue.Peek() != 0)
        {
            anim.SetTrigger("notAttacking");
            anim.ResetTrigger("attack");
            anim.ResetTrigger("attack2");
            anim.ResetTrigger("attack3");
            myQueue.Clear();
            myQueue.Enqueue(0);
        }
        cooldownTimer += Time.deltaTime;
        timeSinceLast += Time.deltaTime;
    }

    private void Attack3()
    {

        anim.SetTrigger("attack3");
        
        anim.ResetTrigger("notAttacking");
       // Damage();
        cooldownTimer = 0f;
        //timeSinceLast = 0f;
        attackState = 0;
        myQueue.Clear();
        myQueue.Enqueue(3);
        cooldownTimer = 0f;
        timeSinceLast = 0f;


    }
    private void Attack2()
    {
        anim.SetTrigger("attack2");
       
        anim.ResetTrigger("notAttacking");
        //Damage();
        attackState = 2;
        myQueue.Clear();
        myQueue.Enqueue(2);
        cooldownTimer = 0f;
        timeSinceLast = 0f;
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        
        anim.ResetTrigger("notAttacking");
        if (Time.time - lastAttack >= .5)
        {
            Damage();
        }
        attackState = 1;
        myQueue.Clear();
        myQueue.Enqueue(1);
        cooldownTimer = 0;
        timeSinceLast = 0f; 
    }
    public void Damage()
    {
        //Detect Enemies in Range
        Vector3 hitSphere = attackPoint.position;
        lastAttack = Time.time;

        audioSource1.pitch = Random.Range(1f, 1.5f);
        audioSource1.Play();
       // hitSphere.x += 0.5f;
       // hitSphere.y += 0.3f;

        Collider[] hitEnemies = Physics.OverlapSphere(hitSphere, attackRange, enemyLayers);
        //Apply Damage
        //Debug.Log("Sphere Created");

        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<enemy>().TakeDamage(attackDamage);
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
