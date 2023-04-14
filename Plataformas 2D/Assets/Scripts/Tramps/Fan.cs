using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] float Force;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>()
               .AddForce(new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, Force),
               ForceMode2D.Force);
        }
    }
}
