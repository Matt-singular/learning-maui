namespace Dropdowns;

using Microsoft.Maui.Controls;

public partial class MainPage : ContentPage
{
  public double QuarterScreenWidth { get; set; }

  public MainPage()
  {
    InitializeComponent();
    QuarterScreenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density / 4;
    this.BindingContext = this;
    PopulateComboBox();
  }

  private void PopulateComboBox()
  {
    var options = new List<string>
    {
      "Option 1",
      "Option 2",
      "Option 3",
      "Option 4"
    };

    HardcodedDropdown.ItemsSource = options;
  }

  private void OnChangeSelectedDropdownOption(object sender, EventArgs e)
  {
    // If there is custom logic to fire when changing the dropdown selection:
    var selectedOption = HardcodedDropdown.SelectedItem.ToString();
    Console.WriteLine($"Selected: {selectedOption}");
  }
}