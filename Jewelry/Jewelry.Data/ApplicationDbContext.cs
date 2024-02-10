namespace Jewelry.Data;

using Jewelry.Models.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductImage> ProductImages { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Бижута", DisplayOrder = 50 },
            new Category { Id = 2, Name = "Подаръци", DisplayOrder = 100 },
            new Category { Id = 3, Name = "Дрехи", DisplayOrder = 150 }
        );

        builder.Entity<Product>().HasData(
              new Product
              {
                  Id = 1,
                  Name = "Гердан “Sea Ventures”",
                  Description = "\"Sea Ventures\" е двоен мъжки гердан с висящ елемент. Едната част на гердана е изработена изцяло от 316L Premium неръждаема стомана, а ланец частта от премиум перли. Тези материали правят този аксесоар изключително устойчив на външни фактори, като пот, вода, топлина без да променя своя цвят и да пуска петна.\r\n\r\nНашият мъжки гердан е с дължина от 56см.\r\n\r\nПерфектен гердан за мъже, които не се страхуват да изяват своята визия пред света.\r\n\r\nПоръчай си нашия Гердан \"Sea Ventures\" сега и ще го получиш за по-малко от един работен ден!",
                  Price = 29.90,
                  Quantity = 15,
                  CategoryId = 1
              },
              new Product
              {
                  Id = 2,
                  Name = "Гердан “Iced Essential Cross”",
                  Description = "\"Iced Essential Cross\" е мъжки гердан с висящ елемент. Герданът е изработен от 316L Premium неръждаема стомана и завършен с фина нотка от циркониеви камъни, което го прави изключително устойчив на външни фактори, като пот, вода, топлина без да променя своя цвят и да пуска петна.\r\n\r\nНашият мъжки гердан е с дължина от 56см.\r\n\r\nПоръчай си нашия Гердан \"Iced Essential Cross\" сега и ще го получиш за по-малко от един работен ден!",
                  Price = 34.90,
                  Quantity = 20,
                  CategoryId = 1
              },
              new Product
              {
                  Id = 3,
                  Name = "Мече от рози за Свети Валентин",
                  Description = "Мече от рози за Свети Валентин\r\nМече от рози за Свети Валентин е един перфектен подарък, с който можеш да покажеш на човека отсреща, колко много го обичаш. Мечето е прекрасен подарък,също така за рожден ден, бал, сватба, моминско парти, Свети Валентин или без повод.\r\n\r\nСега е момента да изнендаш любим човек, ако искате да направите специална изненада с креативно отношение,това е мястото, със сигурност ще останете запомнени, а получателят впечатлен! Докажете,че всеки празник е истински, ако търсите или нещо специално, уникално и единствено по рода си, то помислите за ръчно изработен подарък, вместо просто да купите нещо от магазина. Подарък, който носи специално отношение. Подарък с мисъл за другия. И конкретно послание. Доставка\r\nДоставката на желания от Вас модел ще бъде извършена от един до три работни дни, след направената от Вас поръчка. Изпращаме вашите поръчки с куриерска фирма Еконт.",
                  Price = 65,
                  Quantity = 10,
                  CategoryId = 2
              },
              new Product
              {
                  Id = 4,
                  Name = "Спортен клин",
                  Description = "Цвят черен\r\nТип шарка: боя за вратовръзка\r\nДължина: Изрязана\r\nТип: Обикновен\r\nТалия: Висока талия\r\nХарактеристики: Безшевни\r\nМатерия: висока еластичност\r\nМатериал: плат\r\nСъстав: 90% Полиамид, 10% Еластан\r\nИнструкции за поддръжка: Ръчно пране или професионално химическо чистене\r\nШийр: Не\r\nДейност: бягане и тренировка",
                  Price = 20,
                  Quantity = 30,
                  CategoryId = 3
              },
              new Product
              {
                  Id = 5,
                  Name = "Комплект бельо “Секси Камериарка”",
                  Description = "Цвят: Черно и Бяло\r\nТип: Секси комплекти\r\nДеколте: Халтер\r\nДетайли: волан, волан, подгъв с волан, завързване на гърба\r\nБрой части: Комплект от 8 части\r\nТип сутиен: Триъгълник\r\nТип чорапогащи: Прашки\r\nПлат: Леко разтеглив\r\nИнструкции за поддръжка: Ръчно пране, не химическо чистене\r\nМатериал на горнището: трикотажен плат\r\nГорнище Състав: 95% полиестер, 5% еластан",
                  Price = 39.90,
                  Quantity = 5,
                  CategoryId = 3
              }
           );
    }
}
