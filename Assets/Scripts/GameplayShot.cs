using UnityEngine;

public class GameplayShot : MonoBehaviour
{
    [SerializeField] Transform player1;
    [SerializeField] Transform player2;

    private float minZoom = 1f;        // Minimum zoom level
    private float maxZoom = 50f;        // Maximum zoom level
    private Vector3 offset = new Vector3(0, 10, 0); // Offset for top-down perspective

    private float smoothTime = 0.5f;    // Smooth transition for camera movement
    private Vector3 velocity;          // Internal velocity for smoothing

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void LateUpdate()
    {
        if (player1 == null || player2 == null)
            return;

        // Set the camera position
        Vector3 centerPoint = GetCenterPoint();
        centerPoint = centerPoint + offset;
        // Adjust the camera zoom
        float distance = Vector3.Distance(player1.position, player2.position);
        float normalizedDistance = Mathf.Clamp01((distance - minZoom) / (maxZoom - minZoom));
        float newZoom = Mathf.Lerp(minZoom, maxZoom, normalizedDistance);
        centerPoint = centerPoint + new Vector3(0, newZoom, 0);

        transform.position = Vector3.SmoothDamp(transform.position, centerPoint, ref velocity, smoothTime);

        // Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, newZoom, Time.deltaTime);
    }

    // Get the midpoint between the two players
    private Vector3 GetCenterPoint()
    {
        return (player1.position + player2.position) / 2f;
    }
}
