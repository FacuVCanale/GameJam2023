using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeat : MonoBehaviour
{
    private float spriteWidth;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
        spriteWidth = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -spriteWidth)
        {
            transform.Translate(Vector2.right * 2f * spriteWidth);
        }
    }
}
