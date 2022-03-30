using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D _rb;


    [field: SerializeField] public MovementDataSO MovementData { get; set; }

    [SerializeField] private float currentVelocity = 3;


    private Vector2 movementDirection;

    [field: SerializeField] public UnityEvent<float> OnVelocityChange { get; set; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            movementDirection = movementInput.normalized;
        }
        currentVelocity = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            currentVelocity += MovementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= MovementData.deacceleration * Time.deltaTime;
        }

        return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentVelocity);
        _rb.velocity = currentVelocity * movementDirection.normalized;
    }
}
