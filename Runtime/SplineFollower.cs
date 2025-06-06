using UnityEngine;
using UnityEngine.Splines;

public class SplineFollower : MonoBehaviour
{
    [Header("Spline Settings")]
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private int splineIndex = 0;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool loop = true;
    [SerializeField] private bool lookForward = true;
    [SerializeField] private float rotationSpeed = 5f;

    private float currentDistance = 0f;
    private float splineLength;
    private bool isMoving = true;

    public float DistanceFromPlayerToStart = 15;

    public Player Player;

    void Start()
    {
        if (splineContainer != null && splineContainer.Splines.Count > splineIndex)
        {
            // Get the length of the spline to know when we've reached the end
            splineLength = splineContainer.CalculateLength(splineIndex);
        }
        else
        {
            Debug.LogError("Spline not assigned or invalid spline index!");
            isMoving = false;
        }

        //transform.position = Vector2.zero;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 1, 0.2f);
        Gizmos.DrawWireSphere(transform.position, DistanceFromPlayerToStart);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,1, 0, 0.2f);
        Gizmos.DrawWireSphere(transform.position, DistanceFromPlayerToStart);
    }

    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, Player.transform.position) > DistanceFromPlayerToStart)
        {
            return;
        }

        if (!isMoving || splineContainer == null)
        {
            return;
        }

        // Increase current distance based on speed
        currentDistance += speed * Time.deltaTime;

        // Handle reaching the end of the spline
        if (currentDistance >= splineLength)
        {
            if (loop)
            {
                // Loop back to the start
                currentDistance %= splineLength;
            }
            else
            {
                // Stop at the end
                currentDistance = splineLength;
                isMoving = false;
            }
        }

        // Convert distance to normalized position (0 to 1)
        float normalizedDistance = currentDistance / splineLength;

        // Get position on the spline
        float3 position = SplineUtility.EvaluatePosition(splineContainer.Splines[splineIndex], normalizedDistance);

        // Optional: Convert position from spline's local space to world space
        transform.position = splineContainer.transform.TransformPoint(new float3(position.x, position.y, position.z));

        // Handle rotation if needed
        if (lookForward)
        {
            // Get the tangent (direction) at the current point
            float3 tangent = SplineUtility.EvaluateTangent(splineContainer.Splines[splineIndex], normalizedDistance);

            if (math.lengthsq(tangent) > 0.001f)
            {
                float angle = math.atan2(tangent.y, tangent.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);

                //Quaternion targetRotation = Quaternion.LookRotation(new Vector3(tangent.x, tangent.y, tangent.z));
                //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    // Utility method to reset the follower to the beginning of the path
    public void ResetToStart()
    {
        currentDistance = 0f;
        isMoving = true;

        // Immediately update position
        if (splineContainer != null && splineContainer.Splines.Count > splineIndex)
        {
            float3 position = SplineUtility.EvaluatePosition(splineContainer.Splines[splineIndex], 0);

            // Optional: Convert position from spline's local space to world space
            transform.position = splineContainer.transform.TransformPoint(new float3(position.x, position.y, position.z));
        }
    }

    // Utility method to set a new spline at runtime
    public void SetSpline(SplineContainer newSplineContainer, int newSplineIndex = 0)
    {
        splineContainer = newSplineContainer;
        splineIndex = newSplineIndex;
        splineLength = splineContainer.CalculateLength(splineIndex);
        ResetToStart();
    }
}
