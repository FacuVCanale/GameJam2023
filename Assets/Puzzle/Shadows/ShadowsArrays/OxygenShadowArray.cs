using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenShadowArray : MonoBehaviour
{
    public int[,] gridMatrix;
    // Start is called before the first frame update
    void Start()
    {
        gridMatrix = new int[10,8];
        for (int i = 0; i < 10; i++) {
            if (i == 0 || i == 9) {
                for (int j = 0; j < 8; j++) {
                    if (j == 0 || j == 1 || j == 6 || j == 7) {
                    gridMatrix[i,j] = -1;
                    }
                }
                if (i == 4 && i == 5) {
                    for (int j = 0; j < 8; j++) {
                        if (j != 3 && j != 4) {
                            gridMatrix[i,j] = -1;
                        }
                    }
                }
            }
        }
    }

    public int[,] GetGridMatrix() {
        return gridMatrix;
    }
}
