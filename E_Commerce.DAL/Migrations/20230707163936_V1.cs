using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.ProductId, x.CartId, x.Size, x.Color });
                    table.ForeignKey(
                        name: "FK_CartProduct_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => new { x.ProductID, x.ImageURL });
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsInfo",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsInfo", x => new { x.ProductID, x.Color, x.Size });
                    table.ForeignKey(
                        name: "FK_ProductsInfo_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WishListID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CartID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NameOnCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MidName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_WishLists_WishListID",
                        column: x => x.WishListID,
                        principalTable: "WishLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductWishList",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishListsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWishList", x => new { x.ProductsId, x.WishListsId });
                    table.ForeignKey(
                        name: "FK_ProductWishList_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWishList_WishLists_WishListsId",
                        column: x => x.WishListsId,
                        principalTable: "WishLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersReviews",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersReviews", x => new { x.ProductId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomersReviews_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.ProductId, x.OrderId, x.Color, x.Size });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardNumber", "CartID", "City", "ConcurrencyStamp", "Country", "Discriminator", "Email", "EmailConfirmed", "ExpireDate", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MidName", "NameOnCard", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName", "WishListID" },
                values: new object[,]
                {
                    { "07d96ed8-155d-49c7-a77a-615f109d77c3", 0, 1234567890123456m, null, "New York", "9ab4f8bc-3c46-4ddd-b0e8-eb9f5d5e2276", "Ukraine", "Customer", "johndoe@example.com", false, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe", false, null, "E", " John E Doe", null, null, null, "123-456-7890", false, "User", "7172ebe3-67ce-4102-8684-824aa5dbe1bd", "123 Main St", false, null, null },
                    { "0e67a2e5-df53-4a92-9854-8e1ad46a4e61", 0, 5432101234567890m, null, "Paris", "842693d2-3212-47ea-98a4-ea923b543918", "France", "Customer", "oliviabrown@example.com", false, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivia", "Brown", false, null, "N", "Olivia N Brown", null, null, null, "888-777-6666", false, "User", "57648648-5797-4a47-be67-4345302cea53", "123 Cherry St", false, null, null },
                    { "22ac8dc9-4385-48ae-90a3-7d8c898c6d5d", 0, 1234554321098765m, null, "Seoul", "19801049-febe-42c1-a7db-f63312c3d2c4", "Serbia", "Customer", "sophialee@example.com", false, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia", "Lee", false, null, "K", "Sophia K Lee", null, null, null, "222-333-4444", false, "User", "a068607c-6951-49a4-b913-8e68d3064563", "456 Cedar St", false, null, null },
                    { "23456789-01ab-cdef-0123-456789abcdef", 0, 5432109876543210m, null, "Madrid", "ee6962df-6de0-4f51-a663-dd88260f41b5", "Spain", "Customer", "isabellatmartinez@example.com", false, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isabella", "Martinez", false, null, "T", "Isabella T Martinez", null, null, null, "888-777-6666", false, "User", "c712b157-d3cb-4759-8d64-0469bb99699a", "123 Cherry St", false, null, null },
                    { "2345cdef-0123-4567-89ab-cdef01234567", 0, 1234554321098765m, null, "Seattle", "7f672fe2-0777-47c2-a104-fcfd488315d4", "Kiribati", "Customer", "noahajohnson@example.com", false, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noah", "Johnson", false, null, "A", "Noah A Johnson", null, null, null, "222-333-4444", false, "User", "669e3682-60c6-4e3a-8d8e-fcb1d089313c", "456 Cedar St", false, null, null },
                    { "234cdf89-12a3-45b6-789c-0123456789de", 0, 9876543298765432m, null, "New York", "4cdadc86-7d78-45ac-9b44-d42c918152b7", "Bangladesh", "Customer", "emmajdavis@example.com", false, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma", "Davis", false, null, "J", "Emma J Davis", null, null, null, "444-555-6666", false, "User", "fbcbc93b-b641-4f3b-96a1-21e6c1cdf5d7", "456 Maple Ave", false, null, null },
                    { "456789ab-cdef-0123-4567-89abcdef0123", 0, 5432167890123456m, null, "Rome", "a2bf746d-0bf8-41a9-888e-ba951c2aa403", "Italy", "Customer", "miasjohnson@example.com", false, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mia", "Johnson", false, null, "S", "Mia S Johnson", null, null, null, "777-888-9999", false, "User", "11ba8ad3-5e00-40b6-9d08-9c83d196e3fb", "789 Oak St", false, null, null },
                    { "56789abc-def0-1234-5678-9abcdef01234", 0, 1234987654321098m, null, "Tokyo", "4fff0a1f-9e4e-4596-b023-c2a05b60415b", "Japan", "Customer", "logantmartinez@example.com", false, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Logan", "Martinez", false, null, "T", "Logan T Martinez", null, null, null, "555-666-7777", false, "User", "0be9eeb3-9269-4e35-82c2-22522032c89d", "123 Walnut Ave", false, null, null },
                    { "6789abcd-ef01-2345-6789-abcd01234567", 0, 1234987654321098m, null, "Los Angeles", "d84dde9a-807a-46df-9697-a39931fcaeb1", "Somalia", "Customer", "liammwilson@example.com", false, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liam", "Wilson", false, null, "M", "Liam M Wilson", null, null, null, "777-888-9999", false, "User", "fccddce7-d6fc-4913-b657-cfc0e2f305ed", "789 Oak St", false, null, null },
                    { "724587e6-9314-4fe6-9c3e-6fd612f50234", 0, 1234567812345678m, null, "London", "32e6475d-1db9-4410-8b86-7b9c9050638d", "Andorra", "Customer", "williamtaylor@example.com", false, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "Taylor", false, null, "G", "William G Taylor", null, null, null, "111-222-3333", false, "User", "b8de63af-28bc-4a5d-9a01-9388ad20d101", "123 Elm St", false, null, null },
                    { "74f5b2b3-3d10-4a85-93b5-8c6d0c992b58", 0, 5432167890123456m, null, "Chicago", "41751d07-a523-427e-81bd-bc421f954d65", "Zimbabwe", "Customer", "alexjohnson@example.com", false, new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "Johnson", false, null, "S", " Alex S Johnson", null, null, null, "777-888-666", false, "User", "d325d67a-c3b8-4dba-b570-9c8256acf2b1", "789 Oak St", false, null, null },
                    { "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb7", 0, 9876543210123456m, null, "San Francisco", "6f0999fe-02fc-4d37-b6be-bc36b4a08b1d", "Australia", "Customer", "emilyanderson@example.com", false, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "Anderson", false, null, "R", "Emily R Anderson", null, null, null, "111-222-3333", false, "User", "0bcf2f6f-bac2-446e-ba8b-1d9d83cabb7c", "789 Elm St", false, null, null },
                    { "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb8", 0, 1234987654321098m, null, "London", "a3e3cbbc-754c-496e-aa2e-ca3a2edb7465", "Albania", "Customer", "michaelwilson@example.com", false, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Wilson", false, null, "J", "Michael J Wilson", null, null, null, "444-555-6666", false, "User", "49d27260-0170-4d87-9fca-e51c289eca2d", "456 Maple Ave", false, null, null },
                    { "8901def0-1234-5678-9abc-def012345678", 0, 9876543298765432m, null, "San Francisco", "41e21621-d51f-4c79-8a8e-4a49e50079e9", "Uruguay", "Customer", "avaklee@example.com", false, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ava", "Lee", false, null, "K", "Ava K Lee", null, null, null, "555-666-7777", false, "User", "f3a89519-79c5-41e0-a648-5b21eb729dd5", "789 Walnut Ave", false, null, null },
                    { "b6a76b15-33e5-4d26-98b9-c948c7823b84", 0, 9876543210012345m, null, "Madrid", "4e9e848b-05ce-4429-aaf8-ea33b448e6ee", "Spain", "Customer", "danielmartinez@example.com", false, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", "Martinez", false, null, "T", "Daniel T Martinez", null, null, null, "555-666-7777", false, "User", "79c3e904-b3a9-4803-b27b-520f042fdf04", "789 Walnut Ave", false, null, null },
                    { "bcdef012-3456-789a-bcde-f01234567890", 0, 9876012345678901m, null, "Sydney", "d7ac17af-149d-4c65-810f-7313d25a4946", "Australia", "Customer", "olivialthompson@example.com", false, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivia", "Thompson", false, null, "L", "Olivia L Thompson", null, null, null, "777-777-8888", false, "User", "f7331239-41cf-4c30-93e3-e13b6b572de0", "123 Pine St", false, null, null },
                    { "c7d3e80a-7a4a-4c54-91a6-89c0df051c94", 0, 9876543210987654m, null, "Los Angeles", "23b9cb72-e285-4cf2-b90b-67931d295eec", "Turkey", "Customer", "janesmith@example.com", false, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Smith", false, null, "A", " Jane A Smith", null, null, null, "777-888-9999", false, "User", "7b3bd596-f08d-4516-a207-dc64f86a814b", "456 Elm St", false, null, null },
                    { "def01234-5678-9abc-def0-123456789abc", 0, 1234567812345678m, null, "Paris", "5d687657-472d-425f-b1cf-5d1276546ce4", "France", "Customer", "sophianbrown@example.com", false, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia", "Brown", false, null, "N", "Sophia N Brown", null, null, null, "999-888-7777", false, "User", "a83ed72c-72fa-4a85-80ca-9b8e327d96a3", "456 Maple Ave", false, null, null },
                    { "e23edc32-bd6a-4b6b-a28e-ccf60b5c32dc", 0, 9876012345678901m, null, "Sydney", "0d3d8c13-9b31-45ab-b9b3-7b17e11b7c49", "Australia", "Customer", "sarahthompson@example.com", false, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "Thompson", false, null, "L", "Sarah L Thompson", null, null, null, "777-777-8888", false, "User", "0ca9e8b6-54df-4837-8dcd-c3d82ee84e10", "789 Pine St", false, null, null },
                    { "f0e7f09e-c7ad-4cb0-8f19-6540b4c7c49f", 0, 5432109876543210m, null, "Toronto", "163d67dc-2674-4307-a14a-c995669e113e", "Canada", "Customer", "davidmiller@example.com", false, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Miller", false, null, "M", "David M Miller", null, null, null, "999-888-7777", false, "User", "898257f2-0cc6-443c-8d4d-2ed4d4490232", "123 Oak Ave", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "CustomerId" },
                values: new object[,]
                {
                    { new Guid("06a1bde2-7ce3-4be0-9328-139574ce50ac"), new Guid("0e67a2e5-df53-4a92-9854-8e1ad46a4e61") },
                    { new Guid("3645f1e6-89cc-4b03-8ec6-1eeced9b013f"), new Guid("2345cdef-0123-4567-89ab-cdef01234567") },
                    { new Guid("3a77b569-9809-4b6c-8714-be079a82ff03"), new Guid("234cdf89-12a3-45b6-789c-0123456789de") },
                    { new Guid("40ee2f1e-9007-413b-8864-774d91c33700"), new Guid("e23edc32-bd6a-4b6b-a28e-ccf60b5c32dc") },
                    { new Guid("47d1e1c7-d34b-4918-af83-3b9ce1adad10"), new Guid("def01234-5678-9abc-def0-123456789abc") },
                    { new Guid("63090912-be0a-45f9-9aba-41139f732100"), new Guid("b6a76b15-33e5-4d26-98b9-c948c7823b84") },
                    { new Guid("699fcdd8-4dde-4a5f-a94c-a3c6850a93dd"), new Guid("6789abcd-ef01-2345-6789-abcd01234567") },
                    { new Guid("7896e531-408b-483c-b95a-e099b4ab5122"), new Guid("23456789-01ab-cdef-0123-456789abcdef") },
                    { new Guid("84598136-6a26-4964-943d-59d7b0d89b7d"), new Guid("bcdef012-3456-789a-bcde-f01234567890") },
                    { new Guid("baa6607b-5909-4041-b24f-53e42e1f78e6"), new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992bb7") },
                    { new Guid("c3a96407-a315-4951-af75-6f53c1b9ceec"), new Guid("22ac8dc9-4385-48ae-90a3-7d8c898c6d5d") },
                    { new Guid("c9085f2a-a4c5-42e0-93c3-ae707a84fce5"), new Guid("8901def0-1234-5678-9abc-def012345678") },
                    { new Guid("cad5dbe9-9a63-4811-b2b6-8bce8cc9c038"), new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992bb8") },
                    { new Guid("cd034007-6dfd-4951-95bc-bfbd02afdbae"), new Guid("724587e6-9314-4fe6-9c3e-6fd612f50234") },
                    { new Guid("dfcb5aeb-378c-476a-a06f-5bfdb46d8331"), new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992b58") },
                    { new Guid("dff97da0-e076-4872-a4ce-a63f3cf92918"), new Guid("f0e7f09e-c7ad-4cb0-8f19-6540b4c7c49f") },
                    { new Guid("e4081e63-6ccb-4980-a5a0-e7080694dea7"), new Guid("c7d3e80a-7a4a-4c54-91a6-89c0df051c94") }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f"), "Kids's Clothing", "Kids.jpg", "Kids", null },
                    { new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d"), "Women's Clothing", "Women.jpg", "Women", null },
                    { new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583"), "Men's Clothing", "men.jpg", "Men", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discount", "Name", "Price", "Rate" },
                values: new object[,]
                {
                    { new Guid("011a58aa-b8d5-43eb-b9fc-93319b76e497"), "Cozy hoodie for kids", 0m, "Kids' Hoodie", 29.99m, 0m },
                    { new Guid("02503452-4e15-4853-a722-106117842afd"), "Warm jacket for men", 0.2m, "Men's Jacket", 59.99m, 0m },
                    { new Guid("056d82ad-cb02-40dd-8cf5-9ea4c696ba7d"), "Comfortable sandals for women", 0.2m, "Women's Sandals", 34.99m, 0m },
                    { new Guid("07dc6006-14f0-416a-81b9-22bf98066c9e"), "Elegant blazer for women", 0.2m, "Women's Blazer", 59.99m, 0m },
                    { new Guid("0a453975-9e5b-445c-9f7a-70aed553cfad"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m },
                    { new Guid("0ff531f5-0e92-4395-bc82-49966fb454b9"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("1585d557-9e67-4f9e-8fc1-ab5f1a27c1a0"), "Warm sweater for kids", 0m, "Kids' Sweater", 34.99m, 0m },
                    { new Guid("16016271-36b8-44e0-9868-1caa155fc612"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("17aaf278-7f5b-4782-bdf4-2afb3e5e9056"), "Adorable t-shirt for kids", 0m, "Kids' T-Shirt", 12.99m, 0m },
                    { new Guid("1f252b5e-3e94-4905-a6fa-0a25e152c1d7"), "Stylish jacket for kids", 0m, "Kids' Jacket", 39.99m, 0m },
                    { new Guid("201aa630-a93e-4833-8764-9f4836aad47a"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("20d9bf0f-8bf4-4ac3-b1d7-ae57566d879a"), "Cozy hoodie for kids", 0m, "Kids' Hoodie", 29.99m, 0m },
                    { new Guid("246848a7-fa9e-4413-9797-f1e41463d17b"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("2b5e4555-7549-4660-89ae-88de817b4f31"), "Stylish pants for women", 0.05m, "Women's Pants", 44.99m, 0m },
                    { new Guid("2c8bb1de-e254-4444-9ce1-3d54713c56f2"), "Classic pants for men", 0.1m, "Men's Pants", 49.99m, 0m },
                    { new Guid("2dd7f9ca-1417-4044-aba0-8d085c69d14b"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("2e5bdb76-6b6a-4c78-bbfa-55402a1b7139"), "Sporty sneakers for men", 0.1m, "Men's Sneakers", 54.99m, 0m },
                    { new Guid("305da32b-6c61-48b8-947a-309dcccbd091"), "Warm jacket for men", 0.2m, "Men's Jacket", 59.99m, 0m },
                    { new Guid("31acf544-2ad1-4748-b576-dfc54b97e720"), "Comfortable hoodie for men", 0m, "Men's Hoodie", 29.99m, 0m },
                    { new Guid("3a1fe294-fbd3-4098-bdf1-65ff2e0071f3"), "Formal shirt for men", 0.15m, "Men's Shirt", 34.99m, 0m },
                    { new Guid("3adc25cd-5af3-4d47-a35b-30485dfc30e1"), "Formal shirt for men", 0.15m, "Men's Shirt", 34.99m, 0m },
                    { new Guid("3f88b1d3-e408-405c-8064-a8116b1212c9"), "Fashionable skirt for women", 0m, "Women's Skirt", 27.99m, 0m },
                    { new Guid("44e73e7f-2cd0-4742-bedd-4b332ba787dc"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("4ce2d8d8-c118-4525-97d1-1be0de4a9530"), "Warm jacket for men", 0.2m, "Men's Jacket", 59.99m, 0m },
                    { new Guid("4f68c9c8-1f60-4be4-9d5b-eebc9b7b7c26"), "Fashionable skirt for women", 0m, "Women's Skirt", 27.99m, 0m },
                    { new Guid("4f78714c-8e18-4a07-988a-9c0ba7db24c2"), "Fashionable skirt for women", 0m, "Women's Skirt", 27.99m, 0m },
                    { new Guid("51d36c0d-667c-40c6-baa0-d3008d1ccc27"), "Warm jacket for men", 0.2m, "Men's Jacket", 59.99m, 0m },
                    { new Guid("5993687d-0212-417c-944f-0f4cb8002c71"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("5ad05cce-3b17-4de1-be77-1b1d95445180"), "Spacious backpack for kids", 0m, "Kids' Backpack", 19.99m, 0m },
                    { new Guid("5d34d28a-4385-427a-907d-6b81fed05ab1"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("6879e8f5-3edd-487f-b86d-b8a87c454051"), "Classic pants for men", 0.1m, "Men's Pants", 49.99m, 0m },
                    { new Guid("68cb8428-2b12-4647-93bf-578be76cc469"), "Cute dress for kids", 0m, "Kids' Dress", 32.99m, 0m },
                    { new Guid("6925bd6b-9f6f-48dc-9895-9b65c93c47b8"), "Spacious backpack for kids", 0m, "Kids' Backpack", 19.99m, 0m },
                    { new Guid("6bcb88aa-338a-4b59-ae62-3fcb544bc811"), "Formal shirt for men", 0.15m, "Men's Shirt", 34.99m, 0m },
                    { new Guid("6d649174-acd6-42d1-b396-df114a97f599"), "Stylish trousers for kids", 0.05m, "Kids' Trousers3", 34.99m, 0m },
                    { new Guid("6f3a2f7b-18eb-44e3-880a-866474487c45"), "Comfortable hoodie for men", 0m, "Men's Hoodie", 29.99m, 0m },
                    { new Guid("718cd15b-0168-4cb9-ad18-ad9423efef8e"), "Fashionable skirt for women", 0m, "Women's Skirt", 27.99m, 0m },
                    { new Guid("72a3ff8d-25cf-4aa6-b82a-89fdb2cd5cda"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("73721658-dc7e-4781-a4e1-9abdf120d7b3"), "Classic pants for men", 0.1m, "Men's Pants", 49.99m, 0m },
                    { new Guid("746d36c6-753d-4200-a2b2-f7bfbecba54d"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m },
                    { new Guid("7c05f821-ba90-4bce-b796-24696a0af7db"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("828ae579-bc5d-4819-99d9-9ff8c949278e"), "Stylish pants for women", 0.05m, "Women's Pants", 44.99m, 0m },
                    { new Guid("8726813e-26ac-49f3-b075-51d9a8d692d4"), "Cozy hoodie for kids", 0m, "Kids' Hoodie", 29.99m, 0m },
                    { new Guid("892928e8-efb8-4651-bb77-1fcabbd68d7c"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("8aabb90a-4479-4e02-a8d4-e578a3006988"), "Stylish jacket for kids", 0m, "Kids' Jacket", 39.99m, 0m },
                    { new Guid("8b060128-77e9-477c-85e6-725cfbb1a33a"), "Adorable shirt for kids", 0.15m, "Kids' Shirt", 17.99m, 0m },
                    { new Guid("8e69d7b4-c0b9-48c8-a65e-222433d35e55"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m },
                    { new Guid("94ba28fa-f723-4546-8880-1daa75a8d030"), "Formal shirt for men", 0.15m, "Men's Shirt", 34.99m, 0m },
                    { new Guid("95ab300d-1bbf-4a5c-97c1-0b54e5ef8898"), "Warm sweater for men", 0.1m, "Men's Sweater", 39.99m, 0m },
                    { new Guid("96e75824-eefa-49ef-bc45-083f42869705"), "Classic denim jeans for men", 0.05m, "Men's Jeans", 39.99m, 0m },
                    { new Guid("9885651f-e32c-444a-88dc-edaddf6391ea"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("9a100daa-77c5-4a4e-b109-0346a1d0b7ee"), "Stylish denim jeans for women", 0.05m, "Women's Jeans", 44.99m, 0m },
                    { new Guid("9a82b88f-52e0-4866-a9f5-f819788719dc"), "Stylish jacket for kids", 0m, "Kids' Jacket", 39.99m, 0m },
                    { new Guid("9d04ae65-a2c3-40ab-bb1e-5c8207419394"), "Stylish trousers for kids", 0.05m, "Kids' Trousers", 34.99m, 0m },
                    { new Guid("9f55c196-d339-4c50-b664-843a0941a79a"), "Warm sweater for kids", 0m, "Kids' Sweater", 34.99m, 0m },
                    { new Guid("a73a2580-8180-4816-af9b-9ce5bae283a5"), "Casual trousers for kids", 0.1m, "Kids' Trousers", 21.99m, 0m },
                    { new Guid("a7de1332-0c55-4b03-8ada-c974ab66123b"), "Warm jacket for kids", 0.1m, "Kids' Jacket", 39.99m, 0m },
                    { new Guid("a8cdb42a-1867-43cb-a880-c4b90a997db9"), "Stylish sneakers for men", 0.15m, "Men's Sneakers", 59.99m, 0m },
                    { new Guid("a9d93b11-0cbf-4653-9fbe-dea1427231e8"), "Cozy hoodie for kids", 0m, "Kids' Hoodie", 29.99m, 0m },
                    { new Guid("a9e666fc-f8d5-4eda-b33c-842238071736"), "Stylish trousers for kids", 0.05m, "Kids' Trousers2", 34.99m, 0m },
                    { new Guid("ac45598b-7b11-4dd2-9660-505155227351"), "Classic pants for men", 0.1m, "Men's Pants", 49.99m, 0m },
                    { new Guid("af0079d5-6ce8-4ee7-98aa-5c082b72d1d2"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("b000723a-306c-4d99-9791-c03edc6bab4f"), "Stylish jacket for women", 0m, "Women's Jacket", 54.99m, 0m },
                    { new Guid("b50d2748-e694-4066-8a2d-0b6c13833c7a"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("bdaa530f-7693-4f9d-b0b3-7775de81712e"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("c0681bd9-137d-42da-891a-8d48eefb4949"), "Stylish trousers for kids", 0.05m, "Kids' Trousers4", 34.99m, 0m },
                    { new Guid("c136d1c2-368c-4750-a183-93c7375981e6"), "Casual shorts for kids", 0m, "Kids' Shorts", 15.99m, 0m },
                    { new Guid("c2e6f467-3c87-4132-84ec-3f2a7008b69d"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("c4893e3c-9e0d-48c9-9854-aebda8e18d44"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("c82671d0-2717-42b6-932a-90260f07ee94"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("d23c4d1e-4597-4c7f-9efc-c6438421b88c"), "Comfortable hoodie for men", 0m, "Men's Hoodie", 29.99m, 0m },
                    { new Guid("d6b4c9c4-0035-408f-ace2-373d72084458"), "Casual shorts for men", 0.1m, "Men's Shorts", 17.99m, 0m },
                    { new Guid("d7edf1d3-e754-440c-9174-17ac30bad654"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m },
                    { new Guid("dbed5e94-ea11-473c-bafa-afa1c415662e"), "Stylish blouse for women", 0m, "Women's Blouse", 24.99m, 0m },
                    { new Guid("dddd163c-4213-43ed-bd32-fa8b16fd031e"), "Stylish pants for women", 0.05m, "Women's Pants", 44.99m, 0m },
                    { new Guid("e4ab7da6-efd9-476d-b1f8-59a22e82efe1"), "Comfortable hoodie for men", 0m, "Men's Hoodie", 29.99m, 0m },
                    { new Guid("e7477e01-893c-4325-894b-678c0b6c9c51"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m },
                    { new Guid("e7895206-a03c-47e9-8058-4bee07d6d265"), "Comfortable shorts for men", 0m, "Men's Shorts", 24.99m, 0m },
                    { new Guid("e87fe924-544e-42b7-b21a-7ff3b35558d4"), "Classic polo shirt for men", 0m, "Men's Polo Shirt", 22.99m, 0m },
                    { new Guid("edb6db18-0bfe-4261-99ff-76fd42bef439"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("f044996e-9b51-46bb-a142-b06edac83122"), "Cozy sweater for women", 0m, "Women's Sweater", 39.99m, 0m },
                    { new Guid("f6372dff-635f-4d6b-af5f-b09b90e95701"), "Fashionable sandals for women", 0.1m, "Women's Sandals", 29.99m, 0m },
                    { new Guid("f65365d0-dc26-49b5-bcb0-1cdcbe3d1323"), "Sporty sneakers for men", 0.1m, "Men's Sneakers", 54.99m, 0m },
                    { new Guid("f98f83ad-7180-4cc8-9bb5-84d07a10635d"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("fbe753d4-7400-4fb0-ace4-a3de15ec9217"), "Sporty sneakers for women", 0m, "Women's Sneakers", 49.99m, 0m },
                    { new Guid("fdd7d9e5-54aa-42e8-8b14-8b2bf8c54a1a"), "Stylish pants for women", 0.05m, "Women's Pants", 44.99m, 0m },
                    { new Guid("ff6c38b7-02a3-4e6e-bb27-3741dd4b92e9"), "Casual t-shirt for women", 0.2m, "Women's T-Shirt", 19.99m, 0m }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("1d53debe-03e6-487f-9b34-6b26c68fc1e5"), "Kids Pants's Clothing", "Kids Pants.jpg", "Pants", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("35b303b9-25a0-4379-89b3-64e4ae51291f"), "Women Shoes's Clothing", "Women Shoes.jpg", "Shoes", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("47a38a48-8747-4461-ba32-7e573be663ee"), "Women Jackets's Clothing", "Women Jackets.jpg", "Jackets", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("6b3c4ef5-01ad-49c7-a8ff-36ae55d0ce8d"), "Men Shoes's Clothing", "men Shoes.jpg", "Shoes", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("6f6c6c4c-9e6e-4e0c-97cc-8b52c055918b"), "Men Jackets's Clothing", "men Jackets.jpg", "Jackets", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("8a6d4a19-47cc-4a4e-822b-cac1de2efc8d"), "Kids shirts's Clothing", "Kids shirts.jpg", "Shirts", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("9a938bc1-0717-4b8d-8f8b-3a2f55de49db"), "Men Pants's Clothing", "men Pants.jpg", "Pants", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("a6c4de53-33c5-48e1-9f21-5649726d3a3d"), "Women shirts's Clothing", "Women shirts.jpg", "Shirts", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("a6d7e8b5-2f4d-4f51-b24b-4fcb52e36f5f"), "Men Hoodies's Clothing", "men Hoodies.jpg", "Hoodies", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("b19a53a3-04e7-4804-84bc-84da64d738a6"), "Kids Jackets's Clothing", "Kids Jackets.jpg", "Jackets", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("c2ae51c9-913a-4e7d-a7b5-ef1efc8f9d3e"), "Kids Hoodies's Clothing", "Kids Hoodies.jpg", "Hoodies", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("ca09f6a1-5b87-4b56-9ee3-c6fb6ad070c2"), "Kids Shoes's Clothing", "Kids Shoes.jpg", "Shoes", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("d9f02e92-d14c-4b6d-86ad-6e4e6c48020a"), "Women Pants's Clothing", "Women Pants.jpg", "Pants", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("e18e42b7-799e-4b3b-a084-c55d4bb5da3f"), "Women Hoodies's Clothing", "Women Hoodies.jpg", "Hoodies", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("f032f788-2340-431f-9f8f-eeb176a35177"), "Mens shirts's Clothing", "men shirts.jpg", "Shirts", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ArrivalDate", "City", "Country", "CustomerId", "Discount", "OrderData", "OrderStatus", "PaymentMethod", "PaymentStatus", "Street", "TotalPrice" },
                values: new object[,]
                {
                    { new Guid("07d96ed8-155d-49c7-a77a-615f109d75c3"), new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Zimbabwe", "b6a76b15-33e5-4d26-98b9-c948c7823b84", 1.0, new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Paid", "789 Oak St", 0m },
                    { new Guid("07d96ed8-155d-49c7-a77a-615f109d77c3"), new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Zimbabwe", "e23edc32-bd6a-4b6b-a28e-ccf60b5c32dc", 1.0, new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Paid", "789 Oak St", 0m },
                    { new Guid("0e67a2e5-df53-4a92-9854-8e1ad46a4e61"), new DateTime(2027, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "New York", "Belgium", "0e67a2e5-df53-4a92-9854-8e1ad46a4e61", 0.0, new DateTime(2027, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CreditCard", "Unpaid", "123 Elm St", 0m },
                    { new Guid("22ac8dc9-4385-48ae-90a3-7d8c898c6d5d"), new DateTime(2027, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Los Angeles", "Belize", "74f5b2b3-3d10-4a85-93b5-8c6d0c992b58", 0.5, new DateTime(2027, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipped", "CashOnDelivery", "Paid", "456 Main St", 0m },
                    { new Guid("23456789-01ab-cdef-0123-456789abcdef"), new DateTime(2027, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Francisco", "Oman", "234cdf89-12a3-45b6-789c-0123456789de", 0.10000000000000001, new DateTime(2027, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Paid", "321 Maple Ave", 0m },
                    { new Guid("2345cdef-0123-4567-89ab-cdef11234567"), new DateTime(2027, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", "Taiwan", "6789abcd-ef01-2345-6789-abcd01234567", 0.20000000000000001, new DateTime(2027, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CreditCard", "Paid", "567 Pine St", 0m },
                    { new Guid("6789abcd-ef01-2345-6789-abcd01234567"), new DateTime(2029, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", "Libya", "c7d3e80a-7a4a-4c54-91a6-89c0df051c94", 0.20000000000000001, new DateTime(2029, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CreditCard", "Paid", "789 Elm St", 0m },
                    { new Guid("724587e6-9314-4fe6-9c3e-7fd612f50232"), new DateTime(2029, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Francisco", "Senegal", "def01234-5678-9abc-def0-123456789abc", 0.29999999999999999, new DateTime(2029, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Paid", "123 Maple Ave", 0m },
                    { new Guid("724587e6-9314-4fe6-9c3e-7fd612f50233"), new DateTime(2029, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", "Samoa", "c7d3e80a-7a4a-4c54-91a6-89c0df051c94", 0.20000000000000001, new DateTime(2029, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "789 Pine St", 0m },
                    { new Guid("724587e6-9314-4fe6-9c3e-7fd612f50234"), new DateTime(2029, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dallas", "Samoa", "b6a76b15-33e5-4d26-98b9-c948c7823b84", 0.10000000000000001, new DateTime(2029, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "987 Cedar St", 0m },
                    { new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992b58"), new DateTime(2029, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Diego", "Samoa", "bcdef012-3456-789a-bcde-f01234567890", 0.0, new DateTime(2029, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Unpaid", "456 Oak St", 0m },
                    { new Guid("8901def0-1234-5678-9abc-def012345678"), new DateTime(2029, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Francisco", "Afghanistan", "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb7", 0.0, new DateTime(2029, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Unpaid", "123 Pine St", 0m },
                    { new Guid("b6a76b15-33e5-4d26-98b9-c948c7823b84"), new DateTime(2029, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Los Angeles", "Andorra", "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb8", 0.10000000000000001, new DateTime(2029, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "456 Maple Ave", 0m },
                    { new Guid("c7d3e80a-7a4a-4c54-91a6-89c0df051c94"), new DateTime(2029, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Iraq", "07d96ed8-155d-49c7-a77a-615f109d77c3", 0.10000000000000001, new DateTime(2029, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Paid", "567 Oak St", 0m },
                    { new Guid("def01234-5678-9abc-def0-113456789abc"), new DateTime(2028, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miami", "Fiji", "bcdef012-3456-789a-bcde-f01234567890", 0.29999999999999999, new DateTime(2028, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Paid", "901 Cherry Ln", 0m },
                    { new Guid("e23edc32-bd6a-4b6b-a28e-ccf90b5c32dc"), new DateTime(2028, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boston", "Denmark", "2345cdef-0123-4567-89ab-cdef01234567", 0.14999999999999999, new DateTime(2028, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "246 Elm St", 0m },
                    { new Guid("f0e7f09e-c7ad-4cb0-8f19-6540b4c7c49f"), new DateTime(2029, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Canada", "724587e6-9314-4fe6-9c3e-6fd612f50234", 0.20000000000000001, new DateTime(2028, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Unpaid", "789 Elm St", 0m },
                    { new Guid("f0e7f09e-c7ad-4cb0-8f19-6540b5c7c49f"), new DateTime(2029, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Canada", "8901def0-1234-5678-9abc-def012345678", 0.20000000000000001, new DateTime(2029, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Unpaid", "789 Elm St", 0m }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ImageURL", "ProductID" },
                values: new object[,]
                {
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("201aa630-a93e-4833-8764-9f4836aad47a") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("44e73e7f-2cd0-4742-bedd-4b332ba787dc") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("5993687d-0212-417c-944f-0f4cb8002c71") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("5d34d28a-4385-427a-907d-6b81fed05ab1") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("72a3ff8d-25cf-4aa6-b82a-89fdb2cd5cda") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("7c05f821-ba90-4bce-b796-24696a0af7db") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("9885651f-e32c-444a-88dc-edaddf6391ea") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("b50d2748-e694-4066-8a2d-0b6c13833c7a") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("bdaa530f-7693-4f9d-b0b3-7775de81712e") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("c4893e3c-9e0d-48c9-9854-aebda8e18d44") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("c82671d0-2717-42b6-932a-90260f07ee94") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CartID",
                table: "AspNetUsers",
                column: "CartID",
                unique: true,
                filter: "[CartID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WishListID",
                table: "AspNetUsers",
                column: "WishListID",
                unique: true,
                filter: "[WishListID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CartId",
                table: "CartProduct",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersReviews_CustomerId",
                table: "CustomersReviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWishList_WishListsId",
                table: "ProductWishList",
                column: "WishListsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "CustomersReviews");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductsInfo");

            migrationBuilder.DropTable(
                name: "ProductWishList");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "WishLists");
        }
    }
}
