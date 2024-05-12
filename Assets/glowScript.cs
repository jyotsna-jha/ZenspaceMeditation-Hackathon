using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowScript : MonoBehaviour
{
    public float maxIntensity = 1f; // Maximum intensity of emission
    public float delay = 1f; // Delay in seconds
    private Renderer rend;
    private Material mat;
    private Color originalColor;
    private float timer = 0f;
    private float intensityTimer = 0f; // Timer for intensity change
    private bool increasing = true;
    private bool intensityIncreased = false; // Flag to track intensity increase

    void Start()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
        originalColor = mat.GetColor("_EmissionColor");
    }

    void Update()
    {
        // Increment or decrement emission intensity based on time
        timer += Time.deltaTime;
        if (!intensityIncreased && timer >= delay)
        {
            timer = 0f;
            intensityIncreased = true;
        }

        if (intensityIncreased)
        {
            intensityTimer += Time.deltaTime;
            if (intensityTimer >= 10f) // Increase intensity for 10 seconds
            {
                intensityTimer = 0f;
                intensityIncreased = false;
                mat.SetColor("_EmissionColor", originalColor); // Revert to original intensity
                return; // Stop the Update loop
            }

            if (increasing)
            {
                mat.SetColor("_EmissionColor", originalColor * maxIntensity);
                increasing = false;
            }
            else
            {
                mat.SetColor("_EmissionColor", originalColor);
                increasing = true;
            }
        }
    }
}
