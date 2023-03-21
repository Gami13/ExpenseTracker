

namespace BudgetingApp;



public partial class MainPage : ContentPage
{
	int count = 0;
	
	

	public MainPage()
	{
		InitializeComponent();
        List<Database.shoppingTrip> shoppingTrips = Database.getAllTrips();
		if (shoppingTrips.Count >0 )
		{
            testLabel.Text = shoppingTrips[0].Shop;

        }

    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		

    }
}

