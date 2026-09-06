using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f; // Vitesse de la caméra.
    public Vector3 offset;

    void LateUpdate() // Méthode pour que la caméra suive le joueur.
    {
        Vector3 desiredPosition = target.position + offset; // On met Vector3 au lieu de 2 pour compter la profondeur car c'est important pour qu'on voit bien le joueur.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

}
