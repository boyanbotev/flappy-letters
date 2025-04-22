using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

enum GameMode
{
    Collect,
    Spelling
}

public class GameManager : MonoBehaviour
{
    [SerializeField] string targetLetter = "s";
    [SerializeField] string targetWord = "sap";
    [SerializeField] GameMode gameMode = GameMode.Collect;
    int letterIndex = 0;
    Progress progress;
    SpellingProgress spellingProgress;

    private void Awake()
    {
        progress = FindFirstObjectByType<Progress>();
        spellingProgress = FindFirstObjectByType<SpellingProgress>();

        if (gameMode == GameMode.Spelling)
        {
            spellingProgress.targetWord = targetWord;
            targetLetter = targetWord[letterIndex].ToString();
        }
    }
    private void OnEnable()
    {
        Collide.OnPlayerCollision += HandlePlayerCollision;
        Progress.OnProgressComplete += GoToNext;
    }

    private void OnDisable()
    {
        Collide.OnPlayerCollision -= HandlePlayerCollision;
        Progress.OnProgressComplete -= GoToNext;
    }

    private void HandlePlayerCollision(Collider2D collision)
    {
        if (!collision.transform.GetComponentInParent<Move>()) return;

        var text = collision.transform.GetComponentInChildren<TextMeshPro>();
        if (text != null)
        {
            if (gameMode == GameMode.Collect)
            {
                HandleCollect(text.text);
            } 
            else
            {
                HandleSpell(text.text);
            }

            Destroy(collision.gameObject);
        } 
        else
        {
            Restart();
        }
    }

    void HandleCollect(string letter)
    {
        if (letter == targetLetter)
        {
            progress.HandleCorrectCollect();
        }
        else
        {
            progress.HandleFalseCollect();
        }
    }

    void HandleSpell(string letter)
    {
        if (letter == targetLetter)
        {
            letterIndex++;
            if (letterIndex >= targetWord.Length)
            {
                GoToNext();
            }
            else
            {
                spellingProgress.UpdateProgress(letter);
                targetLetter = targetWord[letterIndex].ToString();
            }
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

    void GoToNext()
    {
        // if next scene
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            // if no next scene, go to main menu
            SceneManager.LoadScene(0);
        }
    }
}
