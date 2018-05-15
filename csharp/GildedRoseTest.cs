using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void testNormalItem()
        {
            var items = new List<Item> { new Item { Name = "bread", SellIn = 2, Quality = 2 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual("bread", items[0].Name);
            Assert.AreEqual(1, items[0].SellIn);
            Assert.AreEqual(1, items[0].Quality);
        }
    }
}
