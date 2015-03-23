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

        protected override void Seed(QMS.Models.QMS_db context)
        {
            context.IPs.AddOrUpdate(i=>i.IP_Address,

                  new IP { Name = "Counter1", IP_Address = "192.168.1.4" },
                  new IP { Name = "Counter2", IP_Address = "192.168.1.108" },
                  new IP { Name = "Counter3", IP_Address = "116.202.114.159" }
                );
            context.Configs.AddOrUpdate(t=>t.key,
                new Config { key = "Token", Value = 1 }
                    );
                
            context.Users.AddOrUpdate(u=>u.Name,

                new User { Name = "sa", Password = "123" }
                );

            
        }
    }
}
