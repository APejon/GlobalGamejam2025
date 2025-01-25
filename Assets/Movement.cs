using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
        public float moveSpeed = 5f; // Speed of movement

    void Update()
    {
        // Get input from arrow keys or WASD
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down arrow keys

        // For 2D movement, comment out the moveZ line and adjust transform position accordingly.
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ);

        // Move the object
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
