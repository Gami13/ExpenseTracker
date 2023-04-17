using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace BudgetingApp;


public partial class Graph : ContentPage
{

    public ISeries[] Seriesy { get; set; }
                = new ISeries[] { new ColumnSeries<int> { Values = new[] { 2, 5, 4, -2, 4, -3, 5 } } };

    List<Database.ShoppingTrip> shoppingTrips;
    public Graph()
    {


        InitializeComponent();
        shoppingTrips = Database.getAllTrips();
        graph.Series = Seriesy;
    }
    private void sortIndexChanged(object sender, System.EventArgs e)
    {
        int index = ((Picker)sender).SelectedIndex;
        switch (index)
        {
            case 0:
                Database.selectedSort = Database.sortBy.DATE;
                Database.isReverse = false;
                break;
            case 1:
                Database.selectedSort = Database.sortBy.DATE;
                Database.isReverse = true;
                break;
            case 2:
                Database.selectedSort = Database.sortBy.SHOP;
                Database.isReverse = false;
                break;
            case 3:
                Database.selectedSort = Database.sortBy.SHOP;
                Database.isReverse = true;
                break;
            case 4:
                Database.selectedSort = Database.sortBy.PRICE;
                Database.isReverse = false;
                break;
            case 5:
                Database.selectedSort = Database.sortBy.PRICE;
                Database.isReverse = true;
                break;
            default:
                break;
        }
        shoppingTrips = Database.getAllTrips();
        //trips.ItemsSource = shoppingTrips;
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
        shoppingTrips = Database.getAllTrips();
        //trips.ItemsSource = shoppingTrips;
    }
}