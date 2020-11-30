using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using API.Utils;
using API.Data.Repositories;
using API.Services;
using Microsoft.OpenApi.Models;

namespace API
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
            services.ConfigureJwtAuthentication();
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
            });
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ILessonService, LessonService>();
            services.AddTransient<ILessonRepository, LessonRepository>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IClassService, ClassService>();
            services.AddTransient<IClassRepository, ClassRepository>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<IQuizRepository, QuizRepository>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddControllersWithViews()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Graduation Thesis",
                    Description = "Resfull API with ASP.NET Core",
                    Contact = new OpenApiContact
                    {
                        Name = "Cuwr and HoangNguyen",
                    },
                });
            });


            services.AddCors(options =>
             {
                 options.AddDefaultPolicy(
                 builder =>
                 {

                     builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader();
                 });

                 options.AddPolicy("MyCORSPolicy",
                     builder =>
                     {
                         builder.WithOrigins("http://localhost:3000").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                     });
             });

            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseCors("MyCORSPolicy");

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Graduation Thesis");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
