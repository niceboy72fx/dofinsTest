namespace Dofins.Models
{
    public class Quote
    {
        public DateTime Date { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Exchange { get; set; }

        public string IndustryCode { get; set; }

        public double PriceBasic { get; set; }

        public double PriceCeiling { get; set; }

        public double PriceFloor { get; set; }

        public double PriceCurrent { get; set; }

        public double PriceLast { get; set; }

        public double PriceHigh { get; set; }

        public double PriceLow { get; set; }

        public double PriceOpen { get; set; }

        public double PriceClose { get; set; }

        public double PriceAverage { get; set; }

        public double TotalTrade { get; set; }

        public double TotalVolume { get; set; }

        public double Volume { get; set; }

        public double TotalValue { get; set; }

        public double PriceBid1 { get; set; }

        public double QuantityBid1 { get; set; }

        public double PriceBid2 { get; set; }

        public double QuantityBid2 { get; set; }

        public double PriceBid3 { get; set; }

        public double QuantityBid3 { get; set; }

        public double PriceAsk1 { get; set; }

        public double QuantityAsk1 { get; set; }

        public double PriceAsk2 { get; set; }

        public double QuantityAsk2 { get; set; }

        public double PriceAsk3 { get; set; }

        public double QuantityAsk3 { get; set; }

        public double BuyCount { get; set; }

        public double SellCount { get; set; }

        public double BuyQuantity { get; set; }

        public double SellQuantity { get; set; }

        public double BuyForeignQuantity { get; set; }

        public double SellForeignQuantity { get; set; }

        public double BuyForeignValue { get; set; }

        public double SellForeignValue { get; set; }

        public double CurrentForeignRoom { get; set; }

        public double TotalActiveBuyVolume { get; set; }

        public double TotalActiveSellVolume { get; set; }

        public double PricePercentChange
        {
            get
            {
                return this.PriceCurrent != 0.0 && this.PriceBasic != 0.0 ? this.PriceCurrent / this.PriceBasic - 1.0 : 0.0;
            }
        }

        public double PriceChange
        {
            get
            {
                return this.PriceCurrent != 0.0 && this.PriceBasic != 0.0 ? this.PriceCurrent - this.PriceBasic : 0.0;
            }
        }
    }
}
