using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Items
{
    internal class LegendaryItem : IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public void UpdateQuality()
        {
            Quality = 80;
        }
    }
}
