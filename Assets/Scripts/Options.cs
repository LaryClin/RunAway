using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    private const float DefaultVolumeLevel = 50.0f; // volume par défaut à 50 si pas de préférences encore sauvegardées
    private Slider VolumeBar;
    void Start()
    {
        VolumeBar = GameObject.Find("VolumeBar").GetComponent<Slider>();

        VolumeBar.value = PlayerPrefs.HasKey("volume") ? PlayerPrefs.GetFloat("volume") : DefaultVolumeLevel;
    }

    // mettre à jour le volume dans les préférences utilisateurs (persistance)
    public void UpdateVolume(Slider volumeBar)
    {
        PlayerPrefs.SetFloat("volume", volumeBar.value);
    }
    // sauvegarder le volume
    public void BackButton()
    {
        PlayerPrefs.Save();
    }
}
