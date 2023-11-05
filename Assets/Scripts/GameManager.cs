using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    [SerializeField] private float initialScrollSpeed; // Velocidad inicial de desplazamiento
    [SerializeField] private TMP_Text scoreText; // Texto que muestra la puntuación

    [SerializeField] private TMP_Text bombTimerText;


    private float timeForRunning = 10f;

    private bool isGameOver = false; // Indica si el juego ha terminado

    public AudioSource musicAudio; // Fuente de audio para la música de fondo

    private float scrollSpeed; // Velocidad de desplazamiento actual
    private float timer; // Tiempo transcurrido
    private float timer_for_score; // Temporizador para el cálculo de la puntuación
    private float meters; // Medidor de distancia recorrida
     // Duración máxima del juego en segundos
    private float seconds_passed = 0f; // Tiempo transcurrido en segundos
    private float toPass;
    [SerializeField] Camera mainCamera; 
    public GameObject John; // Referencia al objeto "John" en el juego

    private void Awake()
    {

        isGameOver = false;

        Time.timeScale = 1f;
        seconds_passed = 0f;
        timer = 0f;
        timer_for_score = 0f;
        timeForRunning = 111f;
        meters = 0f;
        toPass = UpdateMeters();
        // Configura la velocidad inicial
        scrollSpeed = initialScrollSpeed;

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
            UpdateBombTimer();
            
            // Llamada al método para sumar los segundos
            //Debug.Log(seconds_passed);

            // Verifica si el tiempo ha transcurrido y no se ha alcanzado la cantidad de metros necesaria
            if (timeForRunning<=0)
            {
                if (toPass>0)
                {
                    EndGame();
                }
                else {
                    Debug.Log("Win");
                }
                
            }
            else
            {
                if (toPass<=0)
                {
                    WinGame();
                }
            }
        }
    }
    private float UpdateMeters()
    {
        return (float)(ScoreManager.GetScore() * 7);
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

        toPass -= Mathf.CeilToInt(Time.deltaTime * scorePerSeconds);
        scoreText.text = string.Format("Meters: {0:00000}", toPass);
    }

     private void UpdateBombTimer()
    {
        timeForRunning -= Time.deltaTime;
        bombTimerText.text = string.Format("Time Left: {0:00000}", Mathf.Max(0, (int)timeForRunning));
    }

    

    



  private void EndGame()
  {

    isGameOver = true;
    musicAudio.Stop();

    
    // Congela el tiempo 
    Time.timeScale = 0f; 

    
    SceneManager.LoadScene(2); 
    // Carga la escena de Game Over después de unos segundos
    
  }


 private void WinGame()
  {

    isGameOver = true;
    musicAudio.Stop();

    
    // Congela el tiempo 
    Time.timeScale = 0f; 

    
    SceneManager.LoadScene("WinScene"); 
    // Carga la escena de Game Over después de unos segundos
    
  }




 

}
