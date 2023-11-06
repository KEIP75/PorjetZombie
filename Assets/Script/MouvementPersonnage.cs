using UnityEngine;

public class MouvementPersonnage : MonoBehaviour
{
    public float vitesseDeplacement = 5f;
    public Camera cam; 

    void Update()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");
        Vector3 deplacement = new Vector3(deplacementHorizontal, 0f, deplacementVertical) * vitesseDeplacement * Time.deltaTime;
        transform.Translate(deplacement);

        Ray rayonCam = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(rayonCam, out hit))
        {
            Vector3 directionRegard = hit.point - transform.position;
            directionRegard.y = 0f;
            Quaternion rotationVersSouris = Quaternion.LookRotation(directionRegard);
            transform.rotation = rotationVersSouris;
        }
    }
}
