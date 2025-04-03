using UnityEngine;
using UnityEngine.UI;

public class cameraPan : MonoBehaviour
{
    public float panSpeed = 20f; // Speed of panning movement
    public float zoomSpeed = 850f; // Speed of zooming
    public float rotationSpeed = 15f; // Speed of rotation

    // aton components
    public Slider panSpeedSlider;
    public Slider zoomSpeedSlider;
    public Slider rotationSpeedSlider;
    public Button resetButton;

    private Vector3 lastMousePosition;
    private float defaultPanSpeed = 20f;
    private float defaultZoomSpeed = 500f;
    private float defaultRotationSpeed = 15f;

    void Start()
    {
        // amuni ang value halin sa slider naton 
        panSpeedSlider.value = panSpeed;
        zoomSpeedSlider.value = zoomSpeed;
        rotationSpeedSlider.value = rotationSpeed;

        panSpeedSlider.onValueChanged.AddListener(value => panSpeed = value);
        zoomSpeedSlider.onValueChanged.AddListener(value => zoomSpeed = value);
        rotationSpeedSlider.onValueChanged.AddListener(value => rotationSpeed = value);

        ResetToDefaults();

        resetButton.onClick.AddListener(ResetToDefaults);
    }

    void Update()
    {
        HandleMouseInput();
    }

    void HandleMouseInput()
    {
        // Right Mouse Button - Rotate
        if (Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;

            transform.Rotate(Vector3.up, delta.x * rotationSpeed * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.right, -delta.y * rotationSpeed * Time.deltaTime, Space.Self);
        }

        // Middle Mouse Button - Pan
        if (Input.GetMouseButton(2))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            Vector3 move = new Vector3(-delta.x, -delta.y, 0) * panSpeed * Time.deltaTime;
            transform.Translate(move, Space.Self);
        }

        // Scroll Wheel - Zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.forward * scroll * zoomSpeed, Space.Self);

        lastMousePosition = Input.mousePosition;
    }

    void ResetToDefaults()
    {
        panSpeed = defaultPanSpeed;
        zoomSpeed = defaultZoomSpeed;
        rotationSpeed = defaultRotationSpeed;

        panSpeedSlider.value = defaultPanSpeed;
        zoomSpeedSlider.value = defaultZoomSpeed;
        rotationSpeedSlider.value = defaultRotationSpeed;
    }
}
