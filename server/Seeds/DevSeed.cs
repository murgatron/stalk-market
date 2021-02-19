using System;
using Enums;
using FluentMigrator;

namespace Seeds.DevSeed
{
  [Profile("Development")]
  public class DevSeed : Migration
  {
    public override void Up()
    {

      var murgId = Guid.NewGuid();
      var teatimeId = Guid.NewGuid();

      Insert.IntoTable("villager")
      .InSchema("stalkmarket")
      .Row(new
      {
        id = murgId,
        name = "Murg"
      });

      Insert.IntoTable("island")
      .InSchema("stalkmarket")
      .Row(new
      {
        id = teatimeId,
        name = "Teatime",
        owner_id = murgId,
        hemisphere = "North",
        region = "NA"
      });

      Insert.IntoTable("stalk_transaction")
      .InSchema("stalkmarket")
      .Row(new
      {
        id = Guid.NewGuid(),
        price = 92,
        on_island = teatimeId,
        type = TransactionType.Buy,
        villager_id = murgId,
        quantity = 300,
        timestamp = DateTime.Parse("2021-02-13T17:51:42+0000")
      });

      Insert.IntoTable("stalk")
      .InSchema("stalkmarket")
      .Row(new
      {
        id = Guid.NewGuid(),
        island_id = teatimeId,
        meridian = Meridian.AM,
        shop_price = 102,
        date = DateTime.Parse("2021-02-15T00:00:00+0000"),
        entered_by = murgId
      });

      Insert.IntoTable("stalk")
      .InSchema("stalkmarket")
      .Row(new
      {
        id = Guid.NewGuid(),
        island_id = teatimeId,
        meridian = Meridian.PM,
        shop_price = 96,
        date = DateTime.Parse("2021-02-15T00:00:00+0000"),
        entered_by = murgId
      });

      Insert.IntoTable("stalk")
      .InSchema("stalkmarket")
      .Row(new
      {
        id = Guid.NewGuid(),
        island_id = teatimeId,
        meridian = Meridian.AM,
        shop_price = 60,
        date = DateTime.Parse("2021-02-16T00:00:00+0000"),
        entered_by = murgId
      });

      Insert.IntoTable("stalk")
      .InSchema("stalkmarket")
      .Row(new
      {
        id = Guid.NewGuid(),
        island_id = teatimeId,
        meridian = Meridian.PM,
        shop_price = 53,
        date = DateTime.Parse("2021-02-16T00:00:00+0000"),
        entered_by = murgId
      });

      Insert.IntoTable("stalk")
      .InSchema("stalkmarket")
      .Row(new
      {
        id = Guid.NewGuid(),
        island_id = teatimeId,
        meridian = Meridian.AM,
        shop_price = 103,
        date = DateTime.Parse("2021-02-17T00:00:00+0000"),
        entered_by = murgId
      });

      Insert.IntoTable("stalk")
      .InSchema("stalkmarket")
      .Row(new
      {
        id = Guid.NewGuid(),
        island_id = teatimeId,
        meridian = Meridian.PM,
        shop_price = 96,
        date = DateTime.Parse("2021-02-17T00:00:00+0000"),
        entered_by = murgId
      });

      Insert.IntoTable("stalk")
      .InSchema("stalkmarket")
      .Row(new
      {
        id = Guid.NewGuid(),
        island_id = teatimeId,
        meridian = Meridian.AM,
        shop_price = 126,
        date = DateTime.Parse("2021-02-18T00:00:00+0000"),
        entered_by = murgId
      });

      Insert.IntoTable("stalk_transaction")
      .InSchema("stalkmarket")
      .Row(new
      {
        id = Guid.NewGuid(),
        price = 126,
        on_island = teatimeId,
        type = TransactionType.Sell,
        villager_id = murgId,
        quantity = 300,
        timestamp = DateTime.Parse("2021-02-18T10:52:42+0000")
      });

      Insert.IntoTable("stalk")
      .InSchema("stalkmarket")
      .Row(new
      {
        id = Guid.NewGuid(),
        island_id = teatimeId,
        meridian = Meridian.PM,
        shop_price = 102,
        date = DateTime.Parse("2021-02-18T00:00:00+0000"),
        entered_by = murgId
      });
    }

    public override void Down()
    {
      //empty, not using
    }
  }
}