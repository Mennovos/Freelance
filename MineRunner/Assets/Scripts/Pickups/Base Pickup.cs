using UnityEngine;

public abstract class BasePickup : MonoBehaviour
{
    protected Gamemanger gamemanger;
    protected virtual void Start()
    {
        gamemanger = FindFirstObjectByType<Gamemanger>();
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        gamemanger.AddItemes(1);
        Destroy(gameObject);
    }
}
