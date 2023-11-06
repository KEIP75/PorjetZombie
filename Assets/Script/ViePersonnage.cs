using UnityEngine;
using UnityEngine.UI;

public class ViePersonnage : MonoBehaviour
{
    public int vieMaximale = 100;
    private int vieActuelle;

    public Slider barreDeVie; // Barre de vie sur canvas

    void Start()
    {
        vieActuelle = vieMaximale;
        MettreAJourBarreDeVie();
    }

    public void PrendreDesDegats(int degats)
    {
        vieActuelle -= degats;
        vieActuelle = Mathf.Clamp(vieActuelle, 0, vieMaximale); // Vie qui deviens pas négative 
        MettreAJourBarreDeVie();

        if (vieActuelle <= 0)
        {
        }
    }

    void MettreAJourBarreDeVie()
    {
        barreDeVie.value = (float)vieActuelle / vieMaximale;
    }
}
