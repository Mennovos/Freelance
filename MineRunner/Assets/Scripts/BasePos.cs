using UnityEngine;

public class BasePos : MonoBehaviour
{
    public bool turn;
    private void OnTriggerEnter(Collider other)
    {
        turn = true;
    }
}
