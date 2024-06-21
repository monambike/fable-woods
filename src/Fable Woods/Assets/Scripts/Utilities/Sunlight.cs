using UnityEngine;

public class Sunlight : MonoBehaviour
{
    /// <summary>
    /// Light responsible for the sunlight.
    /// </summary>
    public Light directionalLight;

    /// <summary>
    /// Length of the day.
    /// </summary>
    public float dayLengthInMinutes = 1.0f; // Duração do ciclo dia/noite em minutos

    /// <summary>
    /// Time of the day.
    /// </summary>
    private float currentTimeOfDay;

    /// <summary>
    /// Time multiplier based on day length.
    /// </summary>
    private float timeMultiplier;

    void Start()
    {
        // Initializing time multiplier.
        timeMultiplier = 24.0f / (dayLengthInMinutes * 60.0f);
    }

    void Update()
    {
        // Recalculating time of the day based on delta time and time multiplier.
        currentTimeOfDay += Time.deltaTime * timeMultiplier;
        if (currentTimeOfDay >= 24.0f) currentTimeOfDay = 0.0f;

        UpdateLighting();
    }
    void UpdateLighting()
    {
        // Converting time of the day for light angle and setting in into the light.
        float angle = (currentTimeOfDay / 24.0f) * 360.0f - 90.0f;
        directionalLight.transform.rotation = Quaternion.Euler(new Vector3(angle, 170, 0));
    }
}
