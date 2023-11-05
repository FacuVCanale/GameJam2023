using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class John : MonoBehaviour
{
    [SerializeField] private float upForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float radius;
    BoxCollider2D boxCollider;

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
            
            if (collision.gameObject.name.Contains("Box")) 
            {
                GameManager.Instance.EraseHype(0.7f); 
                collision.gameObject.GetComponent<Animator>().SetBool("Died", true);
                RemoveBoxCollider(collision.gameObject); 
            }
            else if (collision.gameObject.name.Contains("Pipes"))
            {
            GameManager.Instance.EraseHype(0.5f);
            collision.gameObject.GetComponent<Animator>().SetBool("Died", true);
            RemoveBoxCollider(collision.gameObject); 
            }
            else if (collision.gameObject.name.Contains("Pipe")) 
            {
            GameManager.Instance.EraseHype(0.3f);
            collision.gameObject.GetComponent<Animator>().SetBool("Died", true);
            RemoveBoxCollider(collision.gameObject);
            }
            else if (collision.gameObject.name.Contains("Stairs")) 
            {
            GameManager.Instance.EraseHype(0.1f);
            Destroy(collision.gameObject);
            }


        void RemoveBoxCollider(GameObject box) {

            BoxCollider2D boxCollider = box.GetComponent<BoxCollider2D>();

                if(boxCollider != null) {
                    box.GetComponent<BoxCollider2D>().enabled = false;
                }

        }
            
        }
    }
}
