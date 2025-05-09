using UnityEngine;
using UnityEngine.UI;

public class ImageColorLerp : MonoBehaviour
{
    /// <summary>
    /// The starting color of the image.
    /// </summary>
    public Color StartingColor = Color.white;

    /// <summary>
    /// The ending color of the image.
    /// </summary>
    public Color EndingColor = Color.white;

    /// <summary>
    /// The duration of the color transition.
    /// </summary>
    public float Duration;

    /// <summary>
    /// The image to change the color of.
    /// </summary>
    Image _image;

    /// <summary>
    /// The amount of time that has elapsed.
    /// </summary>
    float _elapsedTime;

    /// <summary>
    /// Whether the transition has completed.
    /// </summary>
    bool _hasCompleted;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get the image component
        _image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_hasCompleted)
        {
            // we have completed the transition, so we don't need to do anything
            return;
        }

        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= Duration)
        {
            // we have completed the transition
            _elapsedTime = Duration;
            _hasCompleted = true;           
        }

        // update the color of the image
        _image.color = Color.Lerp(StartingColor, EndingColor, _elapsedTime / Duration);
    }
}
