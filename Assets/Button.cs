using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject[] shadows;

    public GameObject OverlayGreatWork;
    
    private int shadowIndex = 1;


    void Start() {
        // Get an array of all the child GameObjects
    }

    public void OnButtonPress() {
        // Get an array of all the game objects with the tag "TetrisPiece"
        GameObject[] tetrisPieces = GameObject.FindGameObjectsWithTag("TetrisPiece");

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

        if (shadowIndex >= shadows.Length) {
            //Pasar a la escena runner
            shadowIndex = 0;
        }
        shadows[shadowIndex].SetActive(true);
        shadowIndex += 1;

        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().ResetSpawnManager();
    }
    
}
