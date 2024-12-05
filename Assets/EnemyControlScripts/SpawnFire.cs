using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    public GameObject Spirit;
    public GameObject Fire;
    public float directionTime = 1.5f;
    private float lastTime = 0f;
    private bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!started)
        {
            Fire.transform.position = Spirit.transform.position;
            started = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastTime > directionTime)
        {
            Fire.transform.position = Spirit.transform.position;
            //Debug.Log("Inside if");
            lastTime = Time.time;
        }

    }
}
