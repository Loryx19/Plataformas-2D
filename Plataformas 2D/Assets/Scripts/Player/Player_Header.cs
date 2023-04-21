using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Header : MonoBehaviour
{
    Player_Movement movePlayer;
    [SerializeField] Player_Audio audioPlayer;
    [SerializeField] AudioSource audio;
    [SerializeField] int MaxVida;
    [HideInInspector] public int vida;
    GameManager Game;
    // Start is called before the first frame update
    void Start()
    {
        vida = MaxVida;
        Game = FindAnyObjectByType<GameManager>();
        movePlayer = GetComponent<Player_Movement>();
        audioPlayer = GetComponentInChildren<Player_Audio>();
        audio = GetComponentInChildren<AudioSource>();
    }
    public void RestaVida(int Damage)
    {
        vida -= Damage;
        audio.PlayOneShot(audioPlayer.HitClip);
        transform.position = movePlayer.inicialPoint;
        if(vida <= 0)
        {
            Game.MuerteJugador();
        }
    }
}
