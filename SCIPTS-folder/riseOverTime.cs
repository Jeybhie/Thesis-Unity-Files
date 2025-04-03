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
    public TMP_Text simulatedTimeText; // display di later on and simulated time 
    public TMP_Text floodHeightText;   // display di karon ang flood height

    public float minY = 0f;
    public float maxY = 10f;

    private Vector3 startPosition;  // preliminary position sang aton flood which has 3 default values the x, y, and z axis of that 3D object
    private Vector3 targetPosition; // ang target position sang simulation after masolve ang predicted flood height naton
    private float metersPerHour;
    private float durationInHours;
    private Coroutine floodCoroutine; // sa unity ni sa nagamit same as like an async ah for resuming and pausing without blocking the main game loop
    private float simulationSpeed = 2f; // as the name suggests it doubles the simulation speed para mas dasig tulukon

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
        // halin ni sa sa aton input fields, we are parsing the data
        metersPerHour = float.TryParse(metersPerHourInput.text, out float mph) ? mph : 1f;
        durationInHours = float.TryParse(durationInput.text, out float dur) ? dur : 1f;


        // the formula to our predicted flood height
        float riseHeight = metersPerHour * durationInHours;

        // calculated target position sang 3D object nga flood based sa iban na variables
        targetPosition = startPosition + new Vector3(0, riseHeight, 0);


        if (floodCoroutine != null) StopCoroutine(floodCoroutine);// kung di null that means ga run na so i stop na for a new simulation
        floodCoroutine = StartCoroutine(RiseFlood(durationInHours * simulationSpeed));// start the simulation
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

            // Update kag display UI text
            simulatedTimeText.text = $"Elapsed Time: {elapsedSimulatedTime:F2} hrs";
            floodHeightText.text = $"Flood Height: {currentHeight:F2}m";

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        // only the final values are displayed
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
