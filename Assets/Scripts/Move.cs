using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private Vector3 direction = Vector3.left;
    void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
    }
}
