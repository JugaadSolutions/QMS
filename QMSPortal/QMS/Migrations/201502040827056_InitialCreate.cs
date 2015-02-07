namespace QMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        key = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IP_Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientName = c.String(nullable: false),
                        PatientId = c.Int(nullable: false),
                        Status = c.String(),
                        IP = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        Token = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateStoredProcedure(
                "dbo.Patient_Insert",
                p => new
                    {
                        PatientName = p.String(),
                        PatientId = p.Int(),
                        Status = p.String(),
                        IP = p.String(),
                        TimeStamp = p.DateTime(),
                        Token = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Patients]([PatientName], [PatientId], [Status], [IP], [TimeStamp], [Token])
                      VALUES (@PatientName, @PatientId, @Status, @IP, @TimeStamp, @Token)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Patients]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Patients] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Patient_Update",
                p => new
                    {
                        Id = p.Int(),
                        PatientName = p.String(),
                        PatientId = p.Int(),
                        Status = p.String(),
                        IP = p.String(),
                        TimeStamp = p.DateTime(),
                        Token = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Patients]
                      SET [PatientName] = @PatientName, [PatientId] = @PatientId, [Status] = @Status, [IP] = @IP, [TimeStamp] = @TimeStamp, [Token] = @Token
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Patient_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Patients]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Patient_Delete");
            DropStoredProcedure("dbo.Patient_Update");
            DropStoredProcedure("dbo.Patient_Insert");
            DropTable("dbo.Users");
            DropTable("dbo.Patients");
            DropTable("dbo.IPs");
            DropTable("dbo.Configs");
        }
    }
}
