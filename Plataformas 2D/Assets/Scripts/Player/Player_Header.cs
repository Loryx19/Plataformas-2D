using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Header : MonoBehaviour
{
    Player_Movement movePlayer;
    [SerializeField] int MaxVida;
    [HideInInspector] public int vida;
    GameManager Game;
    // Start is called before the first frame update
    void Start()
    {
        vida = MaxVida;
        Game = FindAnyObjectByType<GameManager>();
        movePlayer = GetComponent<Player_Movement>();
    }
    public void RestaVida(int Damage)
    {
        vida -= Damage;
        transform.position = movePlayer.inicialPoint;
        if(vida <= 0)
        {
            Game.MuerteJugador();
        }
    }
}
