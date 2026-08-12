using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f; // vitesse de la camera
    public Vector3 offset;

    void LateUpdate() // methode pour que la camera suive le joueur
    {
        Vector3 desiredPosition = target.position + offset; // on met vectore 3 au lieux de 2 pour compter la profondeur car c'est important pour pour q'on voit bien le joueur
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

}
