using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Evenement : MonoBehaviour
{
    public GameObject[] Dialogues;
    public GameObject BoutonSuivant;
    public int Identifiant;
    public int dejafait;

    // Start is called before the first frame update
    void Start()
    {
        Identifiant = 0;
        dejafait = PlayerPrefs.GetInt("FaitTuto");
        if (dejafait == 0)
        {
            Dialogues[0].SetActive(true);
        }
        else 
        {
            Dialogues[11].SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Suivant()
    {
        if (dejafait == 0)
        {
            if (Identifiant == 0)
            {
                Dialogues[0].SetActive(false);
                Dialogues[1].SetActive(true);
            }
            if (Identifiant == 1)
            {
                Dialogues[1].SetActive(false);
                Dialogues[2].SetActive(true);
                BoutonSuivant.SetActive(false);
            }
            if (Identifiant == 3)
            {
                Dialogues[3].SetActive(false);
                Dialogues[4].SetActive(true);
                BoutonSuivant.SetActive(false);
            }
            if (Identifiant == 5)
            {
                Dialogues[5].SetActive(false);
                Dialogues[6].SetActive(true);
                BoutonSuivant.SetActive(false);
            }
            if (Identifiant == 7)
            {
                PlayerPrefs.SetInt("Revivre", PlayerPrefs.GetInt("Revivre") + 10);
                PlayerPrefs.SetInt( ("FaitTuto"), PlayerPrefs.GetInt("FaitTuto") + 1 );
                Dialogues[6].SetActive(false);
                Dialogues[7].SetActive(true);
            }
            if (Identifiant == 8)
            {
                Dialogues[7].SetActive(false);
                Dialogues[8].SetActive(true);
            }
            if (Identifiant == 9)
            {
                Dialogues[8].SetActive(false);
                Dialogues[9].SetActive(true);
            }
            if (Identifiant == 10)
            {
                Dialogues[9].SetActive(false);
                Dialogues[10].SetActive(true);
            }
            if (Identifiant == 11)
            {
                SceneManager.LoadScene("EcranAccueil");
            }
        }
        else if (dejafait < 10)
        {
            if (Identifiant == 0)
            {
                Dialogues[11].SetActive(false);
                Dialogues[1].SetActive(true);
            }
            if (Identifiant == 1)
            {
                Dialogues[1].SetActive(false);
                Dialogues[2].SetActive(true);
                BoutonSuivant.SetActive(false);
            }
            if (Identifiant == 3)
            {
                Dialogues[3].SetActive(false);
                Dialogues[4].SetActive(true);
                BoutonSuivant.SetActive(false);
            }
            if (Identifiant == 5)
            {
                Dialogues[5].SetActive(false);
                Dialogues[6].SetActive(true);
                BoutonSuivant.SetActive(false);
            }
            if (Identifiant == 7)
            {
                PlayerPrefs.SetInt(("FaitTuto"), PlayerPrefs.GetInt("FaitTuto") + 1);
                Dialogues[12].SetActive(false);
                Dialogues[13].SetActive(true);
            }
            if (Identifiant == 8)
            {
                Dialogues[13].SetActive(false);
                Dialogues[8].SetActive(true);
            }
            if (Identifiant == 9)
            {
                Dialogues[8].SetActive(false);
                Dialogues[9].SetActive(true);
            }
            if (Identifiant == 10)
            {
                Dialogues[9].SetActive(false);
                Dialogues[10].SetActive(true);
            }
            if (Identifiant == 11)
            {
                SceneManager.LoadScene("EcranAccueil");
            }
        }
        else
        {
            if (Identifiant == 0)
            {
                Dialogues[11].SetActive(false);
                Dialogues[1].SetActive(true);
            }
            if (Identifiant == 1)
            {
                Dialogues[1].SetActive(false);
                Dialogues[2].SetActive(true);
                BoutonSuivant.SetActive(false);
            }
            if (Identifiant == 3)
            {
                Dialogues[3].SetActive(false);
                Dialogues[4].SetActive(true);
                BoutonSuivant.SetActive(false);
            }
            if (Identifiant == 5)
            {
                Dialogues[5].SetActive(false);
                Dialogues[6].SetActive(true);
                BoutonSuivant.SetActive(false);
            }
            if (Identifiant == 7)
            {
                PlayerPrefs.SetInt(("FaitTuto"), PlayerPrefs.GetInt("FaitTuto") + 1);
                Dialogues[14].SetActive(false);
                Dialogues[15].SetActive(true);
            }
            if (Identifiant == 8)
            {
                Dialogues[15].SetActive(false);
                Dialogues[8].SetActive(true);
            }
            if (Identifiant == 9)
            {
                Dialogues[8].SetActive(false);
                Dialogues[9].SetActive(true);
            }
            if (Identifiant == 10)
            {
                Dialogues[9].SetActive(false);
                Dialogues[10].SetActive(true);
            }
            if (Identifiant == 11)
            {
                SceneManager.LoadScene("EcranAccueil");
            }
        }
        Identifiant++;
    }
}
