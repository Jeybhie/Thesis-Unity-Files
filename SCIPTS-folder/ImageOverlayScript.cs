using UnityEngine;
using UnityEngine.UI; // Use Unity's UI namespace for Toggle
using TMPro; // Import TextMeshPro namespace

public class ToggleVisibility : MonoBehaviour
{
    public Toggle visibilityToggle;   // Reference to the Unity UI Toggle
    public GameObject object1;   // First object to toggle visibility
    public GameObject object2;   // Second object to toggle visibility

    void Start()
    {
        // Attach the ToggleVisibilityEffect function to the toggle's value changed event
        visibilityToggle.onValueChanged.AddListener(ToggleVisibilityEffect);
    }

    void ToggleVisibilityEffect(bool isOn)
    {
        if (object1 != null && object2 != null)
        {
            object1.SetActive(isOn);
            object2.SetActive(!isOn); // Ensure only one object is visible at a time
        }
    }
}