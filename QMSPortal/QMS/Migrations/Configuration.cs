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
            AutomaticMigrationsEnabled = false;
            ContextKey = "QMS.Models.QMS_db";
        }

        protected override void Seed(QMS.Models.QMS_db context)
        {
            context.IPs.Add(

                  new IP { Name = "Counter1", IP_Address = "192.168.1.3" }
                );
            context.Configs.Add(

                    new Config { key = "Token", Value = 1 }
                    );
            context.Users.Add(

                new User { Name = "sa", Password = "123" }
                );

            
        }
    }
}
