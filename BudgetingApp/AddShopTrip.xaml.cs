using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BudgetingApp;

public partial class AddShopTrip : ContentPage
{
    ObservableCollection<Database.Purchase> itemList = new ObservableCollection<Database.Purchase> ();
	int tempId = 0;
	

    int tripID = Database.getMaxTripId()+1;
    public AddShopTrip()
	{
		InitializeComponent();

       
		testy.ItemsSource = itemList;
    }
	

   private void addItem(object sender, EventArgs e)
	{
		Debug.WriteLine("Test2");
		Database.Purchase purchase = new Database.Purchase();
		if (itemName.Text == null || itemPrice.Text == null || itemAmount.Text == null)
		{
            DisplayAlert("Error", "Please fill in all fields", "OK");
            return;
        }
		purchase.Name = itemName.Text;
		purchase.Price = double.Parse(itemPrice.Text);
		purchase.Amount = double.Parse(itemAmount.Text);
		purchase.Date = tripDate.Date;
		purchase.shoppingTripId = tripID;
		purchase.Id= tempId;
		tempId++;
		

        itemList.Add(purchase);
		itemName.Text = "";
		itemPrice.Text = "";
		itemAmount.Text = "";

	
   }
    private void removeItem(object sender, EventArgs e)
	{

		Debug.WriteLine("test");
	}
}