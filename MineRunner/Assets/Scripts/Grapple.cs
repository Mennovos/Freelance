using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Grapple : MonoBehaviour
{
     LayerMask grappleLayerMask;
    private LineRenderer lineRenderer;
    private PlayerController playerController;
    [SerializeField] private float GrappleSpeed = 5f;
    [SerializeField] private Transform Grapplepoint;
    [SerializeField] private List<Transform> grapplePoints;
    [SerializeField] private List<GameObject> PickupsPosition;

    public bool IsPickedUpByGrappler = false;

    private void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        lineRenderer = GetComponent<LineRenderer>();
        grappleLayerMask = LayerMask.GetMask("Grappling");
    }
    private void FixedUpdate()
    {
        if (Physics.Raycast(Grapplepoint.position, transform.forward, out RaycastHit hit, Mathf.Infinity, grappleLayerMask))
        {
            Debug.Log($"Grapple hit: {hit.collider.name}");
            if (playerController.Grappling == true && !hit.collider.CompareTag("Pickup"))
            {
                grapplePoints.Add(hit.transform);
                Vector3 EndPoint = hit.point;
            }
            if (playerController.Grappling == true && hit.collider.CompareTag("Pickup"))
            {
                PickupsPosition.Add(hit.collider.gameObject);
            }
        }
        else
        {
            //Debug.DrawRay(Grapplepoint.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

      
        Vector3 endPoint = Grapplepoint.position + (Grapplepoint.forward * 100);
        lineRenderer.SetPosition(0, Grapplepoint.position); // Start
        lineRenderer.SetPosition(1, endPoint);  // End

        for (int i = 0; i < grapplePoints.Count; i++)
        {
           playerController.transform.position = Vector3.Lerp(playerController.transform.position, grapplePoints[i].position, Time.deltaTime * GrappleSpeed);
            if (Vector3.Distance(playerController.transform.position, grapplePoints[i].position) < 4f)
            {
                grapplePoints.RemoveAt(i);
            }
        }
        for (int i = 0; i < PickupsPosition.Count; i++)
        {
            PickupsPosition[i].transform.position = Vector3.Lerp(PickupsPosition[i].transform.position, playerController.transform.position + new Vector3(0, 5, 0), Time.deltaTime * 3);
            if (Vector3.Distance(playerController.transform.position, PickupsPosition[i].transform.position) <= 5f)
            {
                Debug.Log("Removes it?");
                PickupsPosition.RemoveAt(i);
            }
        }
    }
}
