using UnityEngine;
using System.Collections;
public class Destroy : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;
    private void Start()
    {
        AudioSource.Play();
        StartCoroutine(DestroyCoroutine());
    }
    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
