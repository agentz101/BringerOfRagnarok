using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void Animate()
    {
        anim.SetFloat("AnimMoveX", move.x);
        anim.SetFloat("AnimMoveZ", move.z);
    }
}