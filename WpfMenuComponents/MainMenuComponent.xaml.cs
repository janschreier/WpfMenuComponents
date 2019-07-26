using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMenuComponents
{
  /// <summary>
  /// Interaction logic for MainMenuComponent.xaml
  /// </summary>
  public partial class MainMenuComponent : MenuBaseControl
  {

    public MainMenuComponent()
    {
      InitializeComponent();
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();

      FindPlaceholders(IdMainMenu);  // ggfs. rekursiv nach Menu suchen, wenn Name nicht gewünscht
      ReplacePlaceholders(IdMainMenu);

    }

  }
}
