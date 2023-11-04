using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleterManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D tetrisPiece) {
        Destroy(tetrisPiece.gameObject);
    }
}
