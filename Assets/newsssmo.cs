using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newsssmo : MonoBehaviour
{
    // Movement variables
    public float maxHeight = 0.05f; // Maximum height of the breathing motion
    public float minHeight = -0.05f; // Minimum height of the breathing motion
    public float speed = 0.25f; // Speed of the breathing motion

    private float originalY; // Original Y position of the GameObject

    // Start is called before the first frame update
    void Start()
    {
        originalY = transform.position.y; // Store the original Y position
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new Y position using a sine wave to create a breathing effect
        float newY = originalY + Mathf.Sin(Time.time * speed) * (maxHeight - minHeight) * 0.5f;
        
        // Apply the new Y position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
