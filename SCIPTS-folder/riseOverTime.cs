using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class riseOverTime : MonoBehaviour
{
    [Header("Flood Settings")]
    public TMP_InputField metersPerHourInput;
    public TMP_InputField durationInput;
    public Slider slider;
    public Button startButton;
    public Button resetButton;

    [Header("Simulation Output")]
    public TMP_Text simulatedTimeText; // Shows simulated time
    public TMP_Text floodHeightText;   // Shows flood height

    public float minY = 0f;
    public float maxY = 10f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float metersPerHour;
    private float durationInHours;
    private Coroutine floodCoroutine;
    private float simulationSpeed = 2f; // Adjusted speed to simulate 10 hours in 5 seconds

    void Start()
    {
        startPosition = transform.position;

        startButton.onClick.AddListener(StartSimulation);
        resetButton.onClick.AddListener(ResetFlood);

        // Initialize text outputs
        simulatedTimeText.text = "Elapsed Time: 0 hrs";
        floodHeightText.text = "Flood Height: 0m";
    }

    void StartSimulation()
    {
        metersPerHour = float.TryParse(metersPerHourInput.text, out float mph) ? mph : 1f;
        durationInHours = float.TryParse(durationInput.text, out float dur) ? dur : 1f;


        float riseHeight = metersPerHour * durationInHours;
        targetPosition = startPosition + new Vector3(0, riseHeight, 0);

        if (floodCoroutine != null) StopCoroutine(floodCoroutine);
        floodCoroutine = StartCoroutine(RiseFlood(durationInHours * simulationSpeed));
    }

    IEnumerator RiseFlood(float riseDuration)
    {
        float elapsedSimulatedTime = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < riseDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / riseDuration);

            elapsedSimulatedTime = (elapsedTime / riseDuration) * durationInHours; // Calculate simulated time
            float currentHeight = Mathf.Lerp(0, metersPerHour * durationInHours, elapsedTime / riseDuration);

            // Update UI text
            simulatedTimeText.text = $"Elapsed Time: {elapsedSimulatedTime:F2} hrs";
            floodHeightText.text = $"Flood Height: {currentHeight:F2}m";

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        // Ensure final values are displayed
        simulatedTimeText.text = $"Elapsed Time: {durationInHours:F2} hrs";
        floodHeightText.text = $"Flood Height: {metersPerHour * durationInHours:F2}m";
    }

    void ResetFlood()
    {
        if (floodCoroutine != null) StopCoroutine(floodCoroutine);

        slider.value = slider.minValue;

        transform.position = startPosition;

        // Reset UI
        simulatedTimeText.text = "Elapsed Time: 0 hrs";
        floodHeightText.text = "Flood Height: 0m";
    }
}
