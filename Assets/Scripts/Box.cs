using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour 
{
    private Animator boxAnimator;
    // Start is called before the first frame update
    void Start()
    {
        boxAnimator = GetComponent<Animator>();

    }
  void OnTriggerEnter2D(Collider2D other) 
  {
    boxAnimator.SetTrigger("Died");

  }

}
