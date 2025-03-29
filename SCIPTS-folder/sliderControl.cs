using UnityEngine;
using UnityEngine.UI;

public class sliderControl : MonoBehaviour
{
    public Slider yAxisSlider;   // Assign your UI Slider in the Inspector
    public float minY = 0f;      // Minimum Y position
    public float maxY = 10f;     // Maximum Y position

    private Vector3 startPosition;

    void Start()
    {
        if (yAxisSlider == null)
        {
            return;
        }

        // Store the initial position
        startPosition = transform.position;

        // Set initial position based on slider value
        UpdateYPosition(yAxisSlider.value);

        // Listen for slider value changes
        yAxisSlider.onValueChanged.AddListener(UpdateYPosition);
    }

    void UpdateYPosition(float value)
    {
        float newY = Mathf.Lerp(minY, maxY, value);
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
