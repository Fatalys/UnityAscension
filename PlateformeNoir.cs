using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeNoir : MonoBehaviour
{
    public float TempsCouleur = 1.0f;

    private Tarentino Realisateur;

    private Sam sam;

    private Invocateur invocateur;

    private bool ChangeCouleur;

    public AudioSource FeuDartifice;

    private SpriteRenderer Sprite;

    private ParticleSystem Pariticules;

    public ParticleSystem Ombre;

    private BoxCollider2D Collisionneur;

    private bool Retourne;

    private Vector2 CentreHaut;

    private int Identifiant;

    private float compteur = 0.0f;

    void Awake()
    {
        Realisateur = GameObject.Find("Realisateur").GetComponent<Tarentino>();

        sam = GameObject.Find("Sam").GetComponent<Sam>();

        invocateur = GameObject.Find("Invocateur").GetComponent<Invocateur>();
        Identifiant = invocateur.Identifiant;
        Retourne = invocateur.Retourne;

        Sprite = GetComponent<SpriteRenderer>();

        Pariticules = GetComponent<ParticleSystem>();

        Collisionneur = GetComponent<BoxCollider2D>();

        CentreHaut = new Vector2(Collisionneur.bounds.center[0], Collisionneur.bounds.max[1] + 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeCouleur && compteur < TempsCouleur)
        {
            compteur += Time.deltaTime / TempsCouleur;
            Sprite.color = Color.Lerp(Color.black, Color.white, compteur);
        }

        if (Camera.main.transform.position.y - 20f > Collisionneur.transform.position.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (ChangeCouleur && Identifiant == invocateur.IdentifiantActuel)
        {
            sam.Teleoprtation(CentreHaut);
            invocateur.IdentifiantActuel++;
            Realisateur.mobile = true;
            PlayerPrefs.SetInt("RocherNoir", PlayerPrefs.GetInt("RocherNoir") + 1);
            sam.RenduSprite.flipX = Retourne;
        }
        if(!ChangeCouleur)
        {
            if (PlayerPrefs.GetInt("EffetsSon") % 2 == 0)
            {
                FeuDartifice.Play();
            }
            ChangeCouleur = true;
            Pariticules.Play();
            Ombre.Stop();
        }
    }
}
