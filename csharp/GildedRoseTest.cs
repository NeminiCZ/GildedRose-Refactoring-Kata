using NUnit.Framework;
using System.Collections.Generic;
using csharp.Items;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void TestNormalItem()
        {
            var items = new List<IItem> { new NormalItem { Name = "bread", SellIn = 2, Quality = 2 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual("bread", items[0].Name);
            Assert.AreEqual(1, items[0].SellIn);
            Assert.AreEqual(1, items[0].Quality);
        }

        [Test]
        public void TestNormalItemSellInExpired()
        {
            var items = new List<IItem> { new NormalItem { Name = "bread", SellIn = 0, Quality = 3 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual("bread", items[0].Name);
            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(1, items[0].Quality);
        }

        [Test]
        public void TestNormalItemQualityExpired()
        {
            var items = new List<IItem> { new NormalItem { Name = "bread", SellIn = 2, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.AreEqual("bread", items[0].Name);
            Assert.AreEqual(1, items[0].SellIn);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void TestAgedBrie()
        {
            var items = new List<IItem> { new AgedBrieItem { Name = "Aged Brie", SellIn = 1, Quality = 1 } };
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
            var items = new List<IItem> { new AgedBrieItem { Name = "Aged Brie", SellIn = 2, Quality = 49 } };
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
            var items = new List<IItem> { new LegendaryItem { Name = "Sulfuras", SellIn = 1, Quality = 80 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("Sulfuras", items[0].Name);
            Assert.AreEqual(80, items[0].Quality);

            app.UpdateQuality();

            Assert.AreEqual("Sulfuras", items[0].Name);
            Assert.AreEqual(80, items[0].Quality);
        }

        [Test]
        public void TestBackstagePassMore10Days()
        {
            var items = new List<IItem> { new BackStageItem { Name = "Backstage passes to a wow concert", SellIn = 12, Quality = 10 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("Backstage passes to a wow concert", items[0].Name);
            Assert.AreEqual(11, items[0].SellIn);
            Assert.AreEqual(11, items[0].Quality);
        }

        [Test]
        public void TestBackstagePassLess10Days()
        {
            var items = new List<IItem> { new BackStageItem { Name = "Backstage passes to a wow concert", SellIn = 10, Quality = 10 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("Backstage passes to a wow concert", items[0].Name);
            Assert.AreEqual(9, items[0].SellIn);
            Assert.AreEqual(12, items[0].Quality);
        }

        [Test]
        public void TestBackstagePassLess5Days()
        {
            var items = new List<IItem> { new BackStageItem { Name = "Backstage passes to a wow concert", SellIn = 5, Quality = 10 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("Backstage passes to a wow concert", items[0].Name);
            Assert.AreEqual(4, items[0].SellIn);
            Assert.AreEqual(13, items[0].Quality);
        }

        [Test]
        public void TestBackstagePassOld()
        {
            var items = new List<IItem> { new BackStageItem { Name = "Backstage passes to a wow concert", SellIn = 0, Quality = 10 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("Backstage passes to a wow concert", items[0].Name);
            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void TestConjuredItem()
        {
            var items = new List<IItem> { new ConjuredItem { Name = "Conjured Mana Potion", SellIn = 5, Quality = 10 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(4, items[0].SellIn);
            Assert.AreEqual(8, items[0].Quality);
        }

        [Test]
        public void TestConjuredItemOld()
        {
            var items = new List<IItem> { new ConjuredItem { Name = "Conjured Mana Potion", SellIn = 0, Quality = 10 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(6, items[0].Quality);
        }


    }
}
