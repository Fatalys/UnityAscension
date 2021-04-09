using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemeSon : MonoBehaviour
{

    public AudioSource Ambiance;
    public AudioSource[] Effets;
    public AudioSource Musique;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("AmbianceSon") % 2 == 1)
        {
            Ambiance.mute = true;
        }

        if (PlayerPrefs.GetInt("EffetsSon") % 2 == 1)
        {
            foreach (AudioSource Effet in Effets)
            {
                Effet.mute = true;
            }
        }

        if (PlayerPrefs.GetInt("MusiqueSon") % 2 == 1)
        {
            Musique.mute = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
