using TMPro;
using UnityEngine;

public class Gamemanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DiamondsText;
    [SerializeField] private TextMeshProUGUI EmeraldsText;
    [SerializeField] private TextMeshProUGUI RubysText;
    private int Diamonds;
    private int Emeralds;
    private int Rubys;
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
        else if (Pickupmame == "Ruby")
        {
            Rubys += ItemsAmount;
        }
    }
    void Start()
    {
        DiamondsText.text = " " + Diamonds; 
        EmeraldsText.text = " " + Emeralds;
        RubysText.text = " " + Rubys;
    }

    void Update()
    {
       DiamondsText.text = " " + Diamonds;
       EmeraldsText.text = " " + Emeralds;
       RubysText.text = " " + Rubys;
    }
}
