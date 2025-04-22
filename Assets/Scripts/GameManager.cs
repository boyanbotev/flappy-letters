using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] string targetLetter = "s";
    Progress progress;

    private void Awake()
    {
        progress = FindFirstObjectByType<Progress>();
    }
    private void OnEnable()
    {
        Collide.OnPlayerCollision += HandlePlayerCollision;
    }

    private void OnDisable()
    {
        Collide.OnPlayerCollision -= HandlePlayerCollision;
    }

    private void HandlePlayerCollision(Collider2D collision)
    {
        if (!collision.transform.GetComponentInParent<Move>()) return;

        var text = collision.transform.GetComponentInChildren<TextMeshPro>();
        if (text != null)
        {
            string letter = text.text;

            if (letter == targetLetter)
            {
                progress.HandleCorrectCollect();
            }
            else
            {
                progress.HandleFalseCollect();
            }

            Destroy(collision.gameObject);
        } 
        else
        {
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
