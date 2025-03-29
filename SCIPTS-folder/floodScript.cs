using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FloodScript : MonoBehaviour
{
    [Header("Flood Settings")]
    public InputField metersPerHourInput; // Input field for meters per hour
    public InputField durationInput;      // Input field for duration (hours)
    public Button startButton;            // Button to start simulation
    public Button resetButton;            // Button to reset simulation

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float metersPerHour;
    private float durationInHours;
    private Coroutine floodCoroutine;

    void Start()
    {
        // Store initial position
        startPosition = transform.position;

        // Add button listeners
        startButton.onClick.AddListener(StartSimulation);
        resetButton.onClick.AddListener(ResetFlood);
    }

    void StartSimulation()
    {
        // Parse input values (default to 1 if empty)
        metersPerHour = float.TryParse(metersPerHourInput.text, out float mph) ? mph : 1f;
        durationInHours = float.TryParse(durationInput.text, out float dur) ? dur : 1f;

        // Calculate total rise height and target position
        float riseHeight = metersPerHour * durationInHours;
        targetPosition = startPosition + new Vector3(0, riseHeight, 0);

        // Stop previous coroutine if it's running
        if (floodCoroutine != null) StopCoroutine(floodCoroutine);
        floodCoroutine = StartCoroutine(RiseFlood(durationInHours * 3600f)); // Convert hours to seconds
    }

    IEnumerator RiseFlood(float riseDuration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < riseDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / riseDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition; // Ensure it reaches exact target height
    }

    void ResetFlood()
    {
        // Stop flood coroutine if running
        if (floodCoroutine != null) StopCoroutine(floodCoroutine);

        // Reset position to initial state
        transform.position = startPosition;
    }
}
