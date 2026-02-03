using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed = 6f;
    public float rotateSpeed = 12f;
    public LayerMask groundMask;

    Rigidbody rb;
    Camera cam;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    public void FollowMouse(Vector2 screenPos)
    {
        if (!cam) return;

        Ray ray = cam.ScreenPointToRay(screenPos);
        if (!Physics.Raycast(ray, out RaycastHit hit, 1000f, groundMask)) return;

        Vector3 target = hit.point;
        target.y = rb.position.y; // khóa Y theo player

        Vector3 dir = target - rb.position;
        if (dir.sqrMagnitude < 0.01f) return;

        // Rotate mượt về phía target
        Quaternion lookRot = Quaternion.LookRotation(dir.normalized, Vector3.up);
        Quaternion newRot = Quaternion.Slerp(rb.rotation, lookRot, rotateSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(newRot);

        // Move tiến về phía trước
        rb.MovePosition(rb.position + rb.transform.forward * moveSpeed * Time.fixedDeltaTime);
    }
}
