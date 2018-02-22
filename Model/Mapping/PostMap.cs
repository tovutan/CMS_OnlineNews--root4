using Model.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;

namespace Model.Mapping
{
    public partial class PostMap : BaseMap<Post>
    {
        public PostMap()
        {
            this.ToTable("Post");
            this.HasKey(p => p.Id);

            this.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(r => r.URL)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = false }));

            this.Property(p => p.ShortDesc)
                .IsRequired()
                .IsMaxLength();

            this.Property(p => p.FullDesc)
                .IsRequired()
                .IsMaxLength();


            // quan hệ n-n
            this.HasMany(c => c.Categories) //có nhiều danh mục
                .WithMany(p => p.Posts)// có nhiều bài post
                .Map(m => m.ToTable("Post_Category_Mapping").MapLeftKey("PostId").MapRightKey("CategoryId"));

            this.HasMany(p => p.Tags)
                .WithMany(p => p.Posts)
                .Map(m => m.ToTable("Post_Tag_Mapping").MapLeftKey("PostId").MapRightKey("TagId"));


            this.Property(e => e.PublicDate).IsOptional();
            this.HasOptional(e => e.PublicUser).WithMany().HasForeignKey(e => e.PublicBy).WillCascadeOnDelete(false);

            this.AddBase().AddLog().AddSeo();
        }
    }
}
