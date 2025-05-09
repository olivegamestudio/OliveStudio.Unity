using UnityEngine;

public class CameraZoomIn : MonoBehaviour
{
    public float StartZoom = 1;

    public float EndZoom = 1;

    public float Duration = 1f;

    float _time;

    Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        _time += Time.deltaTime;
        float t = Mathf.Clamp01(_time / Duration);
        _camera.orthographicSize = Mathf.Lerp(StartZoom, EndZoom, t);

        if (_time > Duration)
        {
            enabled = false;
        }
    }
}
