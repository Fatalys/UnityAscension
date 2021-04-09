using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarentino : MonoBehaviour
{

    // FOV horizontale
    private float horizontale = 50.0f;

    public MenuJeu Menu;

    public AudioSource Vent;
    public AudioSource Musique;

    public bool mobile = false;

    public float vitesse = 2.0f;

    public float acceleration = 3.0f;

    private float tempsacceleration = 1.0f;

    private float impulsion = 1.5f;

    private float logarithme = Mathf.Log(1.5f);

    private float calculVerticale(float hFOVInDeg, float aspectRatio)
    {
        float hFOVInRads = hFOVInDeg * Mathf.Deg2Rad;
        float vFOVInRads = 2 * Mathf.Atan(Mathf.Tan(hFOVInRads / 2) / aspectRatio);
        float vFOV = vFOVInRads * Mathf.Rad2Deg;
        return vFOV;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().fieldOfView = calculVerticale(horizontale, Camera.main.aspect);
        switch (GameValues.Difficulte)
        {
            case GameValues.Difficultes.normal:
                acceleration = 4.0f;
                break;
            case GameValues.Difficultes.nuage:
                acceleration = 4.0f;
                break;
            case GameValues.Difficultes.plateforme:
                acceleration = 7.0f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mobile && !Menu.estPause)
        {
            tempsacceleration -= Time.deltaTime;
            if (tempsacceleration <= 0)
            {
                impulsion += 0.05f;
                vitesse += ((float)Mathf.Log(impulsion)-logarithme) * acceleration;
                logarithme = (float)Mathf.Log(impulsion);
                tempsacceleration = 1;
            }
            transform.Translate(0, vitesse * Time.deltaTime, 0);
        }
    }
}
