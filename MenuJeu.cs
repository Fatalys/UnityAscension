using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Advertisements;


public class MenuJeu : MonoBehaviour
{
    public Tarentino Realisateur;

    public GameObject BoutonPause;

    public GameObject MenuPause;

    public GameObject MenuMort;

    public GameObject MenuOptions, PanneauPub;

    public GameObject Reste0, Reste1, Reste2;

    public bool estPause;

    public Sam sam;

    public TextMeshProUGUI Score, ScoreMort, Meilleur;

    public TextMeshProUGUI VieRestante, PrixTexte;

    private int LeScore;

    private int RestePause = 2;

    private float Metre;

    private float Distance;

    private int PrixVie = 0;

    private int NombreMort = 0;

    public string gameId = "3762633";
    public bool testMode = false;

    // Start is called before the first frame update
    void Start()
    {
        Score = Score.GetComponent<TextMeshProUGUI>();
        ScoreMort = ScoreMort.GetComponent<TextMeshProUGUI>();
        Meilleur = Meilleur.GetComponent<TextMeshProUGUI>();
        Score.text = "Départ";

        VieRestante = VieRestante.GetComponent<TextMeshProUGUI>();

        PrixTexte = PrixTexte.GetComponent<TextMeshProUGUI>();

        Distance = sam.transform.position.y;

        Metre = 1.9f / 0.6f;

        int Pub = Random.Range(1, 3);

        Advertisement.Initialize(gameId, testMode);
        if (Advertisement.IsReady() && Pub == 1 && PlayerPrefs.GetInt("Publicite") % 2 == 0)
        {
            Advertisement.Show();
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        LeScore = (int)((sam.transform.position.y - Distance) * Metre);
        Score.text = LeScore + " m";
        ScoreMort.text = "Vous avez atteint :\n" + LeScore + " m";

        switch (GameValues.Difficulte)
        {
            case GameValues.Difficultes.normal:
                if (LeScore > PlayerPrefs.GetInt("MeilleurNormal"))
                {
                    PlayerPrefs.SetInt("MeilleurNormal", LeScore);
                }
                if( NombreMort == 0 && LeScore > PlayerPrefs.GetInt("MeilleurNormalSansVie") )
                {
                    PlayerPrefs.SetInt("MeilleurNormalSansVie", LeScore);
                }
                Meilleur.text = "Votre Meilleur Score :\n" + PlayerPrefs.GetInt("MeilleurNormal") + " m";
                break;
            case GameValues.Difficultes.nuage:
                if (LeScore > PlayerPrefs.GetInt("MeilleurNuage"))
                {
                    PlayerPrefs.SetInt("MeilleurNuage", LeScore);
                }
                if (NombreMort == 0 && LeScore > PlayerPrefs.GetInt("MeilleurNuageSansVie"))
                {
                    PlayerPrefs.SetInt("MeilleurNuageSansVie", LeScore);
                }
                Meilleur.text = "Votre Meilleur Score :\n" + PlayerPrefs.GetInt("MeilleurNuage") + " m";
                break;
            case GameValues.Difficultes.plateforme:
                if (LeScore > PlayerPrefs.GetInt("MeilleurPlateforme"))
                {
                    PlayerPrefs.SetInt("MeilleurPlateforme", LeScore);
                }
                if (NombreMort == 0 && LeScore > PlayerPrefs.GetInt("MeilleurPlateformeSansVie"))
                {
                    PlayerPrefs.SetInt("MeilleurPlateformeSansVie", LeScore);
                }
                Meilleur.text = "Votre Meilleur Score :\n" + PlayerPrefs.GetInt("MeilleurPlateforme") + " m";
                break;
        }

        VieRestante.text = PlayerPrefs.GetInt("Revivre") + "";
    }

    public void Pause()
    {
        if (!estPause)
        {
            switch (RestePause)
            {
                case 2:
                    estPause = true;
                    Reste2.SetActive(true);
                    BoutonPause.SetActive(false);
                    MenuPause.SetActive(true);
                    sam.Attaque();
                    break;
                case 1:
                    estPause = true;
                    Reste1.SetActive(true);
                    BoutonPause.SetActive(false);
                    MenuPause.SetActive(true);
                    sam.Attaque();
                    break;
                case 0:
                    estPause = true;
                    Reste0.SetActive(true);
                    BoutonPause.SetActive(false);
                    MenuPause.SetActive(true);
                    sam.Attaque();
                    break;
            }
            Realisateur.Vent.volume = 0.3f;
            Realisateur.Musique.volume = 0.15f;
        }
        else
        {
            switch (RestePause)
            {
                case 2:
                    BoutonPause.SetActive(true);
                    Reste2.SetActive(false);
                    break;
                case 1:
                    BoutonPause.SetActive(true);
                    Reste1.SetActive(false);
                    break;
                case 0:
                    Reste0.SetActive(false);
                    Score.enabled = false;
                    break;
            }
            RestePause--;
            Realisateur.Vent.volume = 1.0f;
            Realisateur.Musique.volume = 1.0f;
            estPause = false;
            MenuPause.SetActive(false);
            sam.Attaque2();
        }
    }

    public void Quitter()
    {
        SceneManager.LoadScene("EcranAccueil");
    }

    public void Recommencer()
    {
        SceneManager.LoadScene("Jeu");
    }

    public void GameOver()
    {
        NombreMort++;
        PrixVie += NombreMort;
        estPause =true;
        Score.enabled = false;
        PrixTexte.text = "(-" + PrixVie + ")";
        MenuMort.SetActive(true);
        BoutonPause.SetActive(false);
        Realisateur.Vent.volume = 0.3f;
    }

    public void Revivre()
    {
        int VieRestante = PlayerPrefs.GetInt("Revivre");
        if ( VieRestante >= PrixVie)
        {
            PlayerPrefs.SetInt("Revivre", VieRestante - PrixVie);
            int VieDepensee = PlayerPrefs.GetInt("VieDepensee");
            PlayerPrefs.SetInt("VieDepensee", VieDepensee + PrixVie);
            estPause = false;
            Score.enabled = true;
            Realisateur.mobile = false;
            MenuMort.SetActive(false);
            BoutonPause.SetActive(true);
            RestePause = 2;
            Realisateur.Vent.volume = 1.0f;
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, sam.transform.position.y, Camera.main.transform.position.z);
        }
    }

    public void Pub()
    {
        PanneauPub.SetActive(true);

        sam.Attaque();
    }

    public void Non()
    {
        PanneauPub.SetActive(false);

        sam.Attaque2();
    }

    public void Options()
    {
        MenuPause.SetActive(false);
        MenuOptions.SetActive(true);
        sam.Attaque();
    }

    public void RetourOptions()
    {
        MenuPause.SetActive(true);
        MenuOptions.SetActive(false);
        sam.Attaque2();
    }
}
