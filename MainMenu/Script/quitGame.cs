using UnityEngine;
using UnityEngine.UI;

public class quitGame : MonoBehaviour
{
    public Button quitButton; // Assign this in the inspector

    void Start()
    {
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(Quit);
        }
    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}