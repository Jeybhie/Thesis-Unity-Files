using UnityEngine;
using UnityEngine.UI; // Use Unity's UI namespace for Toggle
using TMPro; // Import TextMeshPro namespace

public class ToggleRain : MonoBehaviour
{
    public Toggle rainToggle;   // Reference to the Unity UI Toggle
    public ParticleSystem rainEffect; // Reference to the Particle System

    void Start()
    {
        // Attach the ToggleRainEffect function to the toggle's value changed event
        rainToggle.onValueChanged.AddListener(ToggleRainEffect);
    }

    void ToggleRainEffect(bool isOn)
    {
        if (isOn)
            rainEffect.Play();   // Start the rain
        else
            rainEffect.Stop();   // Stop the rain
    }
}