using TMPro;
using UnityEngine;

public class Gamemanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ItemsText;
    private int Diamonds;
    public void AddItemes(int Items)
    {
        Debug.Log("Added " + Items + " items");
        Diamonds += Items;
    }
    void Start()
    {
        ItemsText.text = " " + Diamonds;   
    }

    void Update()
    {
       ItemsText.text = " " + Diamonds;
    }
}
