using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerProjectile : MonoBehaviour
{
    public float speed;
    public float timeToLive;
    private Transform player;
    private Vector3 target;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        timeToLive -= Time.deltaTime;
        if(transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z){
            DestroyProjectile();
        }
        if (timeToLive <= 0)
        {
            DestroyProjectile();
        }
    }


    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Character")){
            DestroyProjectile();
        }
    }
    void DestroyProjectile(){
        Destroy(gameObject);
    }

}
