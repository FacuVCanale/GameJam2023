using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{   
    
    
    public void PlayGame()
    {
        // Cambiar de escena
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
