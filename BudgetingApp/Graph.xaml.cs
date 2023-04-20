
namespace BudgetingApp;


public partial class Graph : ContentPage
{



    public Graph()
    {


        InitializeComponent();
        Database.getAllTrips();

    }

    private void timeSpanChanged(object sender, System.EventArgs e)
    {
        int index = ((Picker)sender).SelectedIndex;
        switch (index)
        {
            case 0:
                Database.days = 7;
                break;
            case 1:
                Database.days = 14;
                break;
            case 2:
                Database.days = 30;
                break;
            case 3:
                Database.days = 90;
                break;
            case 4:
                Database.days = 180;
                break;
            case 5:
                Database.days = 365;
                break;
            case 6:
                Database.days = Database.defaultDays;
                break;
            default:
                break;
        }
        Database.selectedSort = Database.sortBy.DATE;
        Database.getAllTrips();
        canvas.Invalidate();

        //trips.ItemsSource = shoppingTrips;
    }
}