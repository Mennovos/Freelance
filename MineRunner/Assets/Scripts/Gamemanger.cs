using TMPro;
using UnityEngine;

public class Gamemanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DiamondsText;
    [SerializeField] private TextMeshProUGUI EmeraldsText;
    private int Diamonds;
    private int Emeralds;
    public void AddItemes(int Items)
    {
        Debug.Log("Added " + Items + " items");
        Diamonds += Items;
    }
    void Start()
    {
        DiamondsText.text = " " + Diamonds; 
        EmeraldsText.text = " " + Emeralds;
    }

    void Update()
    {
       DiamondsText.text = " " + Diamonds;
       EmeraldsText.text = " " + Emeralds;
    }
}
