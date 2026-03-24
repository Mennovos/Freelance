using UnityEngine;

public class Grapple : MonoBehaviour
{
     LayerMask grappleLayerMask;
    [SerializeField] private Transform Grapplepoint;
    private float q = 0.0f;
    private void Start()
    {
        grappleLayerMask = LayerMask.GetMask("Grappling");
    }
    private void FixedUpdate()
    {
        if (Physics.Raycast(Grapplepoint.position, transform.forward, out RaycastHit hit, Mathf.Infinity, grappleLayerMask))
        {
            Debug.Log($"Grapple hit: {hit.collider.name}");
        }
        else
        {
            Debug.DrawRay(Grapplepoint.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }
}
