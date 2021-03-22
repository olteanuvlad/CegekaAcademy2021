using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            ItemObserverFactory itemFactory = new ItemObserverFactory();

            IList<Item> Items = new List<Item>{
                itemFactory.CreateItem("+5 Dexterity Vest", 10, 20),
                itemFactory.CreateItem("Aged Brie", 2, 0),
                itemFactory.CreateItem("Elixir of the Mongoose", 5, 7),
                itemFactory.CreateItem("Sulfuras, Hand of Ragnaros", 0, 80),
                itemFactory.CreateItem("Sulfuras, Hand of Ragnaros", -1, 80),
                itemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                itemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 10, 49),
                itemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, 49),
				itemFactory.CreateItem("Conjured Mana Cake", 3, 6)
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (Item item in Items)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
