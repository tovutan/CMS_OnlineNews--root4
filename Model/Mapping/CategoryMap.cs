using Model.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;

namespace Model.Mapping
{
    public partial class CategoryMap : BaseMap<Category>
    {
        public CategoryMap()
        {
            this.ToTable("Category");
            this.HasKey(d => d.Id);

            this.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = false }));

            this.Property(c => c.URL)                                       
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = false }));

            this.HasMany(c => c.ChildCategory)
                .WithOptional(c => c.ParentCategory)
                .HasForeignKey(c => c.ParentId);

            this.AddBase().AddLog().AddSeo();
        }
    }
}
