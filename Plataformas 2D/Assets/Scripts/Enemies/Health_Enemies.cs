using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Enemies : MonoBehaviour
{
    [SerializeField] EnemieGoToAB Enemi;
    [SerializeField] int MaxVida;
    int vida;
    // Start is called before the first frame update
    void Start()
    {
        vida = MaxVida;
    }
    public void RestaVida(int Damage)
    {
        vida -= Damage;
        if (vida <= 0)
        {
            Destroy(Enemi.gameObject);
        }
    }
}
