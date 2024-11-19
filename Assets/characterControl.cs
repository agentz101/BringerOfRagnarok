using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class controlTemp : MonoBehaviour
{

    private CharacterController characterController;
    public float Speed = 5f;
    public Animator anim;
    Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
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


        this.transform.position = new Vector3(this.transform.position.x, 1f, this.transform.position.z);
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