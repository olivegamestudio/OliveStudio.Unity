using System;
using UnityEngine;

public class FixedToCamera : MonoBehaviour
{
    /// <summary>
    /// The offset from the camera's position.
    /// </summary>
    Vector3 _offset;

    /// <summary>
    /// The camera to which the object is fixed.
    /// </summary>
    public Camera Camera;

    /// <summary>
    /// Start is called before the first frame update.
    /// Initializes the offset based on the initial position.
    /// </summary>
    void Start()
    {
        _offset = transform.position;

        if (Camera == null)
        {
            throw new InvalidOperationException("There is no camera attached.");
        }
    }

    /// <summary>
    /// LateUpdate is called once per frame, after all Update functions have been called.
    /// Updates the position of the object to follow the camera with the specified offset.
    /// </summary>
    void LateUpdate()
    {
        transform.position = new Vector3(
            Camera.transform.position.x + _offset.x,
            Camera.transform.position.y + _offset.y,
            transform.position.z);
    }
}
