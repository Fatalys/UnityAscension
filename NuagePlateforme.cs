using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuagePlateforme : MonoBehaviour
{
    private Tarentino Realisateur;

    private Sam sam;

    private Invocateur invocateur;

    private BoxCollider2D Collisionneur;

    private Vector2 CentreHaut;

    private Vector2 PositionDepart, PositionArrivee;

    private bool BonDepart, BonneArrivee;

    private CapsuleCollider2D ZoneTouche;

    private bool Retourne;

    private int Identifiant;

    // Start is called before the first frame update
    void Awake()
    {
        sam = GameObject.Find("Sam").GetComponent<Sam>();

        Realisateur = GameObject.Find("Realisateur").GetComponent<Tarentino>();

        Collisionneur = GetComponent<BoxCollider2D>();
        CentreHaut = new Vector2(Collisionneur.bounds.center[0], Collisionneur.bounds.max[1] + 0.5f);

        ZoneTouche = GetComponent<CapsuleCollider2D>();

        invocateur = GameObject.Find("Invocateur").GetComponent<Invocateur>();
        Identifiant = invocateur.Identifiant;
        Retourne = invocateur.Retourne;
    }

    // Update is called once per frame
    void Update()
    {
        if (Autorisation() && Identifiant == invocateur.IdentifiantActuel)
        {
            sam.Teleoprtation(CentreHaut);
            invocateur.IdentifiantActuel++;
            Realisateur.mobile = true;
            PlayerPrefs.SetInt("Nuage", PlayerPrefs.GetInt("Nuage") + 1);
            sam.RenduSprite.flipX = Retourne;

        }

        if (Camera.main.transform.position.y - 20f > Collisionneur.transform.position.y)
        {
            Destroy(gameObject);
        }
    }

    private bool Autorisation()
    {
        if (Input.touchCount == 1)
        {
            var touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    // Stockage du point de départ
                    PositionDepart = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                    if (sam.ZoneTouchee.bounds.Contains(PositionDepart))
                    {
                        BonDepart = true;
                    }
                    else
                    {
                        BonDepart = false;
                    }
                    break;
                case TouchPhase.Ended:

                    // Stockage du point de fin
                    PositionArrivee = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                    if (ZoneTouche.bounds.Contains(PositionArrivee))
                    {
                        BonneArrivee = true;
                    }
                    else
                    {
                        BonneArrivee = false;
                    }
                    break;
            }
        }

        if(BonDepart && BonneArrivee)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
