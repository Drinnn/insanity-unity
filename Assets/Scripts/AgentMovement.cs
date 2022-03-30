using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float currentVelocity = 3;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 movementInput)
    {
        _rb.velocity = movementInput.normalized * 3;
    }
}
