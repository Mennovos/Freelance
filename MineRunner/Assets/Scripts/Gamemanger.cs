using TMPro;
using UnityEngine;

public class Gamemanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DiamondsText;
    [SerializeField] private TextMeshProUGUI EmeraldsText;
    private int Diamonds;
    private int Emeralds;
    public void AddItemes(int ItemsAmount,string Pickupmame)
    {
        Debug.Log("Added " + ItemsAmount + " items");
        if (Pickupmame == "Diamond")
        {
            Diamonds += ItemsAmount;
        }
        else if (Pickupmame == "Emerald")
        {
            Emeralds += ItemsAmount;
        }
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
