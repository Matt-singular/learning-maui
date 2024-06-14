namespace SideMenus;

public partial class StartupPage : ContentPage
{
  int count = 0;

  public StartupPage()
  {
    InitializeComponent();
  }

  private void OnStartupWizardClicked(object sender, EventArgs e)
  {
    if (Application.Current.MainPage is AppShell appShell)
    {
      //appShell.HasSetUpProject = true;
      //appShell.InitialiseFlyoutItems();
      Application.Current.MainPage = new AppShell(true);
    }
  }
}
