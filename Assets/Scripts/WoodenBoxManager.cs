using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBoxManager : MonoBehaviour
{   
    public static WoodenBoxManager Instance {get; private set; }
    public void destroyThis(GameObject woodenbox) {
        Destroy(woodenbox);
    }
}
