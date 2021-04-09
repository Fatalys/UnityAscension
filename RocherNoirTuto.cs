using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocherNoirTuto : MonoBehaviour
{
    public Sam sam;

    public float TempsCouleur = 1.0f;

    private bool ChangeCouleur;

    public AudioSource FeuDartifice;

    private SpriteRenderer Sprite;

    private ParticleSystem Pariticules;

    public ParticleSystem Ombre;

    private BoxCollider2D Collisionneur;

    private Vector2 CentreHaut;

    private float compteur = 0.0f;

    public Evenement evenement;

    // Start is called before the first frame update
    void Start()
    {
        Collisionneur = GetComponent<BoxCollider2D>();
        CentreHaut = new Vector2(Collisionneur.bounds.center[0], Collisionneur.bounds.max[1] + 0.1f);

        Sprite = GetComponent<SpriteRenderer>();

        Pariticules = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeCouleur && compteur < TempsCouleur)
        {
            compteur += Time.deltaTime / TempsCouleur;
            Sprite.color = Color.Lerp(Color.black, Color.white, compteur);
        }
    }

    private void OnMouseDown()
    {
        if (ChangeCouleur && evenement.Identifiant == 4)
        {
            sam.Teleoprtation(CentreHaut);
            evenement.Identifiant++;
            sam.RenduSprite.flipX = false;
            evenement.Dialogues[4].SetActive(false);
            evenement.Dialogues[5].SetActive(true);
            evenement.BoutonSuivant.SetActive(true);
        }
        if (!ChangeCouleur)
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
