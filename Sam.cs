using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sam : MonoBehaviour
{
    private Animator animateur;

    public Tarentino Realisateur;

    public CapsuleCollider2D ZoneTouchee;

    public AudioSource SonDash;

    private Renderer Sprite;

    public SpriteRenderer RenduSprite;

    public ParticleSystem Dash;

    public AudioSource Son;

    public MenuJeu Menujeu;

    public Rigidbody2D Corps;

    // Start is called before the first frame update
    void Start()
    {
        animateur = GetComponent<Animator>();
        ZoneTouchee = GetComponent<CapsuleCollider2D>();

        Corps = GetComponent<Rigidbody2D>();

        Sprite = GetComponent<Renderer>();

        RenduSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Sprite.isVisible && Camera.main.transform.position.y > transform.position.y && Realisateur.mobile && !Menujeu.estPause)
        {
            Menujeu.GameOver();
        }
    }

    public void Attaque()
    {
        animateur.SetTrigger("Attaque");
        Son.Play();
    }

    public void Attaque2()
    {
        animateur.SetTrigger("Attaque2");
        Son.Play();
    }

    public void Mort()
    {
        animateur.SetBool("Mort",true);
    }

    public void Ressusciter()
    {
        animateur.SetBool("Mort", false);
    }

    public void Teleoprtation(Vector2 position)
    {
        //Dash.Play();
        SonDash.Play();
        transform.position = position;
    }

}
