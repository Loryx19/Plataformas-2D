using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrampolineImpulse : MonoBehaviour
{
    [SerializeField] float ImpulseForce;
    Animator anim;
    private void Start()
    {
        anim= GetComponentInParent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("Impulse", true);
            collision.gameObject.GetComponent<Rigidbody2D>()
                .AddForce(new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, ImpulseForce),
                ForceMode2D.Impulse);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("Impulse", false);
    }
}
