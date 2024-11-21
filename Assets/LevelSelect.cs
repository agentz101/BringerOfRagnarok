using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] public string level1;
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(level1);
    }
}
