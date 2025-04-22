using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        Collide.OnPlayerCollision += HandlePlayerCollision;
    }

    private void OnDisable()
    {
        Collide.OnPlayerCollision -= HandlePlayerCollision;
    }

    private void HandlePlayerCollision()
    {
        Restart();
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
