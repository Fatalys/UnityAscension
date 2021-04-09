using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuageTuto : MonoBehaviour
{
    public Sam sam;

    public Evenement evenement;

    private BoxCollider2D Collisionneur;

    private Vector2 CentreHaut;

    private Vector2 PositionDepart, PositionArrivee;

    private bool BonDepart, BonneArrivee;

    private CircleCollider2D ZoneTouche;

    // Start is called before the first frame update
    void Awake()
    {
        Collisionneur = GetComponent<BoxCollider2D>();
        CentreHaut = new Vector2(Collisionneur.bounds.center[0], Collisionneur.bounds.max[1] + 0.5f);

        ZoneTouche = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Autorisation() && evenement.Identifiant == 6)
        {
            sam.Teleoprtation(CentreHaut);
            evenement.Identifiant++;
            evenement.Dialogues[6].SetActive(false);
            if (evenement.dejafait == 0)
            {
                evenement.Dialogues[7].SetActive(true);
            }
            else if (evenement.dejafait < 10)
            {
                evenement.Dialogues[12].SetActive(true);
            }
            else
            {
                evenement.Dialogues[14].SetActive(true);
            }
            evenement.BoutonSuivant.SetActive(true);
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

        if (BonDepart && BonneArrivee)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
