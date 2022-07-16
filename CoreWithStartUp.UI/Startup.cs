using CoreWithStartUp.UI.Business;
using CoreWithStartUp.UI.Log;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; // IServiceCollection
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(CoreWithStartUp.UI.Startup))]

namespace CoreWithStartUp.UI
{

    #region Info
    //Startup Clası içerininde temelde 2 tane  kritik metod vardır 
    /*
      1) ConfigureServices() metodu --> DI
      2) Configure()         metodu -->
     */

    #endregion

    public class Startup
    {
        public Startup()
        {
            #region Add Appsettings
            var builder = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            #endregion
        }

        public IConfigurationRoot Configuration { get; set; }

        //Dependency Injection ile Interfacelerden servislerin tanımlanması 
        //Configurasyon dosyasından yani "appsettings.json" yapısının inject edilmesi 
        //Database bağlantısı için "AddDbContext" entegrasyonu ile database bağlantı ayarları 
        //Rabbit redis entegrasyon ayarlamalarının yapıldığı metottur 
        public void ConfigureServices(IServiceCollection services)
        {
            #region DI
            services.AddSingleton<IMailService, MailService>();
            services.AddSingleton<ISmsService, SmsService>();
            services.AddSingleton<IConsoleLogger, ConsoleLogger>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<ICardManager, CardManager>();
            #endregion

        }


        //Uygulama üzerindeki configurasyon ayarlarının yapıldığı yer 
        //Örnek olarak Middleware katmanının entegrasyonu yapılır 
        public void Configure(IApplicationBuilder app, IHostingEnvironment hostingEnvironment)
        {
            var services = app.ApplicationServices;

            #region Old
            /*
              var mailService = services.GetService<IMailService>();
            var consoleService = services.GetService<IConsoleLogger>();

            var result = mailService.Send(new Mail { Header = "Datnet Core", Content = "core  detail..", Sender = "1", Receiver = "2" });
            if (result)
                consoleService.Success("Mail Gönderme başarılı");
            else
                consoleService.Error("Mail Gönderme başarısız");


            var PortInfo = Configuration.GetSection("port").Value;
            var userInfo = Configuration.GetSection("user").Value;
          
            */
            #endregion

            var cardManager = services.GetService<ICardManager>();
            cardManager.ShoppingCard(new Shopping { ProductName = "MicrosoftMause", Price = 120 });

        }
    }
}
