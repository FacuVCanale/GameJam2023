using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisPieces : MonoBehaviour
{
    public Vector3 moveDirection;
    public float stepDelay;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > stepDelay) 
        {
            transform.position += moveDirection;
            timer = 0;
        }
    }
}
