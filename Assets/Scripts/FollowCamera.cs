using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // Kamera kuzatadigan ob'ekt
    public Vector3 offset; // Kamera va ob'ekt orasidagi oraliq
    public float smoothSpeed = 0.125f; // Kameraning harakatlanish tezligi

    void LateUpdate()
    {
        // Kerakli pozitsiyani hisoblash
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        // Kameraning hozirgi pozitsiyasini tekislagan holda hisoblash
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Kamerani ob'ektga qaratish
        transform.LookAt(target);
    }
}
