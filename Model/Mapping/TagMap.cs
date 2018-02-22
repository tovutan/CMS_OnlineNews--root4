using Model.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;

namespace Model.Mapping
{
    public partial class TagMap : BaseMap<Tag>
    {
        public TagMap()
        {
            this.ToTable("Tag");
            this.HasKey(t => t.Id);

            this.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = false }));

            this.Property(r => r.URL)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = false }));

            this.AddBase().AddLog().AddSeo();
        }
    }
}
