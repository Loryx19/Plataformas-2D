using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiilPlayer : MonoBehaviour
{
    Player_Header VidaPlayer;
    [SerializeField] int Damage;
    private void Awake()
    {
        VidaPlayer = FindAnyObjectByType<Player_Header>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            VidaPlayer.RestaVida(Damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            VidaPlayer.RestaVida(Damage);
        }
    }
}

