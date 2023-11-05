using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;

public class Shadow : MonoBehaviour
{
    public int[,] gridMatrix;

    private GameObject piece;
    public GameObject spawnManager;

    public GameObject greatWork;
    public TextMeshProUGUI ProgressText;
    public GameObject ProgressBarAdjuster;
    
    public BoxCollider2D shadowBoxCollider;
    public GameObject message1;
    public GameObject message2;
    public GameObject message3;
    private Bounds bounds;

    int messageIndex = 3;

    private int errors;

    void Start() {
        bounds = GetComponent<BoxCollider2D>().bounds; 
        gridMatrix = new int[Mathf.CeilToInt(bounds.size.x), Mathf.CeilToInt(bounds.size.y)];
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return) && piece != null) {
            piece.GetComponent<TetrisPieces>().moveDirection = Vector3.zero;

            if (GetMatrixFillPercentage() >= 75) {
                messageIndex = 1;
            }
            else if (GetMatrixFillPercentage() >= 30 ) {
                messageIndex = 2;
            }

            HorizontalMovement componentToRemove = piece.GetComponent<HorizontalMovement>();
            if (componentToRemove != null) {
                Destroy(componentToRemove);
            }
            VerticalMovement componentToRemove2 = piece.GetComponent<VerticalMovement>();
            if (componentToRemove2 != null) {
                Destroy(componentToRemove2);
            }

            // Loop through each child
            foreach(Transform child in piece.transform) {
                // Get child position
                Vector3 childPos = child.position;

                // Calculate matrix indexes
                int x = Mathf.FloorToInt((bounds.size.x / 2) + childPos.x);  
                int y = Mathf.FloorToInt((bounds.size.y / 2) - childPos.y);

                try {
                    if (gridMatrix[x, y] == -1) {
                        errors += 1;
                    }
                    // Set matrix value
                    gridMatrix[x, y] = 1;
                } catch (IndexOutOfRangeException e) {
                    errors += 1;
                }
            }
            if(IsMatrixFull()){
                greatWork.SetActive(true);
                if(messageIndex == 1){
                    message1.SetActive(true);
                }
                else if(messageIndex == 2){
                    message2.SetActive(true);
                }
                else if(messageIndex == 3){
                    message3.SetActive(true);
                }
            }
            else{
                spawnManager.GetComponent<SpawnManager>().ready = true;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log("Matrix percentage: " + GetMatrixFillPercentage());
            Debug.Log("Matrix full: " + IsMatrixFull());
        }

        //ErrorText.text = "Errors:\n" + errors;

        ProgressText.text = "Progress:\n\n" + GetMatrixFillPercentage() + "%";
        ProgressBarAdjuster.transform.localScale = new Vector3(GetMatrixFillPercentage() / 100f, 1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        piece = other.gameObject;
    }

    private void OnTriggerStay2D(Collider2D other) {
        piece = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other) {
        piece = null;
    }

    public float GetMatrixFillPercentage() {

    int totalCells = gridMatrix.GetLength(0) * gridMatrix.GetLength(1);
    int filledCells = 0;

    for (int i = 0; i < gridMatrix.GetLength(0); i++) {
        for (int j = 0; j < gridMatrix.GetLength(1); j++) {
        
        if (gridMatrix[i,j] == 1) {
            filledCells++; 
        }
        
        }
    }

    return Mathf.RoundToInt((float)filledCells / totalCells * 100f);

    }

    bool IsMatrixFull() {
        
        foreach(int value in gridMatrix) {
            if(value != 1) {
            return false;
            }
        }
        return true;

    }
}
