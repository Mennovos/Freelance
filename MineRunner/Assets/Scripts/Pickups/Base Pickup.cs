using Unity.VisualScripting;
using UnityEngine;

public abstract class BasePickup : MonoBehaviour
{
    protected Gamemanger gamemanger;
    protected Grapple grappler;
    protected PlayerController Player;
    protected virtual void Start()
    {
        gamemanger = FindFirstObjectByType<Gamemanger>();
        grappler = FindFirstObjectByType<Grapple>();
        Player = FindFirstObjectByType<PlayerController>();

    }
    protected virtual void Update()
    {
      if (grappler.IsPickedUpByGrappler)
        {
           LerpToPlayer();
        }
      if (Vector3.Distance(transform.position, Player.transform.position) < 0.5f)
        {
          grappler.IsPickedUpByGrappler = false;
        }
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        gamemanger.AddItemes(1);
        Destroy(gameObject);
    }
    protected virtual void LerpToPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, Player.transform.position + new Vector3(0,5,0), Time.deltaTime * 5f);
    }
}
