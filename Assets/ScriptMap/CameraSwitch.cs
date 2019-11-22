using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject cameraOne;
    public GameObject cameraTwo;

    AudioListener cameraOneAudioLis;
    AudioListener cameraTwoAudioLis;

    void Start ()
    {
        cameraOneAudioLis = cameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis = cameraTwo.GetComponent<AudioListener>();

        cameraPostionChange(PlayerPrefs.GetInt("CameraPostion"));
	}
	
	void Update ()
    {
        // lors de l'appui sur la touche E, tourner la caméra du joueur à 180degrés
        if (Input.GetKeyDown(KeyCode.E))
        {
            cameraChangeCounter();
        }
    }

    // compteur pour la caméra, 0 = vue de face - 1 = vue de derrière
    void cameraChangeCounter()
    {
        int cameraPostionCounter = PlayerPrefs.GetInt("CameraPostion");
        cameraPostionCounter++;
        cameraPostionChange(cameraPostionCounter);
    }

    // changer la position de la caméra
    void cameraPostionChange(int camPosition)
    {
        if(camPosition > 1)
        {
            camPosition = 0;
        }

        PlayerPrefs.SetInt("CameraPostion", camPosition);

        if(camPosition == 0)
        {
            cameraOne.SetActive(true);
            cameraOneAudioLis.enabled = true;

            cameraTwoAudioLis.enabled = false;
            cameraTwo.SetActive(false);
        }

        if(camPosition == 1)
        {
            cameraTwo.SetActive(true);
            cameraTwoAudioLis.enabled = true;

            cameraOneAudioLis.enabled = true;
            cameraOne.SetActive(false);

        }
    }

}
