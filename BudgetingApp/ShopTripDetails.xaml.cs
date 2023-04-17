namespace BudgetingApp;

public partial class ShopTripDetails : ContentPage, IQueryAttributable
{
    public string id;

    public ShopTripDetails()
    {
        InitializeComponent();

    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {

        id = (string)query["id"];
        OnPropertyChanged("id");

        List<Database.Purchase> pur = Database.desuGetAllPurchaches(id);
        testy.ItemsSource = pur;

        Database.ShoppingTrip pur2 = Database.desuGetShoppingTrip(id);
        List<Database.ShoppingTrip> test = new List<Database.ShoppingTrip>() { pur2 };
        testy2.ItemsSource = test;

    }

}