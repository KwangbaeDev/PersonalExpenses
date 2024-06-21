using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesExpensesCategoryandExpenseFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_ExpenseCategory_ExpenseCategoryId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseCategory_Users_UserId",
                table: "ExpenseCategory");

            migrationBuilder.RenameTable(
                name: "ExpenseCategory",
                newName: "ExpenseCategories");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Users",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "ExpenseCategories",
                newName: "IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseCategory_UserId",
                table: "ExpenseCategories",
                newName: "IX_ExpenseCategories_UserId");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Expenses",
                newName: "IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_ExpenseCategoryId",
                table: "Expenses",
                newName: "IX_Expenses_ExpenseCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseCategories_Users_UserId",
                table: "ExpenseCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseCategories_ExpenseCategoryId",
                table: "Expenses",
                column: "ExpenseCategoryId",
                principalTable: "ExpenseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseCategories_Users_UserId",
                table: "ExpenseCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseCategories_ExpenseCategoryId",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameTable(
                name: "ExpenseCategories",
                newName: "ExpenseCategory");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Users",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Expense",
                newName: "IsDelete");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_ExpenseCategoryId",
                table: "Expense",
                newName: "IX_Expense_ExpenseCategoryId");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ExpenseCategory",
                newName: "IsDelete");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseCategories_UserId",
                table: "ExpenseCategory",
                newName: "IX_ExpenseCategory_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_ExpenseCategory_ExpenseCategoryId",
                table: "Expense",
                column: "ExpenseCategoryId",
                principalTable: "ExpenseCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseCategory_Users_UserId",
                table: "ExpenseCategory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
