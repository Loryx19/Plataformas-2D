using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FinNivel : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] int NivelScena;
    [SerializeField] Transform recompensasPadre;
    int Recomp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameManager = FindAnyObjectByType<GameManager>();
            Recomp = recompensasPadre.childCount;
            if (Recomp == 0)
            {
                gameManager = FindAnyObjectByType<GameManager>();
                gameManager.CambioNivel(NivelScena);
            }
        }
    }
}
