using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayedGotoScene : MonoBehaviour
{
    /// <summary>
    /// The name of the scene to transition to after the time has passed.
    /// </summary>
    public string TargetSceneName;

    /// <summary>
    /// The time to wait before transitioning to the target scene.
    /// </summary>
    public float WaitTime;

    /// <summary>
    /// The amount of time that has elapsed.
    /// </summary>
    float _elapsedTime;

    /// <summary>
    /// Whether the scene is transitioning.
    /// </summary>
    bool _isTransitioning;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_isTransitioning)
        {
            // we are transitioning, so we don't need to do anything
            return;
        }

        _elapsedTime += Time.deltaTime;
        if(_elapsedTime >= WaitTime)
        {
            _isTransitioning = true;
            SceneManager.LoadScene(TargetSceneName);
        }
    }
}
