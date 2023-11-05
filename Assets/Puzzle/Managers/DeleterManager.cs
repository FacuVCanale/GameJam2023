using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleterManager : MonoBehaviour
{
    public GameObject SpawnManager;
    private void OnTriggerEnter2D(Collider2D tetrisPiece) {
        Debug.Log("Triggered with " + tetrisPiece.name);
        Destroy(tetrisPiece.gameObject);
        SpawnManager.GetComponent<SpawnManager>().ready = true;
    }
}
