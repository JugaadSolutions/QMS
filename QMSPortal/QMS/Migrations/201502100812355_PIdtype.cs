namespace QMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PIdtype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "PatientId", c => c.String(nullable: false));
            AlterStoredProcedure(
                "dbo.RegisterPatient",
                p => new
                    {
                        PatientName = p.String(),
                        PatientId = p.String(),
                        Status = p.String(),
                        IP = p.String(),
                        TimeStamp = p.DateTime(),
                        Token = p.Int(),
                    },
                body:
                    @" Select @Token = Value from Configs
                      INSERT [dbo].[Patients]([PatientName], [PatientId], [Status], [IP], [TimeStamp], [Token])
                      VALUES (@PatientName, @PatientId, @Status, @IP, @TimeStamp, @Token)
                      
                       
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Patients]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Patients] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id
                      
                      Update Configs set value = value +1"
            );
            
            AlterStoredProcedure(
                "dbo.Patient_Update",
                p => new
                    {
                        Id = p.Int(),
                        PatientName = p.String(),
                        PatientId = p.String(),
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
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "PatientId", c => c.Int(nullable: false));
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
