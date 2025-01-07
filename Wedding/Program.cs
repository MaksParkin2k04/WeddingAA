using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.EntityFrameworkCore;
using Wedding.Data;
using Wedding.Models;
using Wedding.Services;

namespace Wedding {
    public class Program {
        public async static Task Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic }));

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Строка подключения 'DefaultConnection' не найдена.");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connectionString));

            builder.Services.Configure<MailOptions>(builder.Configuration.GetSection("MailOptions"));

            builder.Services.AddScoped<IWeddingRepository, WeddingRepository>();
            builder.Services.AddTransient<ISendMail, SendMail>();

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

#if DEBUG       
            //// Инициализация базы данных
            using (IServiceScope scope = app.Services.CreateScope())
            {
                ApplicationContext context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                await Data.Initialization.DatabaseInitializer.Initialize(context);
            }
#endif

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();

            app.Run();
        }
    }
}
