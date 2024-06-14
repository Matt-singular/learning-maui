namespace SideMenus;

using System.Windows.Input;

public partial class MenuPage : ContentPage
{
  public ICommand NavigateCommand { get; private set; }

  public MenuPage()
  {
    InitializeComponent();

    NavigateCommand = new Command<string>(async (route) => await Shell.Current.GoToAsync(route));
  }
}