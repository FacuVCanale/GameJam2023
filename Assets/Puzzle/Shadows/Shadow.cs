using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;
using System.Text;

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

    public GameObject ScoreManager;
    private Bounds bounds;

    private int errorsOutsideBoundingBox = 0;
    private int errorsInBoundingBox = 0;
    int messageIndex = 3;

    private int totalCells;

    void OnEnable() {
        bounds = GetComponent<BoxCollider2D>().bounds;
        Debug.Log("Grid Matrix size is " + bounds.size.x + " x " + bounds.size.y);
        ContainerShadowArray  ContainerArray = this.GetComponent<ContainerShadowArray>();
        if (ContainerArray != null) {
            gridMatrix = ContainerArray.GetGridMatrix();
        }
        else {
            ChipShadowArray ChipArray = this.GetComponent<ChipShadowArray>();
            if (ChipArray != null) {
                gridMatrix = ChipArray.GetGridMatrix();
            }
            else {
                OxygenShadowArray OxygenArray = this.GetComponent<OxygenShadowArray>();
                if (OxygenArray != null) {
                    gridMatrix = OxygenArray.GetGridMatrix();
                }
                else {
                    TimerShadowArray TimerArray = this.GetComponent<TimerShadowArray>();
                    if (TimerArray != null) {
                        gridMatrix = TimerArray.GetGridMatrix();
                    }
                    else {
                        Debug.Log("No shadow array found");
                    }
                }
            }
            
        }

        Debug.Log("Complete Grid Matrix: " + gridMatrix[0,0]);
        
        totalCells = gridMatrix.GetLength(0) * gridMatrix.GetLength(1);
        for (int i = 0; i < gridMatrix.GetLength(0); i++) {
            for (int j = 0; j < gridMatrix.GetLength(1); j++) {
        
                if (gridMatrix[i,j] == -1) {
                    totalCells--; 
                }
            }
        }
        
        ProgressText.text = "Progress:\n\n" + GetMatrixFillPercentage() + "%";
            ProgressBarAdjuster.transform.localScale = new Vector3(GetMatrixFillPercentage() / 100f, 1f, 1f);
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
                        errorsInBoundingBox += 1;
                    }
                    else {
                        // Set matrix value
                        gridMatrix[x, y] = 1;
                    }
                } catch (IndexOutOfRangeException e) {
                    errorsOutsideBoundingBox += 1;
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
                ScoreManager.GetComponent<ScoreManager>().SumLevelScore(GetMatrixFillPercentage());
            }
            else{
                spawnManager.GetComponent<SpawnManager>().ready = true;
            }
            ProgressText.text = "Progress:\n\n" + GetMatrixFillPercentage() + "%";
            ProgressBarAdjuster.transform.localScale = new Vector3(GetMatrixFillPercentage() / 100f, 1f, 1f);
            //ErrorText.text = "Errors:\n" + errors;
            piece = null;
        }
        
        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log("Matrix percentage: " + GetMatrixFillPercentage());
            Debug.Log("Matrix full: " + IsMatrixFull());
            Debug.Log("Errors in bounding box: " + errorsInBoundingBox);
            Debug.Log("Errors outside bounding box: " + errorsOutsideBoundingBox);
            Debug.Log(ShowMatrix());
        }

        if (Input.GetKeyDown(KeyCode.K)) {
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
        

        }

    void OnTriggerEnter2D(Collider2D other) {
        piece = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other) {
        piece = null;
    }

    int GetMatrixFillPercentage() {
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
        
        for (int i = 0; i < gridMatrix.GetLength(0); i++) {
            for (int j = 0; j < gridMatrix.GetLength(1); j++) {
        
            if (gridMatrix[i,j] == 0) {
                return false; 
            }
        }
        }
        return true;

    }

    private string ShowMatrix() {
        StringBuilder sb = new StringBuilder();
        for (int j = 0; j < bounds.size.y; j++) {
            for (int i = 0; i < bounds.size.x; i++) {
                sb.Append(gridMatrix[i, j]);
                sb.Append(" ");
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}

