using UnityEngine;

public class lightControl : MonoBehaviour
{
    public Material material;             // Material emisivo �nico
    public Color baseEmissionColor = Color.white;
    public float baseIntensity = 10f;    // Intensidad m�xima
    public float blinkAmount = 8f;       // Cu�nto baja la intensidad
    public float blinkSpeed = 2f;        // Velocidad del parpadeo

    void Start()
    {
        if (material == null)
        {
            Debug.LogError("Material no asignado.");
            return;
        }

        material.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        float pulse = Mathf.PingPong(Time.time * blinkSpeed, 1f);
        float currentIntensity = baseIntensity - (blinkAmount * pulse);
        Color emissionColor = baseEmissionColor * baseEmissionColor * currentIntensity;
        material.SetColor("_EmissionColor", emissionColor);
    }
}
