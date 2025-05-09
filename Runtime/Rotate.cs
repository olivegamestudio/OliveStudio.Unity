using UnityEngine;

public class Rotate : MonoBehaviour
{
    /// <summary>
    /// The speed of rotation.
    /// </summary>
    public float Speed = 1.0f;

    /// <summary>
    /// The axis around which the object will rotate.
    /// </summary>
    public Vector3 Axis = Vector3.up;

    /// <summary>
    /// Update is called once per frame.
    /// Rotates the object around the specified axis at the specified speed.
    /// </summary>
    void Update()
    {
        gameObject.transform.Rotate(Axis, Speed * Time.deltaTime);
    }
}
