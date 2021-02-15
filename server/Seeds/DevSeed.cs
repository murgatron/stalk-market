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
        }

        public override void Down()
        {
            //empty, not using
        }
    }
}