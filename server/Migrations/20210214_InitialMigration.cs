using FluentMigrator;

namespace Migrations
{
    [Migration(20210214121800)]
    public class InitialMigration : Migration
    {
        public override void Up()
        {

            Create.Schema("stalkmarket");

            Create.Table("villager").InSchema("stalkmarket")
                .WithColumn("id").AsGuid().PrimaryKey()
                .WithColumn("name").AsString();

            Create.Table("island").InSchema("stalkmarket")
                .WithColumn("id").AsGuid().PrimaryKey()
                .WithColumn("name").AsString()
                .WithColumn("owner_id").AsGuid()
                .WithColumn("region").AsString()
                .WithColumn("hemisphere").AsString()
                .WithColumn("purchase_tax").AsInt64().Nullable();

            Create.Table("stalk").InSchema("stalkmarket")
                .WithColumn("id").AsGuid().PrimaryKey()
                .WithColumn("date").AsDate()
                .WithColumn("meridian").AsFixedLengthString(2)
                .WithColumn("island_id").AsGuid()
                .WithColumn("entered_by").AsGuid();

            // TODO: combine these tables? 
            Create.Table("buy").InSchema("stalkmarket")
                .WithColumn("id").AsGuid().PrimaryKey()
                .WithColumn("price").AsString()
                .WithColumn("on_island").AsGuid()
                .WithColumn("buyer").AsGuid()
                .WithColumn("quantity").AsString()
                .WithColumn("buy_date").AsDateTime();

            Create.Table("sell").InSchema("stalkmarket")
                .WithColumn("id").AsGuid().PrimaryKey()
                .WithColumn("price").AsString()
                .WithColumn("on_island").AsGuid()
                .WithColumn("seller").AsGuid()
                .WithColumn("quantity").AsString()
                .WithColumn("sell_date").AsDateTime();

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

            Create.ForeignKey("buy_on_island_fk")
                .FromTable("buy").InSchema("stalkmarket")
                .ForeignColumn("on_island")
                .ToTable("island").InSchema("stalkmarket")
                .PrimaryColumn("id");

            Create.ForeignKey("buyer_fk")
                .FromTable("buy").InSchema("stalkmarket")
                .ForeignColumn("buyer")
                .ToTable("villager").InSchema("stalkmarket")
                .PrimaryColumn("id");

            Create.ForeignKey("sell_on_island_fk")
                .FromTable("sell").InSchema("stalkmarket")
                .ForeignColumn("on_island")
                .ToTable("island").InSchema("stalkmarket")
                .PrimaryColumn("id");

            Create.ForeignKey("seller_fk")
                .FromTable("sell").InSchema("stalkmarket")
                .ForeignColumn("seller")
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