
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Items.IItem> Items;
        public GildedRose(IList<Items.IItem> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Items.IItem item in Items)
            {
                item.UpdateQuality();
            }    
        }
    }
}
