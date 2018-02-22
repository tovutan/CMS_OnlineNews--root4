using Model.Entities;
using System;
using System.Linq;

namespace Model.Mapping
{
    public partial class SettingMap : BaseMap<Setting>
    {
        public SettingMap()
        {
            this.ToTable("Setting");
            this.HasKey(s => s.Key);
            this.Property(s => s.Key)
                .HasMaxLength(50)
                .IsUnicode(false);

            this.Property(s => s.Value).IsRequired().IsMaxLength();
            this.Property(s => s.Description).IsRequired().IsMaxLength();
            
            this.Property(e => e.UpdateDate).IsOptional();
            this.HasOptional(e => e.UpdateUser).WithMany().HasForeignKey(e => e.UpdateBy).WillCascadeOnDelete(false);
        }
    }
}
