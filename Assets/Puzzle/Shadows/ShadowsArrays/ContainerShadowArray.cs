using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerShadowArray : MonoBehaviour
{
    public int[,] gridMatrix;
    // Start is called before the first frame update
    void Start()
    {
        gridMatrix = new int[12,6];

    }

    public int[,] GetGridMatrix() {
        return gridMatrix;
    }


}
