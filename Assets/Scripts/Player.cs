using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerMovement playerMovement;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void FixedUpdate()
    {
        if (!playerInput.FollowPressed) return;

        playerMovement.FollowMouse(playerInput.PointerScreenPos);
    }
}
