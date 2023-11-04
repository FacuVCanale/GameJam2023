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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.EraseHype();
            Destroy(collision.gameObject);
        }
    }
}
