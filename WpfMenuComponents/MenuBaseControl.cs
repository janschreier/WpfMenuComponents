using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace WpfMenuComponents
{
  public class MenuBaseControl : UserControl
  {
    private class PlaceholderInfo
    {
      public ItemsControl Parent { get; set; }
      public int Index { get; set; }
      public string Id { get; set; }
    }

    // Liste der Platzhalter mit Parent, Id und Position im (Unter-) Menü
    private List<PlaceholderInfo> placeholders = new List<PlaceholderInfo>();



    // Platzhalter im Menü durch Ressourcen ersetzen
    protected void ReplacePlaceholders(Menu dasMenu)
    {
      // Liste nach Parents gruppieren
      foreach (var group in placeholders.GroupBy(p => p.Parent))
      {
        // Im Parent wg. Indizierung von hinten anfangen
        foreach (var platzhalterInfo in group.OrderByDescending(it => it.Index))
        {
          // Ressource suchen (kann im Host-Control liegen)
          var menuItems = (MenuItemList)this.TryFindResource(platzhalterInfo.Id);

          int i = 0;
          if (menuItems != null) // wenn gefunden, Ersetzungen vornehmen
          {
            foreach (var mi in menuItems) // alle Items aus Ressource hinzufügen
            {
              platzhalterInfo.Parent.Items.Insert(platzhalterInfo.Index + i, mi);
              i++;
            }
          }
          platzhalterInfo.Parent.Items.RemoveAt(platzhalterInfo.Index + i); // Platzhalter entfernen, auch wenn es keinen Ersatz in den Ressourcen gibt
        }
      }

    }

    // Alle Platzhalter rekursiv suchen
    protected void FindPlaceholders(ItemsControl itemsControl)
    {
      int index = 0; // Positionszähler
      foreach (var item in itemsControl.Items)
      {
        if (item is MenuItemsPlaceholder)
        {
          // Platzhalter in Liste aufnehmen
          placeholders.Add(new PlaceholderInfo { Id = ((MenuItemsPlaceholder)item).Id, Index = index, Parent = itemsControl });
        }
        else
        {
          var mi = item as MenuItem;
          if (mi != null && mi.HasItems) FindPlaceholders(mi); // Untermenü durchsuchen
        }
        index++;
      }

    }


  }
}
