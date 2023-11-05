using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject[] shadows;
    public GameObject[] progress;

    public GameObject OverlayGreatWork;

    public GameObject message1;
    public GameObject message2;
    public GameObject message3;

    public GameObject ScoreManager;    
    
    private int shadowIndex = 1;
    private int progressIndex = 1;


    void Start() {
        // Get an array of all the child GameObjects
    }

    public void OnButtonPress() {
        // Get an array of all the game objects with the tag "TetrisPiece"
        GameObject[] tetrisPieces = GameObject.FindGameObjectsWithTag("TetrisPiece");

        //hide every message
        message1.SetActive(false);
        message2.SetActive(false);
        message3.SetActive(false);

        // Loop through the array and destroy each game object
        foreach (GameObject tetrisPiece in tetrisPieces) {
            Destroy(tetrisPiece);
        }

        for (int i = 0; i < shadows.Length; i++) {
            Debug.Log(shadows[i].name);
        }


        if (shadowIndex > 0) {
            shadows[shadowIndex-1].SetActive(false);
        }

        if (progressIndex > 0) {
            progress[progressIndex-1].SetActive(false);
        }


        if (shadowIndex >= shadows.Length) {
            //Pasar a la escena runner
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        shadows[shadowIndex].SetActive(true);
        shadowIndex += 1;

        if (progressIndex >= progress.Length) {
            progressIndex = 0;
        }
        progress[progressIndex].SetActive(true);
        progressIndex += 1;

        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().ResetSpawnManager();

        Debug.Log("Shadow index is " + shadowIndex);
    }
    
}
