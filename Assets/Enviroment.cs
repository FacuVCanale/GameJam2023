using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    public GameObject front;
    public Transform start;
    public Transform end;
    public float enviromentVelocity = 15.0f;

    public List<GameObject> props;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageMovement();
        ManageSpawnCicle();
    }

    void ManageMovement()
    {
        front.transform.position = new Vector3(front.transform.position.x - enviromentVelocity * Time.deltaTime, front.transform.position.y, front.transform.position.z);
    }

    void ManageSpawnCicle()
    {
        foreach (GameObject prop in props)
        {
            if(prop.transform.position.x <= end.position.x)
            {
                prop.transform.position = new Vector3(start.position.x, prop.transform.position.y, prop.transform.position.z);
            }
        }
    }

}
