﻿using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Cs_razorweb.Models;

#nullable disable

namespace Cs_razorweb.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });

            
            
            Randomizer.Seed = new Random(200000);
            var fakerArticle = new Faker<Article>();
            fakerArticle.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5));
            fakerArticle.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2021, 1, 1), new DateTime(2021, 8, 4)));
            fakerArticle.RuleFor(a => a.Content, f => f.Lorem.Paragraph());

            for (int i = 0; i < 150; i++)
            {
                Article article = fakerArticle.Generate();
                migrationBuilder.InsertData(
                    table:"articles",
                    columns: new []{"Title", "Created", "Content"},
                    values: new object[]
                    {
                        article.Title,
                        article.Created,
                        article.Content
                    }
                    );
            }
            
            
            migrationBuilder.InsertData(
                table:"articles",
                columns: new []{"Title", "Created", "Content"},
                values: new object[]
                {
                    "Bai viet 1",
                    new DateTime(2021, 8, 20),
                    "Noi dung 1"
                }
                );
            
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
