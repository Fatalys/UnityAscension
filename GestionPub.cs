using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GestionPub : MonoBehaviour
{

    public Text Deception;
    public SamDepart Sam;
    public Toggle Publicite;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Publicite") % 2 == 1)
        {
            Publicite.SetIsOnWithoutNotify(false);
        }
        else
        {
            Publicite.SetIsOnWithoutNotify(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PubliciteActif()
    {
        PlayerPrefs.SetInt("Publicite", PlayerPrefs.GetInt("Publicite") + 1);
        if ( PlayerPrefs.GetInt("Publicite") % 2 == 1)
        {
            Sam.Mort();
            Deception.text = "Tu étais l’élu, c’était toi ! Tu devais rétablir la paix dans la pub pas la condamner à la nuit !";
            Advertisement.Banner.Hide();
        }
        if (PlayerPrefs.GetInt("Publicite") % 2 == 0)
        {
            Sam.Ressusciter();
            Advertisement.Banner.Show();
            Deception.text = "Un choix judicieux tu as fais. \n\n Ainsi la pub, grâce à toi renaît.";
        }
    }

}
