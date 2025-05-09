using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform cameraTransform;  // Reference to the camera
    public Vector2 parallaxMultiplier; // Control the parallax effect for X and Y axes

    private Vector3 lastCameraPosition;

    void Start()
    {
        lastCameraPosition = cameraTransform.position;
    }

    void Update()
    {
        Vector3 cameraMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(cameraMovement.x * parallaxMultiplier.x, cameraMovement.y * parallaxMultiplier.y, 0);
        lastCameraPosition = cameraTransform.position;
    }
}