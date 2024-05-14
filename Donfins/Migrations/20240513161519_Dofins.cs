using System;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dofins.Migrations
{
    public partial class Dofins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "intradayQuotes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Volume = table.Column<double>(type: "double precision", nullable: false),
                    TotalVolume = table.Column<double>(type: "double precision", nullable: false),
                    Side = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_intradayQuotes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "marketInfo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Exchange = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Minutes = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    TotalTrade = table.Column<double>(type: "double precision", nullable: true),
                    TotalValue = table.Column<double>(type: "double precision", nullable: true),
                    TotalVolume = table.Column<double>(type: "double precision", nullable: true),
                    PTVolume = table.Column<double>(type: "double precision", nullable: true),
                    PTValue = table.Column<double>(type: "double precision", nullable: true),
                    IndexCurrent = table.Column<double>(type: "double precision", nullable: true),
                    IndexBasic = table.Column<double>(type: "double precision", nullable: true),
                    IndexHigh = table.Column<double>(type: "double precision", nullable: true),
                    IndexLow = table.Column<double>(type: "double precision", nullable: true),
                    IndexCeiling = table.Column<double>(type: "double precision", nullable: true),
                    IndexFloor = table.Column<double>(type: "double precision", nullable: true),
                    Index1 = table.Column<double>(type: "double precision", nullable: true),
                    TotalTrade1 = table.Column<double>(type: "double precision", nullable: true),
                    TotalValue1 = table.Column<double>(type: "double precision", nullable: true),
                    TotalVolume1 = table.Column<double>(type: "double precision", nullable: true),
                    Index2 = table.Column<double>(type: "double precision", nullable: true),
                    TotalTrade2 = table.Column<double>(type: "double precision", nullable: true),
                    TotalValue2 = table.Column<double>(type: "double precision", nullable: true),
                    TotalVolume2 = table.Column<double>(type: "double precision", nullable: true),
                    Index3 = table.Column<double>(type: "double precision", nullable: true),
                    TotalTrade3 = table.Column<double>(type: "double precision", nullable: true),
                    TotalValue3 = table.Column<double>(type: "double precision", nullable: true),
                    TotalVolume3 = table.Column<double>(type: "double precision", nullable: true),
                    BuyForeignQuantity = table.Column<double>(type: "double precision", nullable: true),
                    SellForeignQuantity = table.Column<double>(type: "double precision", nullable: true),
                    BuyForeignValue = table.Column<double>(type: "double precision", nullable: true),
                    SellForeignValue = table.Column<double>(type: "double precision", nullable: true),
                    Advances = table.Column<int>(type: "integer", nullable: true),
                    Declines = table.Column<int>(type: "integer", nullable: true),
                    Unchange = table.Column<int>(type: "integer", nullable: true),
                    Traded = table.Column<int>(type: "integer", nullable: true),
                    Untraded = table.Column<int>(type: "integer", nullable: true),
                    AdvancesValue = table.Column<double>(type: "double precision", nullable: true),
                    DeclinesValue = table.Column<double>(type: "double precision", nullable: true),
                    UnchangeValue = table.Column<double>(type: "double precision", nullable: true),
                    PriceBid1 = table.Column<double>(type: "double precision", nullable: true),
                    QuantityBid1 = table.Column<double>(type: "double precision", nullable: true),
                    PriceBid2 = table.Column<double>(type: "double precision", nullable: true),
                    QuantityBid2 = table.Column<double>(type: "double precision", nullable: true),
                    PriceBid3 = table.Column<double>(type: "double precision", nullable: true),
                    QuantityBid3 = table.Column<double>(type: "double precision", nullable: true),
                    PriceAsk1 = table.Column<double>(type: "double precision", nullable: true),
                    QuantityAsk1 = table.Column<double>(type: "double precision", nullable: true),
                    PriceAsk2 = table.Column<double>(type: "double precision", nullable: true),
                    QuantityAsk2 = table.Column<double>(type: "double precision", nullable: true),
                    PriceAsk3 = table.Column<double>(type: "double precision", nullable: true),
                    QuantityAsk3 = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marketInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quoteChanges",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Exchange = table.Column<string>(type: "text", nullable: false),
                    PriceBasic = table.Column<double>(type: "double precision", nullable: true),
                    PriceCeiling = table.Column<double>(type: "double precision", nullable: true),
                    PriceFloor = table.Column<double>(type: "double precision", nullable: true),
                    PriceCurrent = table.Column<double>(type: "double precision", nullable: true),
                    PriceLast = table.Column<double>(type: "double precision", nullable: true),
                    PriceHigh = table.Column<double>(type: "double precision", nullable: true),
                    PriceLow = table.Column<double>(type: "double precision", nullable: true),
                    PriceOpen = table.Column<double>(type: "double precision", nullable: true),
                    PriceClose = table.Column<double>(type: "double precision", nullable: true),
                    PriceAverage = table.Column<double>(type: "double precision", nullable: true),
                    TotalVolume = table.Column<double>(type: "double precision", nullable: true),
                    Volume = table.Column<double>(type: "double precision", nullable: true),
                    TotalTrade = table.Column<double>(type: "double precision", nullable: true),
                    TotalValue = table.Column<double>(type: "double precision", nullable: true),
                    PriceBid1 = table.Column<double>(type: "double precision", nullable: true),
                    QuantityBid1 = table.Column<double>(type: "double precision", nullable: true),
                    PriceBid2 = table.Column<double>(type: "double precision", nullable: true),
                    QuantityBid2 = table.Column<double>(type: "double precision", nullable: true),
                    PriceBid3 = table.Column<double>(type: "double precision", nullable: true),
                    QuantityBid3 = table.Column<double>(type: "double precision", nullable: true),
                    PriceAsk1 = table.Column<double>(type: "double precision", nullable: true),
                    QuantityAsk1 = table.Column<double>(type: "double precision", nullable: true),
                    PriceAsk2 = table.Column<double>(type: "double precision", nullable: true),
                    QuantityAsk2 = table.Column<double>(type: "double precision", nullable: true),
                    PriceAsk3 = table.Column<double>(type: "double precision", nullable: true),
                    QuantityAsk3 = table.Column<double>(type: "double precision", nullable: true),
                    BuyCount = table.Column<double>(type: "double precision", nullable: true),
                    SellCount = table.Column<double>(type: "double precision", nullable: true),
                    BuyQuantity = table.Column<double>(type: "double precision", nullable: true),
                    SellQuantity = table.Column<double>(type: "double precision", nullable: true),
                    BuyForeignQuantity = table.Column<double>(type: "double precision", nullable: true),
                    SellForeignQuantity = table.Column<double>(type: "double precision", nullable: true),
                    BuyForeignValue = table.Column<double>(type: "double precision", nullable: true),
                    SellForeignValue = table.Column<double>(type: "double precision", nullable: true),
                    CurrentForeignRoom = table.Column<double>(type: "double precision", nullable: true),
                    TotalActiveBuyVolume = table.Column<double>(type: "double precision", nullable: true),
                    TotalActiveSellVolume = table.Column<double>(type: "double precision", nullable: true),
                    PricePercentChange = table.Column<double>(type: "double precision", nullable: true),
                    PriceChange = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quoteChanges", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tickers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Company = table.Column<string>(type: "text", nullable: true),
                    Exchange = table.Column<string>(type: "text", nullable: false),
                    Industry = table.Column<string>(type: "text", nullable: true),
                    RiskGroup = table.Column<string>(type: "text", nullable: true),
                    StockSize = table.Column<string>(type: "text", nullable: true),
                    PiorityLevel = table.Column<string>(type: "text", nullable: true),
                    AdjustmentCoefficent = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dailyInfors",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tickersId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ShareOutStanding = table.Column<BigInteger>(type: "numeric", nullable: false),
                    FreeShare = table.Column<BigInteger>(type: "numeric", nullable: false),
                    MarketCap = table.Column<BigInteger>(type: "numeric", nullable: false),
                    High = table.Column<double>(type: "double precision", nullable: false),
                    Low = table.Column<double>(type: "double precision", nullable: false),
                    Open = table.Column<double>(type: "double precision", nullable: false),
                    Close = table.Column<double>(type: "double precision", nullable: false),
                    Average = table.Column<double>(type: "double precision", nullable: false),
                    Volume = table.Column<BigInteger>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dailyInfors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dailyInfors_tickers_tickersId",
                        column: x => x.tickersId,
                        principalTable: "tickers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dailyInfors_tickersId",
                table: "dailyInfors",
                column: "tickersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dailyInfors");

            migrationBuilder.DropTable(
                name: "intradayQuotes");

            migrationBuilder.DropTable(
                name: "marketInfo");

            migrationBuilder.DropTable(
                name: "quoteChanges");

            migrationBuilder.DropTable(
                name: "tickers");
        }
    }
}
