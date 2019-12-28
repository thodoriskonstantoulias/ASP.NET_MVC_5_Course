namespace Movie_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1d6e1e5b-b3ae-46a4-b31a-e1c9ef80cdcf', N'admin@xxx.com', 0, N'AHCPnVqRPkXMsnLr57pZo7SAY+nU3PLLDjqy+/tJ2WONSlv2dDuq5rJz9nnz3AIfYQ==', N'0244ce71-634a-411c-aba3-40b2f191afe0', NULL, 0, 0, NULL, 1, 0, N'admin@xxx.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8d5a6fcd-7ea7-4dac-9198-e32b594338ef', N'ted@gmail.com', 0, N'AJxHHg6E3ZzXvCF2zyYycismBsBByOMq5QjNnCGzreDC4+QeqIZ/vhScYwBKtWfu3Q==', N'8d74f859-7b04-4564-90e2-44030cb6aec0', NULL, 0, 0, NULL, 1, 0, N'ted@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ac349f15-52c1-4473-b5f2-40e216bb5c7c', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1d6e1e5b-b3ae-46a4-b31a-e1c9ef80cdcf', N'ac349f15-52c1-4473-b5f2-40e216bb5c7c')

");
        }
        
        public override void Down()
        {
        }
    }
}
