using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public GameObject shadow;
    public GameObject progress;
    public GameObject Message;


    
    public void Continue()
    {
        Destroy(GameObject.FindWithTag("TetrisPiece"));
        
        foreach (Transform child in Message.transform)
        {
            child.gameObject.SetActive(false);
        }

        
        Destroy(shadow.transform.GetChild(0).gameObject);
        shadow.transform.GetChild(0).gameObject.SetActive(true);

        
        Destroy(progress.transform.GetChild(0).gameObject);
        progress.transform.GetChild(0).gameObject.SetActive(true);
    }
    
}
