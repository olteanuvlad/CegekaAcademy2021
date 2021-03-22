namespace csharpcore
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }

    public class ItemObserver : Item
    {
        protected IDegradationStrategy degradationStrategy;
        public ItemObserver(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }
        public virtual void Update()
        {
            Quality = degradationStrategy.GetNewQuality(SellIn, Quality);
            SellIn--;
        }

        public override string ToString()
        {
            return $"{Name}, {SellIn}, {Quality}";
        }
    }

    public class NormalItem : ItemObserver
    {
        public NormalItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            degradationStrategy = new NormalDegradationStrategy();
        }
    }

    public class AgedItem : ItemObserver
    {
        public AgedItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            degradationStrategy = new AgedDegradationStrategy();
        }
    }

    public class LegendaryItem : ItemObserver
    {
        public LegendaryItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            degradationStrategy = null;
        }

        public override void Update()
        {
            SellIn--;
        }
    }

    public class BackstagePassItem : ItemObserver
    {
        public BackstagePassItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            degradationStrategy = new BackstagePassDegradationStrategy();
        }
    }

    public class ConjuredItem : ItemObserver
    {
        public ConjuredItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            degradationStrategy = new ConjuredDegradationStrategy();
        }
    }

    public class ItemObserverFactory
    {
        public ItemObserver CreateItem(string name, int sellIn, int quality)
        {
            if (name.Contains("Aged"))
                return new AgedItem(name, sellIn, quality);
            else if (name.Contains("Backstage pass"))
                return new BackstagePassItem(name, sellIn, quality);
            else if (name.Contains("Conjured"))
                return new ConjuredItem(name, sellIn, quality);
            else if (name.Contains("Sulfuras"))
                return new LegendaryItem(name, sellIn, quality);
            else
                return new NormalItem(name, sellIn, quality);
        }
    }
}
