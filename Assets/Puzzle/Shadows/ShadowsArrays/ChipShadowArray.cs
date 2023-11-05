using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipShadowArray : MonoBehaviour
{

    public int[,] gridMatrix;
    // Start is called before the first frame update

    public int[,] GetGridMatrix() {
        gridMatrix = new int[8,8];
        for (int i = 0; i < 8; i++) {
            if (i != 2 && i != 5) {
                gridMatrix[i, 0] = -1;
                gridMatrix[i, 7] = -1;
                gridMatrix[0, i] = -1;
                gridMatrix[7, i] = -1;
            }
        }
        return gridMatrix;
    }
}
