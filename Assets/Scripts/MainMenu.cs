using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // charger le menu de sélection de niveaux
    public void PlayGame()
    {
        SceneManager.LoadScene("Scenes/LevelSelection");
    }

    // fermer l'application
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    // retourner au menu principal
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

    // charger le niveau 2
    public void NextLevel()
    {
        SceneManager.LoadScene("Scenes/Map2");
    }

    // charger le niveau 1
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Scenes/Map1");
    }
}