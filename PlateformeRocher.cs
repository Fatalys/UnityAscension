using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeRocher : MonoBehaviour
{
    private Tarentino Realisateur;

    private Sam sam;

    private Invocateur invocateur;

    private BoxCollider2D Collisionneur;

    private Vector2 CentreHaut;

    private int Identifiant;

    private bool Retourne;

    void Awake()
    {
        sam = GameObject.Find("Sam").GetComponent<Sam>();

        Realisateur = GameObject.Find("Realisateur").GetComponent<Tarentino>();

        invocateur = GameObject.Find("Invocateur").GetComponent<Invocateur>();
        Identifiant = invocateur.Identifiant;

        Retourne = invocateur.Retourne;

        Collisionneur = GetComponent<BoxCollider2D>();
        CentreHaut = new Vector2(Collisionneur.bounds.center[0], Collisionneur.bounds.max[1] + 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.y - 20f > Collisionneur.transform.position.y)
        {
            Destroy(gameObject); 
        }
    }

    private void OnMouseDown()
    {
        if (Identifiant == invocateur.IdentifiantActuel)
        {
            sam.Teleoprtation(CentreHaut);
            invocateur.IdentifiantActuel++;
            Realisateur.mobile = true;
            PlayerPrefs.SetInt("Rocher", PlayerPrefs.GetInt("Rocher") + 1);
            sam.RenduSprite.flipX = Retourne;
        }
    }
}
