using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerShadowArray : MonoBehaviour
{
    public int[,] gridMatrix;
    // Start is called before the first frame update
    void Start()
    {
        gridMatrix = new int[10,12];
        ZeroToMatrix(1,1);
        ZeroToMatrix(6,1);
        ZeroToMatrix(1,7);
        ZeroToMatrix(6,7);
    }

    public int[,] GetGridMatrix() {
        return gridMatrix;
    }

    private void ZeroToMatrix(int x, int y) {
        gridMatrix[x,y] = -1;
        gridMatrix[x+1,y] = -1;
        gridMatrix[x+2,y] = -1;
        gridMatrix[x+2,y-1] = -1;
        gridMatrix[x+2,y-2] = -1;
        gridMatrix[x+2,y-3] = -1;
        gridMatrix[x+1,y-3] = -1;
        gridMatrix[x,y-3] = -1;
        gridMatrix[x,y-2] = -1;
        gridMatrix[x,y-1] = -1;
    }
}
