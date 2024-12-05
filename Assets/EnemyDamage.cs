using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    private float variables; 
    public LayerMask player;
    private float lastHit = 0f;
    //public GameObject healthBar = GameObject.Find("SceneVariableslvl1");
  
    // Start is called before the first frame update
    void Start()
    {
        variables =  (float)Variables.ActiveScene.Get("CurrentHealth");
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(this.transform.position, .09f, player);
        //Apply Damage
        //Debug.Log("Sphere Created");

        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            if (enemy.name == "FantasyMan" && lastHit <= Time.time-.33f)
            {
                Variables.ActiveScene.Set("CurrentHealth", variables - 10);
                variables -= 10;
                lastHit = Time.time;
            }
        }
    }
}
