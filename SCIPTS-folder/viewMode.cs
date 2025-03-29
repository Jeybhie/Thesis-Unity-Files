using UnityEngine;
using UnityEngine.UI;

public class viewMode : MonoBehaviour
{
    public Button changeTransformButton; // Assign this in the inspector
    public GameObject targetObject; // Assign the target object in the inspector

    void Start()
    {
        if (changeTransformButton != null)
        {
            changeTransformButton.onClick.AddListener(ChangeTransform);
        }
    }

    void ChangeTransform()
    {
        if (targetObject != null)
        {
            targetObject.transform.position = new Vector3(100, 801, -982);
            targetObject.transform.rotation = new Quaternion(0.365462124f, 0, 0, 0.930826247f);
            targetObject.transform.localScale = new Vector3(25, 25, 25);
        }
    }
}
