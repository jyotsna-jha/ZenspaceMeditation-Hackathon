using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

public class EmissionControl : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private Bloom bloomLayer;

    public float startIntensity = 1f;
    public float targetIntensity = 2f;
    public float incrementRate = 0.1f;
    public float delayInterval = 1f;

    private void Start()
    {
        postProcessVolume.profile.TryGetSettings(out bloomLayer);
        bloomLayer.intensity.value = startIntensity;
        StartCoroutine(IncreaseEmissionWithDelay());
    }

    IEnumerator IncreaseEmissionWithDelay()
    {
        while (bloomLayer.intensity.value < targetIntensity)
        {
            bloomLayer.intensity.value += incrementRate;
            yield return new WaitForSeconds(delayInterval);
        }
    }
}
