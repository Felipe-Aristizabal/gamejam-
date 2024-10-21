[System.Serializable]
public class Order
{
    public string customerName;
    public string foodQuantity;
    public string drinkQuantity;
}

[System.Serializable]
public class OrderList
{
    public Order[] orders;
}
