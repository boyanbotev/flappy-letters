using TMPro;
using UnityEngine;

public class SpellingProgress : MonoBehaviour
{
    TextMeshProUGUI text;
    public string targetWord = "sap";

    private void Awake()
    {
        text = this.gameObject.GetComponent<TextMeshProUGUI>();
        text.text = "";
    }


    public void UpdateProgress(string letter)
    {
        text.text += letter;
    }
}
