using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerShadowArray : MonoBehaviour
{
    public int[,] gridMatrix;
    // Start is called before the first frame update
 

    public int[,] GetGridMatrix() {
        gridMatrix = new int[12,6];
        return gridMatrix;
    }


}
