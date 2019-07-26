using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace WpfMenuComponents
{
  public class CustomViewModel : INotifyPropertyChanged
  {
    public ActionCommand Command1 { get; set; }
    public ActionCommand Command2 { get; set; }

    public CustomViewModel()
    {
      Command1 = new ActionCommand(() => MessageBox.Show("Custom Command 1 ausgeführt"));
      Command2 = new ActionCommand(() => MessageBox.Show("Custom Command 2 ausgeführt"));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
