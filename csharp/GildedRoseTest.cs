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

        [Test]
        public void TestAgedBrie()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("Aged Brie", items[0].Name);
            Assert.AreEqual(0, items[0].SellIn);
            Assert.AreEqual(2, items[0].Quality);

            app.UpdateQuality();

            Assert.AreEqual("Aged Brie", items[0].Name);
            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(3, items[0].Quality);
        }

        [Test]
        public void TestQualityLess50()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 49 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("Aged Brie", items[0].Name);
            Assert.AreEqual(1, items[0].SellIn);
            Assert.AreEqual(50, items[0].Quality);

            app.UpdateQuality();

            Assert.AreEqual("Aged Brie", items[0].Name);
            Assert.AreEqual(0, items[0].SellIn);
            Assert.AreEqual(50, items[0].Quality);

            app.UpdateQuality();

            Assert.AreEqual("Aged Brie", items[0].Name);
            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(50, items[0].Quality);

        }

        [Test]
        public void TestSulfuras()
        {
            var items = new List<Item> { new Item { Name = "Sulfuras", SellIn = 1, Quality = 80 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("Sulfuras", items[0].Name);
            Assert.AreEqual(80, items[0].Quality);

            app.UpdateQuality();

            Assert.AreEqual("Sulfuras", items[0].Name);
            Assert.AreEqual(80, items[0].Quality);
        }

    }
}
