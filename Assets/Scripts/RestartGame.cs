using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartGame : MonoBehaviour 
{
  public GameObject canvas;

  public void RestartButton()
  {
    // Desactiva el Canvas
    canvas.SetActive(false); 

    // Reinicia todas las escenas 
    SceneManager.LoadScene(0, LoadSceneMode.Single);

  }

}

