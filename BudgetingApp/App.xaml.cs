
namespace BudgetingApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Database.CreateDatabase();
        MainPage = new AppShell();


    }
}
