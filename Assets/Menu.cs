using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("levelSelect");
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("level1-1.v2");
    }

    public void GoToLevel1Boss(){
        SceneManager.LoadScene("level1-boss.v2");
    }

    public void GoToSettingsMenu(){
        SceneManager.LoadScene("settingsMenu");
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("mainMenu");
    }

    public void QuitGame(){
        Application.Quit(); 
    }
}
