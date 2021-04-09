using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Statistiques : MonoBehaviour
{
    public TextMeshProUGUI Generales, Classiques, Nuage, Rocher;

    private int PartieNormal, PartieNuage, PartieRocher, VieDepensee, PlateformeRocher, PlateformeNuage, PlateformeRocherNoir;

    // Start is called before the first frame update
    void Awake()
    {
        Generales = Generales.GetComponent<TextMeshProUGUI>();
        Classiques = Classiques.GetComponent<TextMeshProUGUI>();
        Nuage = Nuage.GetComponent<TextMeshProUGUI>();
        Rocher = Rocher.GetComponent<TextMeshProUGUI>();

        PartieNormal = PlayerPrefs.GetInt("PartieNormale");
        PartieNuage = PlayerPrefs.GetInt("PartieNuage");
        PartieRocher = PlayerPrefs.GetInt("PartiePlateforme");

        int PartieTotal = PartieNormal + PartieNuage + PartieRocher;

        VieDepensee = PlayerPrefs.GetInt("VieDepensee");

        PlateformeRocher = PlayerPrefs.GetInt("Rocher");
        PlateformeNuage = PlayerPrefs.GetInt("Nuage");
        PlateformeRocherNoir = PlayerPrefs.GetInt("RocherNoir");

        int Escalade = PlateformeNuage + PlateformeRocherNoir + PlateformeRocher;

        Generales.text = " " + PartieTotal + "\n " + VieDepensee + "\n " + Escalade + "\n " + PlateformeRocher + "\n " + PlateformeRocherNoir + "\n " + PlateformeNuage;

        Classiques.text = " " + PartieNormal + "\n " + PlayerPrefs.GetInt("MeilleurNormal") + "\n " + PlayerPrefs.GetInt("MeilleurNormalSansVie");

        Nuage.text = " " + PartieNuage + "\n " + PlayerPrefs.GetInt("MeilleurNuage") + "\n " + PlayerPrefs.GetInt("MeilleurNuageSansVie");

        Rocher.text = " " + PartieRocher + "\n " + PlayerPrefs.GetInt("MeilleurPlateforme") + "\n " + PlayerPrefs.GetInt("MeilleurPlateformeSansVie");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
