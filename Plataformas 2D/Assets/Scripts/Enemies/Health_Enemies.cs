using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Enemies : MonoBehaviour
{
    [SerializeField] EnemieGoToAB Enemi;
    [SerializeField] AudioSource audio;
    [SerializeField] int MaxVida;
    int vida;
    private void Awake()
    {
        audio = GetComponentInChildren<AudioSource>();
    }
    void Start()
    {
        vida = MaxVida;
    }
    public void RestaVida(int Damage)
    {
        vida -= Damage;
        if (vida <= 0)
        {
            audio.PlayOneShot(audio.clip);
            Destroy(Enemi.gameObject, 0.1f);
        }
    }
}
