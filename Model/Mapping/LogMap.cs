using Model.Entities;
using System;
using System.Linq;

namespace Model.Mapping
{
    public partial class LogMap : BaseMap<Log>
    {
        public LogMap()
        {
            this.ToTable("Log");
            this.HasKey(l => l.Id);
            this.Property(l => l.Message).HasMaxLength(250).IsRequired();
            this.Property(l => l.Type).IsRequired();
            this.Property(l => l.Description).IsOptional().IsMaxLength();


            this.Property(e => e.CreateDate).IsRequired();
            this.HasRequired(e => e.CreateUser).WithMany().HasForeignKey(e => e.CreateBy);
        }
    }
}
