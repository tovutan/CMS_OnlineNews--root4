using Model.Entities;
using Model.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Reflection;
using Model.Entities.Identity;
using Model.Mapping.Identity;

namespace Model.Services
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string, UserLogin, UserRole, UserClaim>
    {
        public ApplicationDbContext() : base("OnlineNews2017")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Navigation> Navigations { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }
            
            //dynamically load all configuration
            //System.Type configType = typeof(LanguageMap);   //any of your configuration classes here
            //var typesToRegister = Assembly.GetAssembly(configType).GetTypes()

            //var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => !String.IsNullOrEmpty(type.Namespace))
            //    .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(BaseMap<>));
            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}
            //...or do it manually below. For example,
            //modelBuilder.Configurations.Add(new LanguageMap());

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserClaimMap());
            modelBuilder.Configurations.Add(new UserRoleMap());
            modelBuilder.Configurations.Add(new UserLoginMap());

            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new TagMap());
            modelBuilder.Configurations.Add(new NavigationMap());
            modelBuilder.Configurations.Add(new LogMap());
            modelBuilder.Configurations.Add(new SettingMap());
        }

    }
}