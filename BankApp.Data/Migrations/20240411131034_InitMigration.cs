using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AccountTypes",
            //    columns: table => new
            //    {
            //        AccountTypeId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AccountTypes", x => x.AccountTypeId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        CustomerId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Givenname = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Streetaddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        City = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Birthday = table.Column<DateOnly>(type: "date", nullable: true),
            //        Telephonecountrycode = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Telephonenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Emailaddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customers", x => x.CustomerId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Accounts",
            //    columns: table => new
            //    {
            //        AccountId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Created = table.Column<DateOnly>(type: "date", nullable: false),
            //        Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        AccountTypesId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Accounts", x => x.AccountId);
            //        table.ForeignKey(
            //            name: "FK_Accounts_AccountTypes_AccountTypesId",
            //            column: x => x.AccountTypesId,
            //            principalTable: "AccountTypes",
            //            principalColumn: "AccountTypeId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Dispositions",
            //    columns: table => new
            //    {
            //        DispositionId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerId = table.Column<int>(type: "int", nullable: false),
            //        AccountId = table.Column<int>(type: "int", nullable: false),
            //        Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Dispositions", x => x.DispositionId);
            //        table.ForeignKey(
            //            name: "FK_Dispositions_Accounts_AccountId",
            //            column: x => x.AccountId,
            //            principalTable: "Accounts",
            //            principalColumn: "AccountId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Dispositions_Customers_CustomerId",
            //            column: x => x.CustomerId,
            //            principalTable: "Customers",
            //            principalColumn: "CustomerId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Loans",
            //    columns: table => new
            //    {
            //        LoanId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AccountId = table.Column<int>(type: "int", nullable: false),
            //        Date = table.Column<DateOnly>(type: "date", nullable: false),
            //        Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Duration = table.Column<int>(type: "int", nullable: false),
            //        Payments = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Loans", x => x.LoanId);
            //        table.ForeignKey(
            //            name: "FK_Loans_Accounts_AccountId",
            //            column: x => x.AccountId,
            //            principalTable: "Accounts",
            //            principalColumn: "AccountId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Transactions",
            //    columns: table => new
            //    {
            //        TransactionId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AccountId = table.Column<int>(type: "int", nullable: false),
            //        Date = table.Column<DateOnly>(type: "date", nullable: false),
            //        Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Operation = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Account = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Transactions", x => x.TransactionId);
            //        table.ForeignKey(
            //            name: "FK_Transactions_Accounts_AccountId",
            //            column: x => x.AccountId,
            //            principalTable: "Accounts",
            //            principalColumn: "AccountId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Cards",
            //    columns: table => new
            //    {
            //        CardId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DispositionId = table.Column<int>(type: "int", nullable: false),
            //        Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Issued = table.Column<DateOnly>(type: "date", nullable: false),
            //        Cctype = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Ccnumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Cvv2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ExpM = table.Column<int>(type: "int", nullable: false),
            //        ExpY = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cards", x => x.CardId);
            //        table.ForeignKey(
            //            name: "FK_Cards_Dispositions_DispositionId",
            //            column: x => x.DispositionId,
            //            principalTable: "Dispositions",
            //            principalColumn: "DispositionId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Accounts_AccountTypesId",
            //    table: "Accounts",
            //    column: "AccountTypesId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cards_DispositionId",
            //    table: "Cards",
            //    column: "DispositionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Dispositions_AccountId",
            //    table: "Dispositions",
            //    column: "AccountId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Dispositions_CustomerId",
            //    table: "Dispositions",
            //    column: "CustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Loans_AccountId",
            //    table: "Loans",
            //    column: "AccountId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Transactions_AccountId",
            //    table: "Transactions",
            //    column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Dispositions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "AccountTypes");
        }
    }
}
