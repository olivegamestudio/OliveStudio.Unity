using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoSceneOnClick : MonoBehaviour
{
    /// <summary>
    /// The name of the scene to transition to after the time has passed.
    /// </summary>
    public string TargetSceneName;

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
    }

    public void OnClick()
    {
        if (_isTransitioning)
        {
            return;
        }

        _isTransitioning = true;
        SceneManager.LoadScene(TargetSceneName);
    }
}
