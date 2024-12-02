using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private float latestDirectionChangeTime;
    public float directionChangeTime = 2f;
    public float characterVelocity = 2f;
    private Vector3 movementDirection;
    private Vector3 movementPerSecond;
    void Start()
    {
        latestDirectionChangeTime = 0f;
        calculateNewMovementVector();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calculateNewMovementVector();
        }
        transform.position = new Vector3(transform.position.x + (movementPerSecond.x * Time.deltaTime), 1, transform.position.z + (movementPerSecond.z * Time.deltaTime));
    }

    void calculateNewMovementVector()
    {
        movementDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }
}
