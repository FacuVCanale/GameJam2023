using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public int[,] gridMatrix;

    
    private GameObject piece;
    
    public BoxCollider2D shadowBoxCollider;
    private Bounds bounds;

    private int errors;

    void Start() {
        bounds = GetComponent<BoxCollider2D>().bounds; 
        gridMatrix = new int[Mathf.CeilToInt(bounds.size.x), Mathf.CeilToInt(bounds.size.y)];
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return) && piece != null) {
            piece.GetComponent<TetrisPieces>().moveDirection = Vector3.zero;
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
                Debug.Log("Child: " + child.name);

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
                    Debug.Log("Index out of range: " + e);
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log("Matrix percentage: " + GetMatrixFillPercentage());
            Debug.Log("Matrix full: " + IsMatrixFull());
        }
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

    float GetMatrixFillPercentage() {

    int totalCells = gridMatrix.GetLength(0) * gridMatrix.GetLength(1);
    int filledCells = 0;

    for (int i = 0; i < gridMatrix.GetLength(0); i++) {
        for (int j = 0; j < gridMatrix.GetLength(1); j++) {
        
        if (gridMatrix[i,j] == 1) {
            filledCells++; 
        }
        
        }
    }

    return (float)filledCells / (errors + totalCells) * 100f;

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
