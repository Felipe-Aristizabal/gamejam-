using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoucherManager : MonoBehaviour
{
    public Text[] voucherTexts;  
    
    private OrderList orderList;
    private List<int> usedIndices = new List<int>();  

    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("orders");
        if (jsonFile != null)
        {
            orderList = JsonUtility.FromJson<OrderList>("{\"orders\":" + jsonFile.text + "}");
            ShowOrdersOnVouchers();
        }
        else
        {
            Debug.LogError("There is no orders JSON.");
        }
    }

    void ShowOrdersOnVouchers()
    {
        if (orderList != null && orderList.orders.Length >= voucherTexts.Length)
        {
            for (int i = 0; i < voucherTexts.Length; i++)
            {
                int randomIndex = GetUniqueRandomIndex();
                Order randomOrder = orderList.orders[randomIndex];

                voucherTexts[i].text = $"<b>Customer:</b> {randomOrder.customerName}\n" +
                                       $"<b>Food:</b> {randomOrder.foodQuantity}\n" +
                                       $"<b>Drink:</b> {randomOrder.drinkQuantity}";
                FormatText(voucherTexts[i]);

                usedIndices.Add(randomIndex);
            }
        }
        else
        {
            Debug.LogError("There is not enough orders in database.");
        }
    }

    int GetUniqueRandomIndex()
    {
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, orderList.orders.Length);
        }
        while (usedIndices.Contains(randomIndex));  
        return randomIndex;
    }
    
    void FormatText(Text voucherText)
    {
        voucherText.color = Color.black;
        voucherText.fontSize = 12;
        voucherText.lineSpacing = 1.2f;
        voucherText.resizeTextForBestFit = true;
        voucherText.resizeTextMinSize = 8;
        voucherText.resizeTextMaxSize = 15;
    }
}
