using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        //IWebHostEnvironment - para saber em qual ambiente você está (produção ou desenvolvimento)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //serve para exibir detalhes do erro se estiver em desenvolvimento 
            // e para não expor informações importantes em produção
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Vai forçar que a api responda sobre https
            app.UseHttpsRedirection();

            //Utilizar o padrão de rotas
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
