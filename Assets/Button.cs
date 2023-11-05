using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject shadows;
    
    private int shadowIndex = 0;
    private List<GameObject> shadowList;


    void Start() {
        // Get an array of all the child GameObjects
        Transform[] shadowsChildren = shadows.GetComponentsInChildren<Transform>();
        foreach (Transform shadow in shadowsChildren) {
            shadowList.Add(shadow.gameObject);
        }
    }

    public void OnButtonPress() {
        GameObject TetrisToDelete = GameObject.FindWithTag("TetrisPiece");
        while (TetrisToDelete != null) {
            Destroy(TetrisToDelete);
            TetrisToDelete = GameObject.FindWithTag("TetrisPiece");
        }

        if (shadowIndex >= shadowList.Count) {
            shadowIndex = 0;
        }
        if (shadowIndex > 0) {
            shadowList[shadowIndex-1].SetActive(false);
        }
        shadowList[shadowIndex].SetActive(true);
        shadowIndex += 1;
    }
    
}
