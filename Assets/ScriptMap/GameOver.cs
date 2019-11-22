using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    private string start;
    public List<Collider> colliders;
    public BoxCollider chest;

    private AudioSource[] sounds;
    private float timer;

    // au démarrage, définir les volumes des sons en fonction du volume sauvegardé
    private void Start()
    {
        sounds = GetComponents<AudioSource>();
        sounds[0].volume = PlayerPrefs.GetFloat("volume") / 100;
        sounds[1].volume = PlayerPrefs.GetFloat("volume") / 100;
    }

    // mettre à jour le timer et l'afficher sur l'écran du joueur
    void Update()
    {
        timer += Time.deltaTime;
        GameObject.Find("Time Value").GetComponent<Text>().text = System.Math.Round(timer, 1).ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // lors d'une collision avec un élément "tueur", arrêter le son du jeu et afficher la scène "LostScreen"
        if (colliders.Find(x => x.name == collision.gameObject.name))
        {
            sounds[0].Stop();
            sounds[1].Play();
            SceneManager.LoadScene("Scenes/LostScreen");
        }
        else if (collision.gameObject.name == chest.gameObject.name) // collision avec le coffre -> écran de victoire
        {
            SceneManager.LoadScene("Scenes/WinScreen");
        }
    }
}
