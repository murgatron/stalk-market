using System;
using FluentMigrator;


namespace Seeds.DevSeed
{
    [Profile("Development")]
    public class DevSeed : Migration
    {
        public override void Up()
        {
            var murgId = new Guid();
            var teatimeId = new Guid();

            Insert.IntoTable("villager").Row(new
            {
                Id = murgId,
                Name = "Murg"
            });

            Insert.IntoTable("island").Row(new
            {
                Id = teatimeId,
                Name = "Teatime",
                OwnerId = murgId,
                Hemisphere = "North",
                Region = "NA"
            });

            Insert.IntoTable("buy").Row(new
            {
                Id = new Guid(),
                Price = 92,
                OnIsland = teatimeId,
                Buyer = murgId,
                Quantity = 300,
                BuyDate = DateTime.Parse("2021-02-13T17:51:42+0000")
            });
        }

        public override void Down()
        {
            //empty, not using
        }
    }
}