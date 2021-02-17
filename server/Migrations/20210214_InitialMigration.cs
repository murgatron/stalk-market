using System;
using FluentMigrator;

namespace Migrations
{
  [Migration(20210214121800)]
  public class InitialMigration : Migration
  {
    public override void Up()
    {
      // for great good
      Execute.Sql("create extension if not exists \"uuid-ossp\";");

      // TODO unique constraints
      Create.Schema("stalkmarket");

      Create.Table("villager").InSchema("stalkmarket")
          .WithColumn("id").AsGuid().PrimaryKey().WithDefaultValue(SystemMethods.NewGuid)
          .WithColumn("name").AsString();

      Create.Table("island").InSchema("stalkmarket")
          .WithColumn("id").AsGuid().PrimaryKey().WithDefaultValue(SystemMethods.NewGuid)
          .WithColumn("name").AsString()
          .WithColumn("owner_id").AsGuid()
          .WithColumn("region").AsString()
          .WithColumn("hemisphere").AsString()
          .WithColumn("sales_tax").AsInt64().Nullable();

      // needs unique constraint by meridian, islandid, datetime
      Create.Table("stalk").InSchema("stalkmarket")
                .WithColumn("id").AsGuid().PrimaryKey().WithDefaultValue(SystemMethods.NewGuid)
                .WithColumn("date").AsDate()
                .WithColumn("shop_price").AsString()
                .WithColumn("meridian").AsFixedLengthString(2)
                .WithColumn("island_id").AsGuid()
                .WithColumn("entered_by").AsGuid();

      // needs unique constraint by ? type, villager, timestamp?
      Create.Table("stalk_transaction").InSchema("stalkmarket")
                .WithColumn("id").AsGuid().PrimaryKey().WithDefaultValue(SystemMethods.NewGuid)
                .WithColumn("price").AsString()
                .WithColumn("on_island").AsGuid()
                .WithColumn("type").AsString()
                .WithColumn("villager_id").AsGuid()
                .WithColumn("quantity").AsString()
                .WithColumn("timestamp").AsDateTime();

      // Ignore activity for now

      Create.ForeignKey("island_owner_id_fk")
          .FromTable("island").InSchema("stalkmarket")
          .ForeignColumn("owner_id")
          .ToTable("villager").InSchema("stalkmarket")
          .PrimaryColumn("id");

      Create.ForeignKey("island_id_fk")
          .FromTable("stalk").InSchema("stalkmarket")
          .ForeignColumn("island_id")
          .ToTable("island").InSchema("stalkmarket")
          .PrimaryColumn("id");

      Create.ForeignKey("price_entered_by_fk")
          .FromTable("stalk").InSchema("stalkmarket")
          .ForeignColumn("entered_by")
          .ToTable("villager").InSchema("stalkmarket")
          .PrimaryColumn("id");

      Create.ForeignKey("transaction_on_island_fk")
          .FromTable("stalk_transaction").InSchema("stalkmarket")
          .ForeignColumn("on_island")
          .ToTable("island").InSchema("stalkmarket")
          .PrimaryColumn("id");

      Create.ForeignKey("transaction_villager_id_fk")
          .FromTable("stalk_transaction").InSchema("stalkmarket")
          .ForeignColumn("villager_id")
          .ToTable("villager").InSchema("stalkmarket")
          .PrimaryColumn("id");
    }

    public override void Down()
    {
      // TODO lol
      Delete.Table("villager").InSchema("stalkmarket");
    }
  }
}