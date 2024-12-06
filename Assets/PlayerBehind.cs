using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehind : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject Player;
    public float xlow;
    public float xhigh;
    public float zlow;
    public float zhigh;
    void Awake()
    {
        Player = GameObject.Find("FantasyMan");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x >= xlow && Player.transform.position.x <= xhigh && Player.transform.position.z >= zlow)
        {
            Debug.Log("see through me");
            this.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
