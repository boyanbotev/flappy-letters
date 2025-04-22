using UnityEngine;

public class Collide : MonoBehaviour
{
    public static event System.Action OnPlayerCollision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponentInParent<Move>())
        {
            OnPlayerCollision?.Invoke();
        }
    }
}
