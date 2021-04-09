using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class Invocateur : MonoBehaviour
{

    public GameObject PlateformeRocher, PlateformeNoire, PlateformeNuage;

    public Tarentino Realisateur;

    public int Identifiant,IdentifiantActuel = 0;

    private bool[] Palier;

    private float ProbaNoire;
    private float ProbaNuage;

    private float PositionSuivante = 0.0f;

    public bool Retourne, InitialisationRetourne;

    private Vector3 Position;

    // Start is called before the first frame update
    void Start()
    {
        switch (GameValues.Difficulte)
        {
            case GameValues.Difficultes.normal:
                PlayerPrefs.SetInt("PartieNormale", PlayerPrefs.GetInt("PartieNormale") + 1 );
                ProbaNoire = 0.2f;
                ProbaNuage = 0.05f;
                break;
            case GameValues.Difficultes.nuage:
                PlayerPrefs.SetInt("PartieNuage", PlayerPrefs.GetInt("PartieNuage") + 1);
                ProbaNoire = 0f;
                ProbaNuage = 1.0f;
                break;
            case GameValues.Difficultes.plateforme:
                PlayerPrefs.SetInt("PartiePlateforme", PlayerPrefs.GetInt("PartiePlateforme") + 1);
                ProbaNoire = 0.0f;
                ProbaNuage = 0.0f;
                break;
        }

        Position = new Vector3(Random.Range(0.0f, 3.5f), 0, 0);
        PositionSuivante = Random.Range(-3.5f, 3.5f);
  
        if (PositionSuivante < Position.x)
        {
            Retourne = true;
        }
        else
        {
            Retourne = false;
        }
        GameObject Plateforme = Instantiate(PlateformeRocher, Position, Quaternion.identity);
        Identifiant++;

        Palier = new bool[] { true, true, true, true, true, true };


        /*

        for (int i = 0; i < 5; i++)
        {
            Position.x = PositionSuivante;
            PositionSuivante = Random.Range(-3.5f, 3.5f);
            Position.y += 4.0f;

            if (PositionSuivante < Position.x)
            {
                Retourne = true;
            }
            else
            {
                Retourne = false;
            }

            Plateforme = Instantiate(PlateformeRocher, Position, Quaternion.identity);
            Identifiant++;

        }

        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Realisateur.vitesse > 5 && Palier[0])
        {
            Palier[0] = false;
            switch (GameValues.Difficulte)
            {
                case GameValues.Difficultes.normal:
                    ProbaNoire = 0.25f;
                    ProbaNuage = 0.1f;
                    break;
            }
        }
        if (Realisateur.vitesse > 8 && Palier[1])
        {
            Palier[1] = false;
            switch (GameValues.Difficulte)
            {
                case GameValues.Difficultes.normal:
                    ProbaNoire = 0.30f;
                    ProbaNuage = 0.15f;
                    break;
            }
        }
        if (Realisateur.vitesse > 10 && Palier[2])
        {
            Palier[2] = false;
            switch (GameValues.Difficulte)
            {
                case GameValues.Difficultes.normal:
                    ProbaNoire = 0.33f;
                    ProbaNuage = 0.20f;
                    break;
            }
        }

        if (Realisateur.vitesse > 12 && Palier[3])
        {
            Palier[3] = false;
            switch (GameValues.Difficulte)
            {
                case GameValues.Difficultes.normal:
                    ProbaNoire = 0.33f;
                    ProbaNuage = 0.25f;
                    break;
            }
        }

        if (Realisateur.vitesse > 15 && Palier[4])
        {
            Palier[4] = false;
            switch (GameValues.Difficulte)
            {
                case GameValues.Difficultes.normal:
                    ProbaNoire = 0.33f;
                    ProbaNuage = 0.33f;
                    break;
            }
        }
        if (Realisateur.vitesse > 20 && Palier[5])
        {
            Palier[5] = false;
            switch (GameValues.Difficulte)
            {
                case GameValues.Difficultes.normal:
                    ProbaNoire = 0.15f;
                    ProbaNuage = 0.70f;
                    break;
            }
        }
        Apparition();
    }

    private void Apparition()
    {
        if (Camera.main.transform.position.y + 10f > Position.y)
        {
            float aleatoire = Random.value;
            Position.x = PositionSuivante;
            PositionSuivante = Random.Range(-3.5f, 3.5f);
            Position.y += 4.0f;
            if (PositionSuivante < Position.x)
            {
                Retourne = true;
            }
            else
            {
                Retourne = false;
            }
            if (aleatoire <= ProbaNoire)
            {
                GameObject Plateforme = Instantiate(PlateformeNoire, Position, Quaternion.identity);
            }
            else if (ProbaNoire < aleatoire && aleatoire <= ProbaNuage + ProbaNoire)
            {
                GameObject Plateforme = Instantiate(PlateformeNuage, Position, Quaternion.identity);
            }
            else
            {
                GameObject Plateforme = Instantiate(PlateformeRocher, Position, Quaternion.identity);
            }
            Identifiant++;
        }
    }
}
