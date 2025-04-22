using TMPro;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public static event System.Action OnProgressComplete;
    public int progress = 0;
    public int maxProgress = 10;
    TextMeshProUGUI text;

    public void HandleCorrectCollect()
    {
        progress++;
        Debug.Log($"Progress: {progress}/{maxProgress}");
        UpdateProgress();

        if (progress >= maxProgress)
        {
            Debug.Log("Progress complete!");
            OnProgressComplete?.Invoke();
        }
    }

    public void HandleFalseCollect()
    {
        progress--;
        if (progress < 0)
        {
            progress = 0;
        }
        UpdateProgress();
        Debug.Log($"Progress: {progress}/{maxProgress}");
    }

    private void Awake()
    {
        text = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateProgress();
    }

    private void UpdateProgress()
    {
        text.text = $"Progress: {progress}/{maxProgress}";
    }
}