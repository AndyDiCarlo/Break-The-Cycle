using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Begin(){
        SceneManager.LoadScene("TheCycle", LoadSceneMode.Single);
    }

    public void retry(){
        SceneManager.LoadScene("TheCycle", LoadSceneMode.Single);
    }

    public void Menu(){
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
