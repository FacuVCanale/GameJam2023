using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class John : MonoBehaviour
{
    [SerializeField] private float upForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float radius;

    private Rigidbody2D dinoRb;
    private Animator dinoAnimator;
    // Start is called before the first frame update
    void Start()
    {
        dinoRb = GetComponent<Rigidbody2D>();
        dinoAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        bool IsGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, ground);
        dinoAnimator.SetBool("IsGrounded", IsGrounded);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            dinoRb.AddForce(Vector2.up * upForce);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Obstacle")) {
            Destroy(collision.gameObject);
            if (collision.gameObject.name.Contains("Box")) 
            {
            GameManager.Instance.EraseHype(0.7f); 
            }
            else if (collision.gameObject.name.Contains("Down")) 
            {
            GameManager.Instance.EraseHype(0.5f); 
            }
            else if (collision.gameObject.name.Contains("Stairs")) 
            {
            GameManager.Instance.EraseHype(0.1f); 
            }
            else
            {
            GameManager.Instance.EraseHype(0.3f); 
            }
        }
    }
}
