using UnityEngine;

public class Flap : MonoBehaviour
{
    Rigidbody2D rb;
    public float flapForce = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * flapForce;
        }
    }
}
