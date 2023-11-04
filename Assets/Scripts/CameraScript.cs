using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject John;

    void Update()
    {
            Vector3 position = transform.position;
            position.x = John.transform.position.x;
            transform.position = position;
    }
}