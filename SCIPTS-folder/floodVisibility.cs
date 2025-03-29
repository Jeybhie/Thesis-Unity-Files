using UnityEngine;
using UnityEngine.UI; // Use Unity's UI namespace for Toggle
using TMPro; // Import TextMeshPro namespace

public class floodVisibility : MonoBehaviour
{
    public Toggle visibilityToggle;   // Reference to the Unity UI Toggle
    public GameObject targetObject;   // Object to toggle visibility

    void Start()
    {
        // Attach the ToggleVisibilityEffect function to the toggle's value changed event
        visibilityToggle.onValueChanged.AddListener(ToggleVisibilityEffect);
    }

    void ToggleVisibilityEffect(bool isOn)
    {
        if (targetObject != null)
        {
            targetObject.SetActive(isOn); // Toggle the object's visibility
        }
    }
}