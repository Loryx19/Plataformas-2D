using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Aceso a otros scipts")]
    [SerializeField] Player_Header VidaPlayer;
    [Header("Textos")]
    [SerializeField] TextMeshProUGUI ScoreTxt;
    [SerializeField] TextMeshProUGUI VidaText;
    int vida, score;
    private void Start()
    {
        VidaPlayer = FindAnyObjectByType<Player_Header>();
        vida = VidaPlayer.vida;
        ScoreTxt.text = score.ToString();
        VidaText.text = vida.ToString();
    }
    private void Update()
    {
        vida = VidaPlayer.vida;
        ScoreTxt.text = score.ToString();
        VidaText.text = vida.ToString();
    }
    public void SumaScore(int Valor)
    {
        score += Valor;
    }
    public void MuerteJugador()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
