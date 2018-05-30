
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private readonly IList<Items.IItem> _items;
        public GildedRose(IList<Items.IItem> items)
        {
            this._items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                item.UpdateQuality();
            }    
        }
    }
}
