using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] AudioSource Audio;
    [SerializeField] int ValorScore;
    GameManager Game;
    private void Awake()
    {
        Game = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            Game.SumaScore(ValorScore);
            Audio.PlayOneShot(Audio.clip);
            anim.SetBool("Recolected", true);
            Destroy(gameObject, 0.40f);
        }
    }
}
