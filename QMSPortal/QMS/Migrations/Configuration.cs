namespace QMS.Migrations
{
    using QMS.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QMS.Models.QMS_db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "QMS.Models.QMS_db";
        }

        //protected override void Seed(QMS.Models.QMS_db context)
        //{
        //    context.Database.ExecuteSqlCommand("TRUNCATE TABLE IPs ");
        //    context.IPs.AddOrUpdate(i => i.IP_Address,

        //          new IP { Name = "Counter1", IP_Address = "192.168.1.1" },
        //          new IP { Name = "Counter2", IP_Address = "192.168.1.2" },
        //          new IP { Name = "Counter3", IP_Address = "192.168.1.3" },
        //          new IP { Name = "Counter4", IP_Address = "192.168.1.4" },
        //          new IP { Name = "Counter5", IP_Address = "192.168.1.5" },
        //          new IP { Name = "Counter6", IP_Address = "192.168.1.6" }
        //        );
        //    context.Users.AddOrUpdate(u => u.Name,

        //        new User { Name = "sa", Password = "123" }
        //        );
        //    var token =from r in context.Configs
        //             select r.Value;
        //    foreach(var item in token)
        //    {
        //        return;
                
        //    }
        //    context.Configs.AddOrUpdate(t => t.Id,

        //            new Config { Id = 1, key = "Token", Value = 1 }
        //                );
                


        //}
    }
}
