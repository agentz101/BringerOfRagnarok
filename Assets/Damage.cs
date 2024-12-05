using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public Variables variables;
    public LayerMask player;
    public GameObject healthBar = GameObject.Find("SceneVariableslvl1");
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(this.transform.position, 1.3f, player);
        //Apply Damage
        //Debug.Log("Sphere Created");

        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            if (enemy.name == "FantasyMan")
            {
                healthBar.
            }
        }
    }
}
