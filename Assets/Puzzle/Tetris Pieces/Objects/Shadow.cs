using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    private GameObject piece;
    
    public BoxCollider2D shadowBoxCollider;

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
    }
  }

    private void OnTriggerEnter2D(Collider2D other) {
        piece = other.gameObject;
        Debug.Log("Shadow colliding with " + other.gameObject.name);
    }

    private void OnTriggerStay2D(Collider2D other) {
        piece = other.gameObject;
        Debug.Log("Shadow colliding with " + other.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D other) {
        piece = null;
        Debug.Log("Shadow stopped colliding with " + other.gameObject.name);
    }

    public bool IsFull() {
        if (shadowBoxCollider.IsTouchingLayers(LayerMask.GetMask("TetrisPiece"))) {
            Debug.Log("Shadow is full");
            return true;
        }
        return false;
    }
}
