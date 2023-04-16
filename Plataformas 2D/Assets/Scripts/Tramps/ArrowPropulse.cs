using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPropulse : MonoBehaviour
{
    [SerializeField] float ImpulseForce;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Hit", true);
            collision.gameObject.GetComponent<Rigidbody2D>()
                .AddForce(new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, ImpulseForce),
                ForceMode2D.Impulse);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("Hit", false);
    }
}
