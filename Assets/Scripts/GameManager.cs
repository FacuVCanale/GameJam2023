using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    [SerializeField] private float initialScrollSpeed;
    [SerializeField] private TMP_Text scoreText;


    private bool isGameOver = false;

    public AudioSource musicAudio;

    private float scrollSpeed;
    private float timer;
    private float timer_for_score;
    private float meters;
    private float gameDuration = 5f; // Duración del juego en segundos 
    
    private float seconds_passed = 0f;


    public GameObject John;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            UpdateSpeed();
            UpdateTime();
            UpdateScore();
            // Llamada al método para sumar los segundos
            Debug.Log(seconds_passed);

            // Verifica si el tiempo ha transcurrido y no se ha alcanzado la cantidad de metros necesaria
            if (seconds_passed >= gameDuration && meters < 5000)
            {
                // El juego termina y se pierde
                EndGame();
            }
        }
    }

    private void UpdateTime()
    {

        timer += Time.deltaTime;

        seconds_passed+= Time.deltaTime;
    }

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }

    public void EraseHype(float multi)
    {
        timer = timer * multi;
    }

    private void UpdateSpeed()
    {
        float speedDivider = 8f;
        scrollSpeed = initialScrollSpeed + timer / speedDivider;
        if (scrollSpeed > 10f)
        {
            scrollSpeed = 10f;
        }
    }

    private void UpdateScore()
    {
        float scorePerSeconds = 3 + (scrollSpeed / 2f);

        timer_for_score += Time.deltaTime;
        meters = (int)(timer_for_score * scorePerSeconds);
        scoreText.text = string.Format("Meters: {0:000000}", meters);
    }

    

    

  private void EndGame()
  {

    musicAudio.Stop();

    isGameOver = true;

    // Congela el tiempo 
    Time.timeScale = 0f; 

    

    // Carga la escena de Game Over después de unos segundos
    Invoke("LoadGameOverScene", 0.3f);
  }

  void LoadGameOverScene()
  {
    SceneManager.LoadScene(2); 
  }


  //AGREGAR PARA LA ESCENA DE MUERTE: 
  /* Invoke("ReloadGameScene", 5f);
}

void ReloadGameScene()
{
  // Reinicia la música
  musicAudio.Play(); 
  
  // Recarga la escena del juego
  SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
} */
}
