using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class DropDownScript : MonoBehaviour
{
    public TMP_Dropdown dropdown; // Reference to TMP Dropdown component
    public GameObject heatMap; // Third object to toggle visibility
    public GameObject map;

    void Start()
    {
        // Ensure the dropdown is assigned
        if (dropdown != null)
        {
            dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        }

        // Set default state (both false)
        ResetVisibility();
    }

    void OnDropdownValueChanged(int index)
    {
        // Reset all objects to ensure proper visibility
        ResetVisibility();

        if (index == 1) // HeatMap option
        {
            ShowHeatMap();
        }
        else if (index == 2) // Default map option
        {
            ShowDefault();
        }

    }

    void ResetVisibility()
    {
        if (heatMap != null) heatMap.SetActive(false);
        if (map != null) map.SetActive(true);
    }

    void ShowDefault()
    {
        if (map != null) map.SetActive(true);
        if (heatMap != null) heatMap.SetActive(false);
    }

    void ShowHeatMap()
    {
        if (map != null) map.SetActive(false);
        if (heatMap != null) heatMap.SetActive(true);
    }

}