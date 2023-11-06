using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public int degats = 10;
    public Transform Cible; 
    public float vitesseDeplacement = 3f; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ViePersonnage viePersonnage = other.GetComponent<ViePersonnage>();
            if (viePersonnage != null)
            {
                viePersonnage.PrendreDesDegats(degats);
            }
        }
    }
    
    
    void Update()
    {
        if (Cible != null)
        {
            Vector3 direction = Cible.position - transform.position;
            direction.y = 0f; 
            direction.Normalize();

            transform.position += direction * vitesseDeplacement * Time.deltaTime;

            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
