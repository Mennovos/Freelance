using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform followTarget;

    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float bottomClamp = -20f;
    [SerializeField] private float topClamp = 70f;

    private float CinemachinetargetPitch = 0f;
}
