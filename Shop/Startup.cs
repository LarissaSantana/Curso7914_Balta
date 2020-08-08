using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;

namespace Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddScoped<DataContext, DataContext>();
        }

        //IWebHostEnvironment - para saber em qual ambiente voc� est� (produ��o ou desenvolvimento)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //serve para exibir detalhes do erro se estiver em desenvolvimento 
            // e para n�o expor informa��es importantes em produ��o
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Vai for�ar que a api responda sobre https
            app.UseHttpsRedirection();

            //Utilizar o padr�o de rotas
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
