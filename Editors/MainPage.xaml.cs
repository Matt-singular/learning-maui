﻿namespace Editors;

using Microsoft.Maui.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class MainPage : ContentPage
{
  public MainPage()
  {
    InitializeComponent();
  }

  private void OnFormatJsonClicked(object sender, EventArgs e)
  {
    try
    {
      var parsedJson = JToken.Parse(InputEditor.Text);
      OutputEditor.Text = parsedJson.ToString(Formatting.Indented);
    }
    catch (JsonReaderException ex)
    {
      OutputEditor.Text = $"Invalid JSON: {ex.Message}";
    }
  }

  private void OnClearClicked(object sender, EventArgs e)
  {
    // Gets the EditorName from the CommandParameter
    var button = sender as Button;
    var editorName = button.CommandParameter.ToString();

    // Checks which Editor to clear
    List<Editor?> editorsToClear = editorName switch
    {
      "InputEditor" => [InputEditor, OutputEditor],
      "OutputEditor" => [OutputEditor],
      _ => throw new ArgumentNullException(nameof(editorName), "You need to specify an EditorName for the event using the CommandParameter")
    };

    // Clear editors
    foreach (var editor in editorsToClear)
    {
      editor!.Text = string.Empty;
    }
  }

  private void OnCopyClicked(object sender, EventArgs e)
  {
    var text = OutputEditor.Text;
    if (!string.IsNullOrEmpty(text))
    {
      Clipboard.SetTextAsync(text);
    }
  }

  private async void OnSaveClicked(object sender, EventArgs e)
  {
    var filePickerResult = await FilePicker.Default.PickAsync(new PickOptions
    {
      FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            { DevicePlatform.WinUI, new[] { "json" } }
        }),
      PickerTitle = "Save JSON File"
    });

    if (filePickerResult != null)
    {
      await File.WriteAllTextAsync(filePickerResult.FullPath, OutputEditor.Text);
    }
  }
}