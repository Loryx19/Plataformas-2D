using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPropulse : MonoBehaviour
{
    [SerializeField] float ImpulseForce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>()
                .AddForce(new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, ImpulseForce),
                ForceMode2D.Impulse);
        }
    }
}
