using System;
using System.Collections.Generic;
using csharp.Items;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<IItem> Items = new List<IItem>{
                new NormalItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new AgedBrieItem {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new NormalItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new LegendaryItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new LegendaryItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new BackStageItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new BackStageItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new BackStageItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new ConjuredItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
