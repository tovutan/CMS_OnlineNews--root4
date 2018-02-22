using Model.IEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping
{
    public static class MappingHelper
    {
        public static EntityTypeConfiguration<TEntityType> AddLog<TEntityType>(this EntityTypeConfiguration<TEntityType> config) where TEntityType : class, ILogEntity
        {
            config.Property(e => e.CreateDate).IsRequired();
            config.Property(e => e.UpdateDate).IsOptional();
            config.HasRequired(e => e.CreateUser).WithMany().HasForeignKey(e => e.CreateBy).WillCascadeOnDelete(false);
            config.HasOptional(e => e.UpdateUser).WithMany().HasForeignKey(e => e.UpdateBy).WillCascadeOnDelete(false);

            return config;
        }

        public static EntityTypeConfiguration<TEntityType> AddBase<TEntityType>(this EntityTypeConfiguration<TEntityType> config) where TEntityType : class, IBaseEntity
        {
            config.Property(e => e.IsDeleted).IsRequired();

            return config;
        }

        public static EntityTypeConfiguration<TEntityType> AddSeo<TEntityType>(this EntityTypeConfiguration<TEntityType> config) where TEntityType : class, ISeoEntity
        {
            config.Property(e => e.SeoTitle).IsOptional().HasMaxLength(250);
            config.Property(e => e.SeoKeyword).IsOptional().IsMaxLength();
            config.Property(e => e.SeoDescription).IsOptional().IsMaxLength();

            return config;
        }
    }
}
