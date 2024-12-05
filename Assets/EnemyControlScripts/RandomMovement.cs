using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private float latestDirectionChangeTime;
    public float directionChangeTime = 2f;
    public float characterVelocity = 2f;
    private bool waiting = false;
    public float waitTime = 1f;
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
        if (Time.time - waitTime > latestDirectionChangeTime)
            {
                waiting = false;
            }
        if (waiting)
        {
            return;
        }
        if(Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
           
            calculateNewMovementVector();
            waiting = true;

        }
        transform.position = new Vector3(transform.position.x + (movementPerSecond.x * Time.deltaTime), 1, transform.position.z + (movementPerSecond.z * Time.deltaTime));
    }

    void calculateNewMovementVector()
    {
        //StartCoroutine(waitTime());
        movementDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
        
    }
    /*IEnumerator waitTime()
    {
        yield return new WaitForSeconds(1f);
    }*/

}
