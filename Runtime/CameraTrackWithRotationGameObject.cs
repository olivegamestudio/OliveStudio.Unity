using System;
using UnityEngine;

public class CameraTrackWithRotationGameObject : MonoBehaviour
{
    /// <summary>
    /// The game object that the camera will track and rotate with.
    /// </summary>
    public GameObject TrackObject;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        if (TrackObject == null)
        {
            throw new InvalidOperationException("There is no GameObject attached.");
        }
    }

    /// <summary>
    /// Update is called once per frame.
    /// Updates the camera's position and rotation to match the target's position and rotation with an offset.
    /// </summary>
    void Update()
    {
        // Update the camera's position to match the target's position with an offset
        Quaternion z = Quaternion.Lerp(transform.rotation, TrackObject.transform.rotation, 0.01f);
        transform.rotation = z;

        transform.position = new Vector3(TrackObject.transform.position.x, TrackObject.transform.position.y, transform.position.z);
    }
}
