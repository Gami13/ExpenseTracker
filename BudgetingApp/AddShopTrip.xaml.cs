using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BudgetingApp;

public partial class AddShopTrip : ContentPage
{

    ObservableCollection<Database.Purchase> itemList = new ObservableCollection<Database.Purchase>();

    int tempId = 0;
    int tripID = Database.getMaxTripId() + 1;
    public AddShopTrip()
    {
        InitializeComponent();

        reset();

        testy.ItemsSource = itemList;
    }
    private void reset()
    {
        itemList.Clear();
        tempId = 0;


        tripID = Database.getMaxTripId() + 1;
        itemName.Text = "";
        itemPrice.Text = "";
        itemAmount.Text = "";
        tripShop.Text = "";
        tripDate.Date = DateTime.Now;
        tripDescription.Text = "";

    }

    private void addItem(object sender, EventArgs e)
    {
        Debug.WriteLine("Test2");
        Database.Purchase purchase = new Database.Purchase();
        if (itemName.Text.Length < 1 || itemPrice.Text.Length < 1 || itemAmount.Text.Length < 1)
        {
            DisplayAlert("Error", "Please fill in all fields", "OK");
            return;
        }
        Debug.WriteLine(itemName.Text + itemPrice.Text + itemAmount.Text);
        purchase.Name = itemName.Text;
        purchase.Price = double.Parse(itemPrice.Text);
        purchase.Amount = double.Parse(itemAmount.Text);
        purchase.Date = tripDate.Date;
        purchase.shoppingTripId = tripID;
        purchase.Id = tempId;
        tempId++;


        itemList.Add(purchase);
        itemName.Text = "";
        itemPrice.Text = "";
        itemAmount.Text = "";


    }
    private void removeItem(object sender, EventArgs e)
    {
        //get sender binding context and remove from list
        string itemId = ((Button)sender).BindingContext.ToString();
        itemList.Remove(itemList.Where(x => x.Id == int.Parse(itemId)).FirstOrDefault());


        Debug.WriteLine("test " + itemId);
    }
    private async void addTrip(object sender, EventArgs e)
    {
        Database.ShoppingTrip trip = new Database.ShoppingTrip();
        trip.Shop = tripShop.Text;
        trip.Description = tripDescription.Text;
        trip.Date = tripDate.Date;
        double totalPrice = 0;
        foreach (Database.Purchase purchase in itemList)
        {
            totalPrice += purchase.Price * purchase.Amount;
            purchase.Id = 0;
            Database.addPurchase(purchase);

        }
        trip.Price = totalPrice;
        trip.Price = totalPrice;
        Database.addTrip(trip);
        reset();
        await Shell.Current.GoToAsync("//MainPage");

    }
}