using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject Rahhhsound;
    private void Start()
    {
    }
    private void Update()
    {
    
    }
    public void Coolsound()
    {
       Instantiate(Rahhhsound, transform.position, Quaternion.identity);
    }
}
