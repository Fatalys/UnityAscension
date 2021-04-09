using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocherTutoriel : MonoBehaviour
{
    public Sam sam;

    private BoxCollider2D Collisionneur;

    private Vector2 CentreHaut;

    public Evenement evenement;

    // Start is called before the first frame update
    void Start()
    {
        Collisionneur = GetComponent<BoxCollider2D>();
        CentreHaut = new Vector2(Collisionneur.bounds.center[0], Collisionneur.bounds.max[1] + 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (evenement.Identifiant == 2)
        {
            sam.Teleoprtation(CentreHaut);
            evenement.Identifiant++;
            sam.RenduSprite.flipX = true;
            evenement.Dialogues[2].SetActive(false);
            evenement.Dialogues[3].SetActive(true);
            evenement.BoutonSuivant.SetActive(true);
        }
    }
}
