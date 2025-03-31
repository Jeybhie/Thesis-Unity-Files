using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro; // Import TextMeshPro namespace


public class directionalView : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public Transform targetObject;

    private List<Vector3> positions = new List<Vector3>()
    {
        new Vector3(100, 801, -982),
        new Vector3(136, 1649, -59),
        new Vector3(100, 801, 887),
        new Vector3(1477, 1091, -48),
        new Vector3(100, 801, -982),
        new Vector3(-1247, 1091, -48)
    };

    private List<Quaternion> rotations = new List<Quaternion>()
    {
        new Quaternion(0.365461707f, 0, 0, 0.930826366f),
        new Quaternion(0.707106829f, 0, 0, 0.707106829f),
        new Quaternion(0, 0.930826366f, -0.365461707f, 0),
        new Quaternion(0.258420438f, -0.658193648f, 0.258420438f, 0.658193648f),
        new Quaternion(0.365461707f, 0, 0, 0.930826366f),
        new Quaternion(0.258420438f, 0.658193648f, -0.258420438f, 0.658193648f)
    };

    void Start()
    {
        if (dropdown != null && targetObject != null)
        {
            dropdown.onValueChanged.AddListener(delegate { UpdateTransform(dropdown.value); });
            InitializeDropdown();
            UpdateTransform(0); // Set default position and rotation
        }
    }

    void InitializeDropdown()
    {
        dropdown.ClearOptions();
        List<string> options = new List<string> { "Default View", "Top-down", "North", "East", "South", "West" };
        dropdown.AddOptions(options);
    }

    void UpdateTransform(int index)
    {
        targetObject.position = positions[index];
        targetObject.rotation = rotations[index];
    }
}
