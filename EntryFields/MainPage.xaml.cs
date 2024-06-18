namespace EntryFields;
public partial class MainPage : ContentPage
{
  public Entry BuildInputField { get; private set; }
  public Entry FromInputField { get; private set; }
  public Entry ToInputField { get; private set; }
  public SearchBar SearchField { get; private set; }

  public MainPage()
  {
    var columnWidth = 125;//DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density / 10;
    InitializeComponent();
    RenderContentPage();
    this.BuildInputField = RenderRow(columnWidth, Constants.BuildLabel, Constants.BuildPlaceholder, OnClickBuildInputField);
    this.FromInputField = RenderRow(columnWidth, Constants.FromLabel, Constants.FromPlaceholder, OnClickFromInputField);
    this.ToInputField = RenderRow(columnWidth, Constants.ToLabel, Constants.ToPlaceholder, OnClickToInputField);
    this.SearchField = RenderSearchRow(OnSearchField);
  }

  #region Event Handlers
  private void OnClickInputFieldXaml(object? sender, EventArgs e) => DisplayAlert("InputFieldXaml Value", this.InputFieldXaml.Text, "OK");
  private void OnClickBuildInputField(object? sender, EventArgs e) => DisplayAlert("BuildInputField Value", this.BuildInputField.Text, "OK");
  private void OnClickFromInputField(object? sender, EventArgs e) => DisplayAlert("FromInputField Value", this.FromInputField.Text, "OK");
  private void OnClickToInputField(object? sender, EventArgs e) => DisplayAlert("ToInputField Value", this.ToInputField.Text, "OK");
  private void OnSearchField(object? sender, EventArgs e) => DisplayAlert("SearchField Value", this.SearchField.Text, "OK");
  #endregion

  #region XAML
  private void RenderContentPage()
  {
    // 1) Define the VerticalStackLayout
    var verticalStackLayout = new VerticalStackLayout
    {
      Spacing = 50,
      Padding = 30,
      HorizontalOptions = LayoutOptions.Fill,
      VerticalOptions = LayoutOptions.Start
    };
    this.Content = verticalStackLayout;
  }

  private Entry RenderRow(double columnWidth, string labelText, string placeholderText, EventHandler onClickEvent)
  {
    // 1) Create the Grid
#pragma warning disable CS0618 // Type or member is obsolete 
    var grid = new Grid
    {
      HorizontalOptions = LayoutOptions.FillAndExpand, // this is a valid option for a grid, and is only obsolete for a StackLayout.
      VerticalOptions = LayoutOptions.Start,
      ColumnSpacing = 50
    };
#pragma warning restore CS0618 // Type or member is obsolete

    // Define the columns
    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = columnWidth });
    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

    // 2) Create the Label
    var label = new Label
    {
      Text = $"{labelText}: ",
      VerticalOptions = LayoutOptions.Center,
      TextColor = Colors.MediumPurple,
      FontSize = 20,
      FontAttributes = FontAttributes.Bold
    };
    Grid.SetColumn(label, 0);

    // 3) Create the Entry
    var entry = new Entry
    {
      Placeholder = placeholderText,
      VerticalOptions = LayoutOptions.Center
    };
    Grid.SetColumn(entry, 1);
    //this.DynamicInputField = entry; // TODO:

    // 4) Create the Button
    var button = new Button
    {
      Text = "Submit",
      VerticalOptions = LayoutOptions.Fill
    };
    button.Clicked += onClickEvent;
    Grid.SetColumn(button, 2);

    // Add controls to the Grid
    grid.Children.Add(label);
    grid.Children.Add(entry);
    grid.Children.Add(button);

    // Set the ContentPage's content to the VerticalStackLayout
    AddToContentPage(grid);

    // Return the entry to allow binding in the constructor
    return entry;
  }

  private SearchBar RenderSearchRow(EventHandler onSearchEvent)
  {
    // Create the Grid
    var grid = new Grid
    {
      HorizontalOptions = LayoutOptions.FillAndExpand,
      VerticalOptions = LayoutOptions.Start,
      ColumnSpacing = 50
    };

    // Define the columns
    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

    // Create the SearchBar
    var searchBar = new SearchBar
    {
      Placeholder = "Search...",
      VerticalOptions = LayoutOptions.Center,
      HorizontalOptions = LayoutOptions.FillAndExpand
    };
    searchBar.SearchButtonPressed += onSearchEvent;
    Grid.SetColumn(searchBar, 0);
    Grid.SetColumnSpan(searchBar, 2); // Make the SearchBar span across both columns

    // Add the SearchBar to the Grid
    grid.Children.Add(searchBar);

    // Add the Grid to the ContentPage
    AddToContentPage(grid);
    return searchBar;
  }

  private void AddToContentPage(Layout layoutToAdd)
  {
    var mainLayout = Content as VerticalStackLayout;
    mainLayout?.Children.Add(layoutToAdd);
  }

  public static class Constants
  {
    // Build Input Field
    public const string BuildLabel = "Build";
    public const string BuildPlaceholder = "Enter build name here...";
    // From Input Field
    public const string FromLabel = "To";
    public const string FromPlaceholder = "Select a branch or tag...";
    // To Input Field
    public const string ToLabel = "From";
    public const string ToPlaceholder = "Select a branch or tag...";
  }
  #endregion
}