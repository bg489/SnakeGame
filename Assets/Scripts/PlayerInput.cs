using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionReference pointAction;   // <Pointer>/position
    public InputActionReference followAction;  // <Mouse>/leftButton hoặc <Pointer>/press

    public bool FollowPressed { get; private set; }
    public Vector2 PointerScreenPos { get; private set; }

    void OnEnable()
    {
        if (pointAction != null) pointAction.action.Enable();
        if (followAction != null) followAction.action.Enable();
    }

    void OnDisable()
    {
        if (pointAction != null) pointAction.action.Disable();
        if (followAction != null) followAction.action.Disable();
    }

    void Update()
    {
        if (followAction == null || pointAction == null) return;

        FollowPressed = followAction.action.IsPressed();
        PointerScreenPos = pointAction.action.ReadValue<Vector2>();
    }
}
