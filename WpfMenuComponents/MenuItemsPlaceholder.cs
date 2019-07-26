using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfMenuComponents
{
  public class MenuItemsPlaceholder : Control
  {
    /// <summary>
    /// Id einer Ressource, die den Platzhalter ersetzen soll
    /// </summary>
    public string Id
    {
      get { return (string)GetValue(IdProperty); }
      set { SetValue(IdProperty, value); }
    }

    public static readonly DependencyProperty IdProperty =
        DependencyProperty.Register("Id", typeof(string), typeof(MenuItemsPlaceholder));

  }

  /// <summary>
  /// Hilfsklasse für Liste von MenuItems in der Ressource
  /// </summary>
  public class MenuItemList : List<MenuItem> { }

}
