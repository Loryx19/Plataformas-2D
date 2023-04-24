using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void ComienzaJuego(int scena)
    {
        SceneManager.LoadScene(scena);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
