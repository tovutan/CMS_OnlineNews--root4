using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping
{
    public partial class NavigationMap : BaseMap<Navigation>
    {
        public NavigationMap()
        {
            this.ToTable("Navigation");
            this.HasKey(n => n.Id);

            this.Property(n => n.Title).HasMaxLength(100);

            this.HasOptional(n => n.Category).WithMany().HasForeignKey(n => n.CategoryId);

            this.AddLog();
        }
    }
}
