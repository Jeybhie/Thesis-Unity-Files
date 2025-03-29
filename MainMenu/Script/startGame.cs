using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    public Button nextSceneButton; // Assign this in the inspector

    void Start()
    {
        if (nextSceneButton != null)
        {
            nextSceneButton.onClick.AddListener(LoadNext);
        }
    }

    void LoadNext()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
