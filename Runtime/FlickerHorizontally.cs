using UnityEngine;

public class FlickerHorizontally : MonoBehaviour
{
    /// <summary>
    /// The base scale of the object.
    /// </summary>
    public Vector3 Scale;

    /// <summary>
    /// The amount by which the scale will flicker.
    /// </summary>
    public float Amount;

    /// <summary>
    /// The speed at which the scale will flicker.
    /// </summary>
    public float Speed;

    /// <summary>
    /// Update is called once per frame.
    /// Adjusts the local scale of the object to create a flickering effect.
    /// </summary>
    void Update()
    {
        transform.localScale = new Vector3(
            Scale.x,
            Scale.y + Mathf.Sin(Time.time * Speed) * Amount,
            Scale.z);
    }
}
