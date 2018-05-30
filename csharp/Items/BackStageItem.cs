using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Items
{
    internal class BackStageItem : IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public void UpdateQuality()
        {
            SellIn = SellIn - 1;
            Quality = SellIn > 10 ? Quality + 1 :
                SellIn > 5 ? Quality + 2 :
                SellIn < 0 ? 0 : Quality + 3;
            Quality = Quality > 50 ? 50 : Quality;
        }
    }
}
