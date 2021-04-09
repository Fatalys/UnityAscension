using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject Accueil;

    public GameObject MenuJouer;

    public GameObject MenuPlus;

    public GameObject PanneauMot, StatistiquesMenu, PanneauOptions, PanneauPub, PanneauCredit, PanneauTexteCredit;

    public TextMeshProUGUI VieRestante;

    public TextMeshProUGUI Merci, Identifiant;

    public Image Unitylogo;

    public bool estMenuJouer;

    public bool estMenuPlus;

    public bool estPanneauMot;

    public bool estCredit;

    public float TempsCouleur = 1.0f;

    private float compteur = 0.0f;

    private float compteur2 = 0.0f;

    private float compteur3 = 0.0f;

    private float compteur4 = 0.0f;

    public SamDepart sam;

    public Image CouleurCredit;

    public string gameId = "3762633";
    public string placementId = "bannerPlacement";
    public bool testMode = false;


    /*

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementId);
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("PremiereFois") != 1)
        {
            PlayerPrefs.SetInt("Identifiant", Random.Range(0, 4095));
            PlayerPrefs.SetInt("PremiereFois", 1);
            PlayerPrefs.SetInt("Revivre", 30);
            if ( PlayerPrefs.GetInt("Identifiant") == 2 )
            {
                PlayerPrefs.SetInt("Revivre", 500);
            }
            if (PlayerPrefs.GetInt("Identifiant") == 3)
            {
                PlayerPrefs.SetInt("Revivre", 200);
            }
            if (PlayerPrefs.GetInt("Identifiant") == 0)
            {
                PlayerPrefs.SetInt("Revivre", 0);
            }
            if (PlayerPrefs.GetInt("Identifiant") == 1)
            {
                PlayerPrefs.SetInt("Revivre", 100);
            }
            PlayerPrefs.SetInt("Rocher", 0);
            PlayerPrefs.SetInt("RocherNoir", 0);
            PlayerPrefs.SetInt("Nuage", 0);
            PlayerPrefs.SetInt("Publicite", 0);
        }

        VieRestante = VieRestante.GetComponent<TextMeshProUGUI>();

        CouleurCredit = PanneauCredit.GetComponent<Image>();

        Identifiant = Identifiant.GetComponent<TextMeshProUGUI>();

        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenInitialized());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);

    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        if (PlayerPrefs.GetInt("Publicite") % 2 == 1)
        {
            sam.Mort();
            Advertisement.Banner.Hide();
        }
        if (PlayerPrefs.GetInt("Publicite") % 2 == 0)
        {
            Advertisement.Banner.Show();
        }
    }

    // Update is called once per frame
    void Update()
    {
        VieRestante.text = PlayerPrefs.GetInt("Revivre") + "";

        Identifiant.text = PlayerPrefs.GetInt("Identifiant") + "";

        if (estCredit && compteur < TempsCouleur)
        {
            compteur += Time.deltaTime / TempsCouleur;
            CouleurCredit.color = Color.Lerp(new Color(0, 0, 0,0), new Color(0, 0, 0, 1), compteur);
        }

        if ( compteur >= TempsCouleur )
        {
            compteur3 += Time.deltaTime / TempsCouleur;
            PanneauTexteCredit.transform.Translate(0, 50.0f * Time.deltaTime * Screen.height / 800, 0);
        }
        if(compteur3 >= 24)
        {
            if ( PlayerPrefs.GetInt("CreditVu") != 1 )
            {
                PlayerPrefs.SetInt("Revivre", PlayerPrefs.GetInt("Revivre") + 10);
                PlayerPrefs.SetInt("CreditVu", 1);
            }
            compteur2 += Time.deltaTime / TempsCouleur;
            Merci.color = Color.Lerp(new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), compteur2);
            if (compteur3 >= 30)
            {
                compteur4 += Time.deltaTime / 10;
                Identifiant.color = Color.Lerp(new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), compteur4);
            }
        }
    }

    public void Jouer()
    {
        estMenuJouer = true;

        Accueil.SetActive(false);

        MenuJouer.SetActive(true);

        sam.Attaque();
    }

    public void Plus()
    {
        estMenuPlus = true;

        Accueil.SetActive(false);

        MenuPlus.SetActive(true);

        sam.Attaque2();
    }

    public void MotduDev()
    {
        estPanneauMot = true;

        MenuPlus.SetActive(false);

        PanneauMot.SetActive(true);

        sam.Attaque();
    }

    public void Statistiques()
    {
        MenuPlus.SetActive(false);

        StatistiquesMenu.SetActive(true);

        sam.Attaque();
    }

    public void Options()
    {
        MenuPlus.SetActive(false);

        PanneauOptions.SetActive(true);

        sam.Attaque();
    }

    public void Credit()
    {
        MenuPlus.SetActive(false);

        PanneauCredit.SetActive(true);

        PanneauTexteCredit.SetActive(true);

        PanneauTexteCredit.GetComponent<RectTransform>().localPosition = new Vector3 (0, - 800 * Screen.height / Screen.width);

        Advertisement.Banner.Hide();

        estCredit = true;
    }

    public void RetourStat()
    {
        MenuPlus.SetActive(true);

        StatistiquesMenu.SetActive(false);

        sam.Attaque2();
    }

    public void RetourCredit()
    {
        MenuPlus.SetActive(true);

        PanneauCredit.SetActive(false);

        PanneauTexteCredit.SetActive(false);

        compteur = 0;
        compteur2 = 0;
        compteur3 = 0;
        Merci.color = new Color(1, 1, 1, 0);

        estCredit = false;

        if (PlayerPrefs.GetInt("Publicite") % 2 == 0)
        {
            Advertisement.Banner.Show();
        }
    }


    public void RetourJouer()
    {
        estMenuJouer = false;

        Accueil.SetActive(true);

        MenuJouer.SetActive(false);

        sam.Attaque2();
    }

    public void RetourPlus()
    {
        estMenuPlus = false;

        Accueil.SetActive(true);

        MenuPlus.SetActive(false);

        sam.Attaque();
    }

    public void RetourMot()
    {
        estPanneauMot = false;

        MenuPlus.SetActive(true);

        PanneauMot.SetActive(false);

        sam.Attaque2();
    }

    public void RetourOption()
    {
        MenuPlus.SetActive(true);

        PanneauOptions.SetActive(false);

        sam.Attaque2();
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

    public void Classique()
    {
        Advertisement.Banner.Hide();
        GameValues.Difficulte = GameValues.Difficultes.normal;
        SceneManager.LoadScene("Jeu");
    }

    public void Tutoriel()
    {
        SceneManager.LoadScene("Tutoriel");
    }

    public void Rocher()
    {
        Advertisement.Banner.Hide();
        GameValues.Difficulte = GameValues.Difficultes.plateforme;
        SceneManager.LoadScene("Jeu");
    }

    public void Nuage()
    {
        Advertisement.Banner.Hide();
        GameValues.Difficulte = GameValues.Difficultes.nuage;
        SceneManager.LoadScene("Jeu");
    }

}
