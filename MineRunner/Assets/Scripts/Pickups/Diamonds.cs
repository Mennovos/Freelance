using UnityEngine;

public class Diamonds : BasePickup
{
     private void Start()
     {
      base.Start();
     }
     private void Update()
     {
       base.Update();
    }
     private void OnCollisionEnter(Collision collision)
     {
        base.OnCollisionEnter(collision);
        gamemanger.AddItemes(1, "Diamond");
    }

}
