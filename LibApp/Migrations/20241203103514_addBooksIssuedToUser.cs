﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibApp.Migrations
{
    /// <inheritdoc />
    public partial class addBooksIssuedToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BooksIssued",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BooksIssued",
                table: "AspNetUsers");
        }
    }
}
