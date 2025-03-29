using UnityEngine;
using UnityEngine.UI;

public class cameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float boostMultiplier = 2f;
    public float lookSensitivity = 2f;

    public Button inspectorMode;

    private float rotationX = 0f;
    private float rotationY = 0f;
    private bool isInspectorModeActive = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        inspectorMode.onClick.AddListener(ToggleInspectorMode);
    }

    void Update()
    {
        if (!isInspectorModeActive) return;

        HandleMouseLook();
        HandleMovement();
        HandleCursorUnlock();
    }

    void ToggleInspectorMode()
    {
        isInspectorModeActive = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        rotationY += mouseX;

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }

    void HandleMovement()
    {
        float speed = moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? boostMultiplier : 1f);

        Vector3 direction = new Vector3(
            Input.GetAxis("Horizontal"),
            (Input.GetKey(KeyCode.Space) ? 1 : 0) - (Input.GetKey(KeyCode.LeftControl) ? 1 : 0),
            Input.GetAxis("Vertical")
        );

        transform.position += transform.TransformDirection(direction) * speed * Time.deltaTime;
    }

    void HandleCursorUnlock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isInspectorModeActive = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Reset position and rotation
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }
    }
}
