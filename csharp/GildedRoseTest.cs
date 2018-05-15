using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void TestNormalItem()
        {
            var items = new List<Item> { new Item { Name = "bread", SellIn = 2, Quality = 2 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual("bread", items[0].Name);
            Assert.AreEqual(1, items[0].SellIn);
            Assert.AreEqual(1, items[0].Quality);
        }

        [Test]
        public void TestNormalItemSellInExpired()
        {
            var items = new List<Item> { new Item { Name = "bread", SellIn = 0, Quality = 3 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual("bread", items[0].Name);
            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(1, items[0].Quality);
        }

        [Test]
        public void TestNormalItemQualityExpired()
        {
            var items = new List<Item> { new Item { Name = "bread", SellIn = 2, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual("bread", items[0].Name);
            Assert.AreEqual(1, items[0].SellIn);
            Assert.AreEqual(0, items[0].Quality);
        }


    }
}
