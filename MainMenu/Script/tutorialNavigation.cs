using UnityEngine;
using UnityEngine.UI;

public class tutorialNavigation : MonoBehaviour
{
    public GameObject[] images; // Array of image GameObjects to navigate
    public Button nextButton;
    public Button prevButton;
    private int currentIndex = 0;

    void Start()
    {
        UpdateImageVisibility();
        UpdateButtonVisibility();

        if (nextButton != null)
            nextButton.onClick.AddListener(NextImage);

        if (prevButton != null)
            prevButton.onClick.AddListener(PrevImage);
    }

    public void NextImage()
    {
        if (images.Length == 0 || currentIndex >= images.Length - 1) return;

        images[currentIndex].SetActive(false);
        currentIndex++;
        images[currentIndex].SetActive(true);
        UpdateButtonVisibility();
    }

    public void PrevImage()
    {
        if (images.Length == 0 || currentIndex <= 0) return;

        images[currentIndex].SetActive(false);
        currentIndex--;
        images[currentIndex].SetActive(true);
        UpdateButtonVisibility();
    }

    private void UpdateImageVisibility()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(i == currentIndex);
        }
    }

    private void UpdateButtonVisibility()
    {
        if (prevButton != null)
            prevButton.gameObject.SetActive(currentIndex > 0);

        if (nextButton != null)
            nextButton.gameObject.SetActive(currentIndex < images.Length - 1);
    }
}