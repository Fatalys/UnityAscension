using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamDepart : MonoBehaviour
{
    private Animator animateur;

    //private Renderer Sprite;

    public AudioSource Son;

    // Start is called before the first frame update
    void Start()
    {
        animateur = GetComponent<Animator>();

        //Sprite = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Faire quelque chose quand il n'est plus à l'écran
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
        animateur.SetBool("Mort", true);
    }

    public void Ressusciter()
    {
        animateur.SetBool("Mort", false);
    }

}

