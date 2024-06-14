namespace SideMenus;

public partial class AppShell : Shell
{
  public string DefaultPage { get; set; }
  public bool HasSetUpProject { get; set; }

  public AppShell()
  {
    InitializeComponent();
    InitialiseFlyoutItems();
    GoToAsync($"//{DefaultPage}");
  }

  /// <summary>
  /// Adds side menu entries programmatically
  /// </summary>
  private void InitialiseFlyoutItems()
  {
    if (!HasSetUpProject)
    {
      // New user still needs to set up
      AddFlyoutItem("Startup", "dotnet_bot.png", typeof(MainPage), true);
      AddFlyoutItem("Configurations", "dotnet_bot.png", typeof(MainPage));
    }
    else
    {
      // Existing user
      AddFlyoutItem("Home", "dotnet_bot.png", typeof(MainPage), true);
      AddFlyoutItem("Configurations", "dotnet_bot.png", typeof(MainPage));
      AddFlyoutItem("User screen 1", "dotnet_bot.png", typeof(MainPage));
    }
  }

  private void AddFlyoutItem(string title, string icon, Type navigationPageType, bool isDefaultPage = false)
  {
    // Creates the flyout with its title and icon
    var flyout = new FlyoutItem
    {
      Title = title,
      Icon = icon,
      Route = title
    };

    // Default page to open
    if (isDefaultPage)
    {
      // Set a unique route for the default page
      this.DefaultPage = title;
    }

    // Creates the shell content to define the page to navigate to
    var shellContent = new ShellContent
    {
      ContentTemplate = new DataTemplate(navigationPageType)
    };
    flyout.Items.Add(shellContent);


    // Adds the flyout to the shell page
    this.Items.Add(flyout);
  }
}
