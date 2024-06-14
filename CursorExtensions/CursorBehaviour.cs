namespace CursorExtensions;

#if ANDROID
using CursorExtensions.Platforms.Android;
#endif
#if IOS
using CursorExtensions.Platforms.iOS;
#endif
#if MACCATALYST
using CursorExtensions.Platforms.MacCatalyst;
#endif
#if WINDOWS
using CursorExtensions.Platforms.Windows;
#endif

public class CursorBehaviour
{
  public static readonly BindableProperty CursorProperty = BindableProperty.CreateAttached("Cursor", typeof(CursorIcon), typeof(CursorBehaviour), CursorIcon.Arrow, propertyChanged: CursorChanged);

  private static void CursorChanged(BindableObject bindable, object oldvalue, object newvalue)
  {
    if (bindable is VisualElement visualElement)
    {
      visualElement.SetCustomCursor((CursorIcon)newvalue, Application.Current?.MainPage?.Handler?.MauiContext);
    }
  }

  public static CursorIcon GetCursor(BindableObject view) => (CursorIcon)view.GetValue(CursorProperty);

  public static void SetCursor(BindableObject view, CursorIcon value) => view.SetValue(CursorProperty, value);
}

public enum CursorIcon
{
  Wait,
  Hand,
  Arrow,
  IBeam,
  Cross,
  SizeAll
}