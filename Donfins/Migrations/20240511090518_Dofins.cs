using System;
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
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Exchange = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Minutes = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    TotalTrade = table.Column<double>(type: "double precision", nullable: false),
                    TotalValue = table.Column<double>(type: "double precision", nullable: false),
                    TotalVolume = table.Column<double>(type: "double precision", nullable: false),
                    PTVolume = table.Column<double>(type: "double precision", nullable: false),
                    PTValue = table.Column<double>(type: "double precision", nullable: false),
                    IndexCurrent = table.Column<double>(type: "double precision", nullable: false),
                    IndexBasic = table.Column<double>(type: "double precision", nullable: false),
                    IndexHigh = table.Column<double>(type: "double precision", nullable: false),
                    IndexLow = table.Column<double>(type: "double precision", nullable: false),
                    IndexCeiling = table.Column<double>(type: "double precision", nullable: false),
                    IndexFloor = table.Column<double>(type: "double precision", nullable: false),
                    Index1 = table.Column<double>(type: "double precision", nullable: false),
                    TotalTrade1 = table.Column<double>(type: "double precision", nullable: false),
                    TotalValue1 = table.Column<double>(type: "double precision", nullable: false),
                    TotalVolume1 = table.Column<double>(type: "double precision", nullable: false),
                    Index2 = table.Column<double>(type: "double precision", nullable: false),
                    TotalTrade2 = table.Column<double>(type: "double precision", nullable: false),
                    TotalValue2 = table.Column<double>(type: "double precision", nullable: false),
                    TotalVolume2 = table.Column<double>(type: "double precision", nullable: false),
                    Index3 = table.Column<double>(type: "double precision", nullable: false),
                    TotalTrade3 = table.Column<double>(type: "double precision", nullable: false),
                    TotalValue3 = table.Column<double>(type: "double precision", nullable: false),
                    TotalVolume3 = table.Column<double>(type: "double precision", nullable: false),
                    BuyForeignQuantity = table.Column<double>(type: "double precision", nullable: false),
                    SellForeignQuantity = table.Column<double>(type: "double precision", nullable: false),
                    BuyForeignValue = table.Column<double>(type: "double precision", nullable: false),
                    SellForeignValue = table.Column<double>(type: "double precision", nullable: false),
                    Advances = table.Column<int>(type: "integer", nullable: false),
                    Declines = table.Column<int>(type: "integer", nullable: false),
                    Unchange = table.Column<int>(type: "integer", nullable: false),
                    Traded = table.Column<int>(type: "integer", nullable: false),
                    Untraded = table.Column<int>(type: "integer", nullable: false),
                    AdvancesValue = table.Column<double>(type: "double precision", nullable: false),
                    DeclinesValue = table.Column<double>(type: "double precision", nullable: false),
                    UnchangeValue = table.Column<double>(type: "double precision", nullable: false),
                    PriceBid1 = table.Column<double>(type: "double precision", nullable: false),
                    QuantityBid1 = table.Column<double>(type: "double precision", nullable: false),
                    PriceBid2 = table.Column<double>(type: "double precision", nullable: false),
                    QuantityBid2 = table.Column<double>(type: "double precision", nullable: false),
                    PriceBid3 = table.Column<double>(type: "double precision", nullable: false),
                    QuantityBid3 = table.Column<double>(type: "double precision", nullable: false),
                    PriceAsk1 = table.Column<double>(type: "double precision", nullable: false),
                    QuantityAsk1 = table.Column<double>(type: "double precision", nullable: false),
                    PriceAsk2 = table.Column<double>(type: "double precision", nullable: false),
                    QuantityAsk2 = table.Column<double>(type: "double precision", nullable: false),
                    PriceAsk3 = table.Column<double>(type: "double precision", nullable: false),
                    QuantityAsk3 = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marketInfo", x => x.ID);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "intradayQuotes");

            migrationBuilder.DropTable(
                name: "marketInfo");

            migrationBuilder.DropTable(
                name: "quoteChanges");
        }
    }
}
