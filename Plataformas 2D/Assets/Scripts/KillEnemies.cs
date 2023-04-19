using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemies : MonoBehaviour
{
    [SerializeField] Health_Enemies health_Enemie;
    [SerializeField] int Damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            health_Enemie = collision.gameObject.GetComponent<Health_Enemies>();
            health_Enemie.RestaVida(Damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            health_Enemie = collision.gameObject.GetComponent<Health_Enemies>();
            health_Enemie.RestaVida(Damage);
        }
    }
}
