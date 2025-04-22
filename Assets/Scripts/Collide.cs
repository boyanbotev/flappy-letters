using UnityEngine;

public class Collide : MonoBehaviour
{
    public static event System.Action<Collider2D> OnPlayerCollision;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPlayerCollision?.Invoke(collision);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnPlayerCollision?.Invoke(collision.collider);
    }
}
