namespace csharpcore
{
    public interface IDegradationStrategy
    {
        int GetNewQuality(int sellIn, int quality);
    }

    public class NormalDegradationStrategy : IDegradationStrategy
    {
        private int ammount = 1;
        public int GetNewQuality(int sellIn, int quality)
        {
            if (sellIn < 0) ammount *= 2;
            return (quality - ammount < 0) ? 0 : quality - ammount;
        }
    }

    public class AgedDegradationStrategy : IDegradationStrategy
    {
        private int ammount = 1;
        public int GetNewQuality(int sellIn, int quality)
        {
            if (sellIn < 0) ammount *= 2;
            return (quality + ammount > 50) ? 50 : quality + ammount;
        }
    }

    public class BackstagePassDegradationStrategy : IDegradationStrategy
    {
        private int ammount = 1;
        public int GetNewQuality(int sellIn, int quality)
        {
            if (sellIn < 0) return 0;
            else if (sellIn <= 5) ammount = 3;
            else if (sellIn <= 10) ammount = 2;
            return (quality + ammount > 50) ? 50 : quality + ammount;
        }
    }

    public class ConjuredDegradationStrategy : IDegradationStrategy
    {
        private int ammount = 2;
        public int GetNewQuality(int sellIn, int quality)
        {
            if (sellIn < 0) ammount *= 2;
            return (quality - ammount < 0) ? 0 : quality - ammount;
        }
    }
}