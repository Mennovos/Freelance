using UnityEngine;

public class Grapple : MonoBehaviour
{
   LayerMask grappleLayerMask;
    private float q = 0.0f;
    private void Start()
    {
        grappleLayerMask = LayerMask.GetMask("Grappling");
    }
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity, grappleLayerMask))
        {
            Debug.Log($"Grapple hit: {hit.collider.name}");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
