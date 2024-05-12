using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class glowNew : MonoBehaviour
{
    public Material[] glowMaterials; // Materials with emission property for the seven objects
    public float glowIntensityIncrement = 20f; // Incremental increase in glow intensity for each object
    public float glowDuration = 10f; // Duration of glow effect
    public float delayBetweenGlow = 0f; // Delay between each object glowing

    private int currentIndex = 0; // Index of the current object
    private float timer = 0f;
    private bool glowing = false;

    void Start()
    {
        // Ensure all materials start with emission disabled
        foreach (Material material in glowMaterials)
        {
            material.DisableKeyword("_EMISSION");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delayBetweenGlow && currentIndex < glowMaterials.Length && !glowing)
        {
            glowing = true;
            StartCoroutine(ActivateGlow());
        }
    }

    IEnumerator ActivateGlow()
    {
        Material currentMaterial = glowMaterials[currentIndex];
        float currentIntensity = glowIntensityIncrement * currentIndex;

        currentMaterial.EnableKeyword("_EMISSION");

        yield return new WaitForSeconds(glowDuration);

        currentMaterial.DisableKeyword("_EMISSION");
        glowing = false;
        timer = 0f;
        currentIndex++;
    }
}
