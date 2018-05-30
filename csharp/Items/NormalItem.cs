using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Items
{
    class NormalItem : IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public void UpdateQuality()
        {
            SellIn = SellIn - 1;
            Quality = Quality == 0 ? 0 : Quality - 1;
        }
    }
}
