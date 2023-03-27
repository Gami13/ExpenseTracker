

using System.Diagnostics;

namespace BudgetingApp;



public partial class MainPage : ContentPage
{
    List<Database.ShoppingTrip> shoppingTrips;

    public MainPage()
    {
        InitializeComponent();
        shoppingTrips = Database.getAllTrips();
        trips.ItemsSource = shoppingTrips;
    }


    private void refresh(object sender, EventArgs e)
    {
        shoppingTrips = Database.getAllTrips();
    }
    private void sortIndexChanged(object sender, System.EventArgs e)
    {
        Debug.WriteLine("Test");
    }
    private void timeSpanChanged(object sender, System.EventArgs e)
    {
        Debug.WriteLine("Test");
    }
    private async void onItemTapped(object sender, System.EventArgs e)
    {
        FlexLayout btn = (FlexLayout)sender;

        Debug.WriteLine($"TAPPED  {btn.BindingContext.ToString()}");
        await Shell.Current.GoToAsync($"//Details?id={2}");
    }
}

