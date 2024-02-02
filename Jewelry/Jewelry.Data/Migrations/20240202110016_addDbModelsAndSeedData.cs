using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jewelry.Data.Migrations
{
    /// <inheritdoc />
    public partial class addDbModelsAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OutOfStock = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 50, "Бижута" },
                    { 2, 100, "Подаръци" },
                    { 3, 150, "Дрехи" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "OutOfStock", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "\"Sea Ventures\" е двоен мъжки гердан с висящ елемент. Едната част на гердана е изработена изцяло от 316L Premium неръждаема стомана, а ланец частта от премиум перли. Тези материали правят този аксесоар изключително устойчив на външни фактори, като пот, вода, топлина без да променя своя цвят и да пуска петна.\r\n\r\nНашият мъжки гердан е с дължина от 56см.\r\n\r\nПерфектен гердан за мъже, които не се страхуват да изяват своята визия пред света.\r\n\r\nПоръчай си нашия Гердан \"Sea Ventures\" сега и ще го получиш за по-малко от един работен ден!", "Гердан “Sea Ventures”", false, 29.899999999999999, 15 },
                    { 2, 1, "\"Iced Essential Cross\" е мъжки гердан с висящ елемент. Герданът е изработен от 316L Premium неръждаема стомана и завършен с фина нотка от циркониеви камъни, което го прави изключително устойчив на външни фактори, като пот, вода, топлина без да променя своя цвят и да пуска петна.\r\n\r\nНашият мъжки гердан е с дължина от 56см.\r\n\r\nПоръчай си нашия Гердан \"Iced Essential Cross\" сега и ще го получиш за по-малко от един работен ден!", "Гердан “Iced Essential Cross”", false, 34.899999999999999, 20 },
                    { 3, 2, "Мече от рози за Свети Валентин\r\nМече от рози за Свети Валентин е един перфектен подарък, с който можеш да покажеш на човека отсреща, колко много го обичаш. Мечето е прекрасен подарък,също така за рожден ден, бал, сватба, моминско парти, Свети Валентин или без повод.\r\n\r\nСега е момента да изнендаш любим човек, ако искате да направите специална изненада с креативно отношение,това е мястото, със сигурност ще останете запомнени, а получателят впечатлен! Докажете,че всеки празник е истински, ако търсите или нещо специално, уникално и единствено по рода си, то помислите за ръчно изработен подарък, вместо просто да купите нещо от магазина. Подарък, който носи специално отношение. Подарък с мисъл за другия. И конкретно послание. Доставка\r\nДоставката на желания от Вас модел ще бъде извършена от един до три работни дни, след направената от Вас поръчка. Изпращаме вашите поръчки с куриерска фирма Еконт.", "Мече от рози за Свети Валентин", false, 65.0, 10 },
                    { 4, 3, "Цвят черен\r\nТип шарка: боя за вратовръзка\r\nДължина: Изрязана\r\nТип: Обикновен\r\nТалия: Висока талия\r\nХарактеристики: Безшевни\r\nМатерия: висока еластичност\r\nМатериал: плат\r\nСъстав: 90% Полиамид, 10% Еластан\r\nИнструкции за поддръжка: Ръчно пране или професионално химическо чистене\r\nШийр: Не\r\nДейност: бягане и тренировка", "Спортен клин", false, 20.0, 30 },
                    { 5, 3, "Цвят: Черно и Бяло\r\nТип: Секси комплекти\r\nДеколте: Халтер\r\nДетайли: волан, волан, подгъв с волан, завързване на гърба\r\nБрой части: Комплект от 8 части\r\nТип сутиен: Триъгълник\r\nТип чорапогащи: Прашки\r\nПлат: Леко разтеглив\r\nИнструкции за поддръжка: Ръчно пране, не химическо чистене\r\nМатериал на горнището: трикотажен плат\r\nГорнище Състав: 95% полиестер, 5% еластан", "Комплект бельо “Секси Камериарка”", false, 39.899999999999999, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
