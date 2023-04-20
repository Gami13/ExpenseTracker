namespace BudgetingApp;


public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        MessagingCenter.Subscribe<MainPage, string>(this, "showThing", async (sender, arg) =>
        {
            tripDetails.IsVisible = true;
        });


    }
    protected override void OnNavigating(ShellNavigatingEventArgs args)
    {
        try
        {

            if (Shell.Current.CurrentState.Location.ToString() == "//Details")
            {
                tripDetails.IsVisible = false;
            }
            base.OnNavigating(args);
        }
        catch
        {

        }

    }





}
