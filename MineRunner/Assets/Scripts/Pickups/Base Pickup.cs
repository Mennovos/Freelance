using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BasePickup : MonoBehaviour
{
    protected Gamemanger gamemanger;
    protected virtual void Start()
    {
        gamemanger = FindFirstObjectByType<Gamemanger>();

    }
    protected virtual void Update()
    {
     transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
       Grapple grapple = collision.gameObject.GetComponentInChildren<Grapple>();
        if (grapple != null)
        {
            grapple.PickupsPosition.Remove(grapple.PickupsPosition[0]);
        }
        Destroy(gameObject);
    }
}
