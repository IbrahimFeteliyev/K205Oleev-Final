using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CaseStudies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStudies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CountDowns",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountDowns", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Infos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHeader = table.Column<bool>(type: "bit", nullable: false),
                    IsSlider = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OurExpertises",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurExpertises", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OurServices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurServices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OurTestimonials",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurTestimonials", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AboutLanguages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutLanguages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AboutLanguages_Abouts_AboutID",
                        column: x => x.AboutID,
                        principalTable: "Abouts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleLanguages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleLanguages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArticleLanguages_Articles_ArticleID",
                        column: x => x.ArticleID,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseStudyLanguages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseStudyID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStudyLanguages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CaseStudyLanguages_CaseStudies_CaseStudyID",
                        column: x => x.CaseStudyID,
                        principalTable: "CaseStudies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountDownLanguages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountDownID = table.Column<int>(type: "int", nullable: false),
                    SEO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountDownLanguages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CountDownLanguages_CountDowns_CountDownID",
                        column: x => x.CountDownID,
                        principalTable: "CountDowns",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfoLanguages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InfoID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoLanguages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InfoLanguages_Infos_InfoID",
                        column: x => x.InfoID,
                        principalTable: "Infos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OurExpertiseLanguages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OurExpertiseID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurExpertiseLanguages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OurExpertiseLanguages_OurExpertises_OurExpertiseID",
                        column: x => x.OurExpertiseID,
                        principalTable: "OurExpertises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OurServiceLanguages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OurServiceID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurServiceLanguages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OurServiceLanguages_OurServices_OurServiceID",
                        column: x => x.OurServiceID,
                        principalTable: "OurServices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OurTestimonialLanguages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OurTestimonialID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurTestimonialLanguages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OurTestimonialLanguages_OurTestimonials_OurTestimonialID",
                        column: x => x.OurTestimonialID,
                        principalTable: "OurTestimonials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutLanguages_AboutID",
                table: "AboutLanguages",
                column: "AboutID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleLanguages_ArticleID",
                table: "ArticleLanguages",
                column: "ArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseStudyLanguages_CaseStudyID",
                table: "CaseStudyLanguages",
                column: "CaseStudyID");

            migrationBuilder.CreateIndex(
                name: "IX_CountDownLanguages_CountDownID",
                table: "CountDownLanguages",
                column: "CountDownID");

            migrationBuilder.CreateIndex(
                name: "IX_InfoLanguages_InfoID",
                table: "InfoLanguages",
                column: "InfoID");

            migrationBuilder.CreateIndex(
                name: "IX_OurExpertiseLanguages_OurExpertiseID",
                table: "OurExpertiseLanguages",
                column: "OurExpertiseID");

            migrationBuilder.CreateIndex(
                name: "IX_OurServiceLanguages_OurServiceID",
                table: "OurServiceLanguages",
                column: "OurServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_OurTestimonialLanguages_OurTestimonialID",
                table: "OurTestimonialLanguages",
                column: "OurTestimonialID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutLanguages");

            migrationBuilder.DropTable(
                name: "ArticleLanguages");

            migrationBuilder.DropTable(
                name: "CaseStudyLanguages");

            migrationBuilder.DropTable(
                name: "CountDownLanguages");

            migrationBuilder.DropTable(
                name: "InfoLanguages");

            migrationBuilder.DropTable(
                name: "OurExpertiseLanguages");

            migrationBuilder.DropTable(
                name: "OurServiceLanguages");

            migrationBuilder.DropTable(
                name: "OurTestimonialLanguages");

            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "CaseStudies");

            migrationBuilder.DropTable(
                name: "CountDowns");

            migrationBuilder.DropTable(
                name: "Infos");

            migrationBuilder.DropTable(
                name: "OurExpertises");

            migrationBuilder.DropTable(
                name: "OurServices");

            migrationBuilder.DropTable(
                name: "OurTestimonials");
        }
    }
}
