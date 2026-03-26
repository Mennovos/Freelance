using UnityEngine;

public abstract class BasePickup : MonoBehaviour
{
    protected Gamemanger gamemanger;
    protected Grapple grappler;
    protected virtual void Start()
    {
        gamemanger = FindFirstObjectByType<Gamemanger>();
        grappler = FindFirstObjectByType<Grapple>();

    }
    protected virtual void Update()
    {
      if (grappler.IsPickedUpByGrappler)
        {
            gamemanger.AddItemes(1);
            Destroy(gameObject);
            grappler.IsPickedUpByGrappler = false;
        }
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        gamemanger.AddItemes(1);
        Destroy(gameObject);
    }
}
