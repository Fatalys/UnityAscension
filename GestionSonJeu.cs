using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionSonJeu : MonoBehaviour
{
    public Sam sam;
    public Toggle estAmbiance;
    public Toggle estEffets;
    public Toggle estMusique;
    public AudioSource Ambiance;
    public AudioSource[] Effets;
    public AudioSource Musique;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("AmbianceSon") % 2 == 1)
        {
            estAmbiance.SetIsOnWithoutNotify(false);
        }
        else
        {
            estAmbiance.SetIsOnWithoutNotify(true);
        }

        if (PlayerPrefs.GetInt("EffetsSon") % 2 == 1)
        {
            estEffets.SetIsOnWithoutNotify(false);
        }
        else
        {
            estEffets.SetIsOnWithoutNotify(true);
        }

        if (PlayerPrefs.GetInt("MusiqueSon") % 2 == 1)
        {
            estMusique.SetIsOnWithoutNotify(false);
        }
        else
        {
            estMusique.SetIsOnWithoutNotify(true);
        }

        Musique.mute = !estMusique.isOn;
        Ambiance.mute = !estAmbiance.isOn;

        foreach (AudioSource Effet in Effets)
        {
            Effet.mute = !estEffets.isOn;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AmbianceActif()
    {
        Ambiance.mute = !estAmbiance.isOn;
        PlayerPrefs.SetInt("AmbianceSon", PlayerPrefs.GetInt("AmbianceSon") + 1);
        sam.Attaque();
    }

    public void EffetsActif()
    {
        foreach (AudioSource Effet in Effets)
        {
            Effet.mute = !estEffets.isOn;
        }
        PlayerPrefs.SetInt("EffetsSon", PlayerPrefs.GetInt("EffetsSon") + 1);
        sam.Attaque2();
    }

    public void MusiqueActif()
    {
        Musique.mute = !estMusique.isOn;
        PlayerPrefs.SetInt("MusiqueSon", PlayerPrefs.GetInt("MusiqueSon") + 1);
        sam.Attaque();
    }

}
