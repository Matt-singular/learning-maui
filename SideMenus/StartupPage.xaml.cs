namespace SideMenus;

public partial class StartupPage : ContentPage
{
  public StartupPage()
  {
    InitializeComponent();
  }

  private void OnStartupWizardClicked(object sender, EventArgs e)
  {
    // Re-initialise the AppShell to show the new Side menu items
    Application.Current.MainPage = new AppShell(hasSetup: true);

    //if (Application.Current.MainPage is AppShell appShell)
    //{
    //  appShell.HasSetUpProject = true;
    //  appShell.InitialiseFlyoutItems();
    //}
  }
}
