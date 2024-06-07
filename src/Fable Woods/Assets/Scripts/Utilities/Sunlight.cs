using UnityEngine;

public class Sunlight : MonoBehaviour
{
    public Light directionalLight;

    public float dayLengthInMinutes = 1.0f; // Duração do ciclo dia/noite em minutos

    private float timeOfDay;

    private float timeMultiplier;

    void Start()
    {
        timeMultiplier = 24.0f / (dayLengthInMinutes * 60.0f); // Converte para um ciclo de 24 horas
    }

    void Update()
    {
        timeOfDay += Time.deltaTime * timeMultiplier;
        if (timeOfDay >= 24.0f)
        {
            timeOfDay = 0.0f;
        }

        UpdateLighting();
    }
    void UpdateLighting()
    {
        float angle = (timeOfDay / 24.0f) * 360.0f - 90.0f; // Converte o tempo do dia para um ângulo
        directionalLight.transform.rotation = Quaternion.Euler(new Vector3(angle, 170, 0));
    }
}
