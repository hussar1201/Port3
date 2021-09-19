using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Menu_Arming");
    }

    public void Exit()
    {
        Application.Quit();        
    }
}
