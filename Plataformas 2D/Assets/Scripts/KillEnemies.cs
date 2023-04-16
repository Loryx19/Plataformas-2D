using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemies : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Debug.Log("Mato");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Debug.Log("Mato");
        }
    }
}
