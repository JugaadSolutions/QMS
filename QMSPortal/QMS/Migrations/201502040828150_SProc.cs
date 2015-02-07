namespace QMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SProc : DbMigration
    {
        public override void Up()
        {
            RenameStoredProcedure(name: "dbo.Patient_Insert", newName: "RegisterPatient");
            AlterStoredProcedure(
               "dbo.RegisterPatient",
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
                      
                      Update Configs set value = value +1
                       "
           );
            
        }
        
        public override void Down()
        {
            RenameStoredProcedure(name: "dbo.RegisterPatient", newName: "Patient_Insert");
        }
    }
}
