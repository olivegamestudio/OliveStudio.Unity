using UnityEngine;

public class CameraRotationLock : MonoBehaviour
{
    /// <summary>
    /// The main camera in the scene.
    /// </summary>
    Camera _camera;

    /// <summary>
    /// Start is called before the first frame update.
    /// Initializes the main camera reference.
    /// </summary>
    void Start()
    {
        _camera = Camera.main;
    }

    /// <summary>
    /// Update is called once per frame.
    /// Locks the rotation of the object to match the camera's rotation.
    /// </summary>
    void Update()
    {
        transform.rotation = _camera.transform.rotation;
    }
}
