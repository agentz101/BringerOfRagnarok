using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public bool isTower;

    public GameObject bullet;
    public Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character").transform;
        timeBtwShots = startTimeBtwShots;
    }
    // Update is called once per frame
    void Update()
    {
        if(!isTower){
            if (Vector3.Distance(transform.position, player.position) > stoppingDistance) {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance) {
                transform.position = this.transform.position;
            }
            else if (Vector3.Distance(transform.position, player.position) < retreatDistance) {
                transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }  
        }

        if (timeBtwShots<= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }  
}
