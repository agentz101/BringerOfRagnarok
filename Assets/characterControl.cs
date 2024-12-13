using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class controlTemp : MonoBehaviour
{

    private CharacterController characterController;
    public float Speed = 5f;
    public float teleportSpeed = .01f;
    public Animator anim;
    public float Stanima = 100;
    public int stanimaRegainTime = 120;
    public AudioSource audioSource2;
    Vector3 move;
    Vector3 teleport;
    
    //GameObject scene;
    //float health;
    //float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Stanima = (float) Variables.ActiveScene.Get("CurrentStamina");
        //scene = GameObject.Find("level1-1.v2");
    }

    // Update is called once per frame
    //WASD MOVEMENT
    void Update()
    {
        
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * Speed);
        Animate();
        if (move.x > 0.01f)
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        else if (move.x < -0.01f)
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        teleport = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetMouseButtonDown(1) && move != new Vector3(0, 0, 0) && Stanima >= 10)
        {
            characterController.Move(teleportSpeed*teleport);
            Variables.ActiveScene.Set("CurrentStamina", Stanima - 10);
            Stanima -= 10;
            audioSource2.pitch = Random.Range(1f, 1.5f);
            audioSource2.Play();
        }

        if(Time.frameCount % stanimaRegainTime == 0 && Stanima < 100)
        {
            if ((bool)Variables.ActiveScene.Get("MovementActive?"))
            {
                Stanima += 2;
            }
            else
            {
                Stanima += 1;
            }
            Variables.ActiveScene.Set("CurrentStamina", Stanima);
        }
        //Debug.Log("Stanima is: " + Stanima);
        
        //health = scene.GetComponent<CurrentHealth>;
        //this.transform.position = new Vector3(this.transform.position.x, 1.3f, this.transform.position.z);
    }

    void Animate()
    {
        anim.SetFloat("AnimMoveX", move.x);
        anim.SetFloat("AnimMoveZ", move.z);
    }

    public bool canAttack()
    {
        return move.x == 0 && move.z == 0;
    }
}