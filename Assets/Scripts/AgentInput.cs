using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour
{
    private Camera mainCamera;

    [field: SerializeField] public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
    [field: SerializeField] public UnityEvent<Vector2> OnPointerPositionChanged { get; set; }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
    }

    private void GetMovementInput()
    {
        OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    private void GetPointerInput()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;

        var pointerInWorldSpace = mainCamera.ScreenToWorldPoint(mousePosition);
        OnPointerPositionChanged?.Invoke(pointerInWorldSpace);
    }
}
