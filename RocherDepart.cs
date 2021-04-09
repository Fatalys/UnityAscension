using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocherDepart : MonoBehaviour
{

    public float Dephasage = 0.0f;

    public float Amplitude = 0.3f;

    public float Periode = 10.0f;

    private Rigidbody2D Corps;
    /*

    public MenuPrincipal menuPrincipal;

    public float TempsMouvement = 3.0f;

    public float vitesse = 3.0f;

    public int direction;
    */

    // Start is called before the first frame update
    void Start()
    {
        Corps = GetComponent<Rigidbody2D>();

        // direction = (int) Mathf.Sign(rigidbody2D.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (menuPrincipal.estMenuJouer && TempsMouvement>0)
        {
            TempsMouvement -= Time.deltaTime;
        }
        */
    }

    // FixedUpdate is called once per time unite
    void FixedUpdate()
    {
        Vector2 position = Corps.position;

        position.y += Amplitude * Mathf.Cos(2 * Mathf.PI * (Time.time + Dephasage) / Periode) * Time.deltaTime;

        Corps.MovePosition(position);

        /*
        if (menuPrincipal.estMenuJouer)
        {
            if (TempsMouvement > 0)
            {
                position.x += vitesse * Time.deltaTime * direction;

                rigidbody2D.MovePosition(position);
            }
        }
        */
    }
}
