namespace Dofins.Models
{
    public class QuoteChanges
    {
        public QuoteChanges(long iD, DateTime? date, string symbol, string name, string type, string exchange, double? priceBasic, double? priceCeiling, double? priceFloor, double? priceCurrent, double? priceLast, double? priceHigh, double? priceLow, double? priceOpen, double? priceClose, double? priceAverage, double? totalVolume, double? volume, double? totalTrade, double? totalValue, double? priceBid1, double? quantityBid1, double? priceBid2, double? quantityBid2, double? priceBid3, double? quantityBid3, double? priceAsk1, double? quantityAsk1, double? priceAsk2, double? quantityAsk2, double? priceAsk3, double? quantityAsk3, double? buyCount, double? sellCount, double? buyQuantity, double? sellQuantity, double? buyForeignQuantity, double? sellForeignQuantity, double? buyForeignValue, double? sellForeignValue, double? currentForeignRoom, double? totalActiveBuyVolume, double? totalActiveSellVolume, double? pricePercentChange, double? priceChange)
        {
            ID = iD;
            Date = date;
            Symbol = symbol;
            Name = name;
            Type = type;
            Exchange = exchange;
            PriceBasic = priceBasic;
            PriceCeiling = priceCeiling;
            PriceFloor = priceFloor;
            PriceCurrent = priceCurrent;
            PriceLast = priceLast;
            PriceHigh = priceHigh;
            PriceLow = priceLow;
            PriceOpen = priceOpen;
            PriceClose = priceClose;
            PriceAverage = priceAverage;
            TotalVolume = totalVolume;
            Volume = volume;
            TotalTrade = totalTrade;
            TotalValue = totalValue;
            PriceBid1 = priceBid1;
            QuantityBid1 = quantityBid1;
            PriceBid2 = priceBid2;
            QuantityBid2 = quantityBid2;
            PriceBid3 = priceBid3;
            QuantityBid3 = quantityBid3;
            PriceAsk1 = priceAsk1;
            QuantityAsk1 = quantityAsk1;
            PriceAsk2 = priceAsk2;
            QuantityAsk2 = quantityAsk2;
            PriceAsk3 = priceAsk3;
            QuantityAsk3 = quantityAsk3;
            BuyCount = buyCount;
            SellCount = sellCount;
            BuyQuantity = buyQuantity;
            SellQuantity = sellQuantity;
            BuyForeignQuantity = buyForeignQuantity;
            SellForeignQuantity = sellForeignQuantity;
            BuyForeignValue = buyForeignValue;
            SellForeignValue = sellForeignValue;
            CurrentForeignRoom = currentForeignRoom;
            TotalActiveBuyVolume = totalActiveBuyVolume;
            TotalActiveSellVolume = totalActiveSellVolume;
            PricePercentChange = pricePercentChange;
            PriceChange = priceChange;
        }

        public long ID { get; set; }
        public DateTime? Date { get; set; } // important
        public string Symbol { get; set; } // important
        public string Name { get; set; }
        public string Type { get; set; }
        public string Exchange { get; set; } 
        public double? PriceBasic { get; set; }
        public double? PriceCeiling { get; set; }
        public double? PriceFloor { get; set; }
        public double? PriceCurrent { get; set; } // important
        public double? PriceLast { get; set; }
        public double? PriceHigh { get; set; } // important
        public double? PriceLow { get; set; } // important
        public double? PriceOpen { get; set; } // important
        public double? PriceClose { get; set; } // important
        public double? PriceAverage { get; set; } // important
        public double? TotalVolume { get; set; } // important
        public double? Volume { get; set; }
        public double? TotalTrade { get; set; }
        public double? TotalValue { get; set; }
        public double? PriceBid1 { get; set; }
        public double? QuantityBid1 { get; set; }
        public double? PriceBid2 { get; set; }
        public double? QuantityBid2 { get; set; }
        public double? PriceBid3 { get; set; }
        public double? QuantityBid3 { get; set; }
        public double? PriceAsk1 { get; set; }
        public double? QuantityAsk1 { get; set; }
        public double? PriceAsk2 { get; set; }
        public double? QuantityAsk2 { get; set; }
        public double? PriceAsk3 { get; set; }
        public double? QuantityAsk3 { get; set; }
        public double? BuyCount { get; set; }
        public double? SellCount { get; set; }
        public double? BuyQuantity { get; set; }
        public double? SellQuantity { get; set; }
        public double? BuyForeignQuantity { get; set; }
        public double? SellForeignQuantity { get; set; }
        public double? BuyForeignValue { get; set; }
        public double? SellForeignValue { get; set; }
        public double? CurrentForeignRoom { get; set; }
        public double? TotalActiveBuyVolume { get; set; }
        public double? TotalActiveSellVolume { get; set; }
        public double? PricePercentChange { get; set; }
        public double? PriceChange { get; set; }
    }
}
