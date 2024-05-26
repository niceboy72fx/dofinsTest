
using Dofins.Interfaces;
using Dofins.Models;

namespace Dofins.Services
{
    public class RealtimeServices : IRealtime
    {


        string[] symbols = new string[]
         {
            "CTG", "BID", "VCB", "VIB", "MBB", "TCB", "TPB", "HDB", "STB", "EIB",
            "VIB", "ACB", "MSB", "NCB", "LPB", "NAB", "PGB", "ABB", "BAB", "KLB",
            "VBB", "BVB", "SHB", "SGB"
         };


        public List<QuoteChanges> FilterStockByDate(List<QuoteChanges> stockFilter)
        {
            foreach (var stock in symbols)
            {
                Random random = new Random();
                DateTime localDate = DateTime.Now.AddYears(-1).AddDays(random.Next(365));
                double? priceBasic = random.NextDouble() * 100;
                double? priceCeiling = random.NextDouble() * 100;
                double? priceFloor = random.NextDouble() * 100;
                double? priceCurrent = random.NextDouble() * 100;
                double? priceLast = random.NextDouble() * 100;
                double? priceHigh = random.NextDouble() * 100;
                double? priceLow = random.NextDouble() * 100;
                double? priceOpen = random.NextDouble() * 100;
                double? priceClose = random.NextDouble() * 100;
                double? priceAverage = random.NextDouble() * 100;
                double? totalVolume = random.NextDouble() * 100;
                double? volume = random.NextDouble() * 100;
                double? totalTrade = random.NextDouble() * 100;
                double? totalValue = random.NextDouble() * 100;
                double? priceBid1 = random.NextDouble() * 100;
                double? quantityBid1 = random.NextDouble() * 100;
                double? priceBid2 = random.NextDouble() * 100;
                double? quantityBid2 = random.NextDouble() * 100;
                double? priceBid3 = random.NextDouble() * 100;
                double? quantityBid3 = random.NextDouble() * 100;
                double? priceAsk1 = random.NextDouble() * 100;
                double? quantityAsk1 = random.NextDouble() * 100;
                double? priceAsk2 = random.NextDouble() * 100;
                double? quantityAsk2 = random.NextDouble() * 100;
                double? priceAsk3 = random.NextDouble() * 100;
                double? quantityAsk3 = random.NextDouble() * 100;
                double? buyCount = random.NextDouble() * 100;
                double? sellCount = random.NextDouble() * 100;
                double? buyQuantity = random.NextDouble() * 100;
                double? sellQuantity = random.NextDouble() * 100;
                double? buyForeignQuantity = random.NextDouble() * 100;
                double? sellForeignQuantity = random.NextDouble() * 100;
                double? buyForeignValue = random.NextDouble() * 100;
                double? sellForeignValue = random.NextDouble() * 100;
                double? currentForeignRoom = random.NextDouble() * 100;
                double? totalActiveBuyVolume = random.NextDouble() * 100;
                double? totalActiveSellVolume = random.NextDouble() * 100;
                double? pricePercentChange = random.NextDouble() * 100;
                double? priceChange = random.NextDouble() * 100;
                QuoteChanges quoteChanges = new QuoteChanges(iD: 1,
                    date: localDate,
                    symbol: stock,
                    name: "Company ABC",
                    type: "Com",
                    exchange: "HOSE",
                    priceBasic: priceBasic,
                    priceCeiling: priceCeiling,
                    priceFloor: priceFloor,
                    priceCurrent: priceCurrent,
                    priceLast: priceLast,
                    priceHigh: priceHigh,
                    priceLow: priceLow,
                    priceOpen: priceOpen,
                    priceClose: priceClose,
                    priceAverage: priceAverage,
                    totalVolume: totalVolume,
                    volume: volume,
                    totalTrade: totalTrade,
                    totalValue: totalValue,
                    priceBid1: priceBid1,
                    quantityBid1: quantityBid1,
                    priceBid2: priceBid2,
                    quantityBid2: quantityBid2,
                    priceBid3: priceBid3,
                    quantityBid3: quantityBid3,
                    priceAsk1: priceAsk1,
                    quantityAsk1: quantityAsk1,
                    priceAsk2: priceAsk2,
                    quantityAsk2: quantityAsk2,
                    priceAsk3: priceAsk3,
                    quantityAsk3: quantityAsk3,
                    buyCount: buyCount,
                    sellCount: sellCount,
                    buyQuantity: buyQuantity,
                    sellQuantity: sellQuantity,
                    buyForeignQuantity: buyForeignQuantity,
                    sellForeignQuantity: sellForeignQuantity,
                    buyForeignValue: buyForeignValue,
                    sellForeignValue: sellForeignValue,
                    currentForeignRoom: currentForeignRoom,
                    totalActiveBuyVolume: totalActiveBuyVolume,
                    totalActiveSellVolume: totalActiveSellVolume,
                    pricePercentChange: pricePercentChange,
                    priceChange: priceChange
                );
                stockFilter.Add(quoteChanges);
            }

            return stockFilter;
        }
    }
}
