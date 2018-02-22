using Model.Entities.Identity;
using Model.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model.Entities
{

    public partial class Category : IBaseEntity, ILogEntity, ISeoEntity
    {
        public Category()
        {
            Posts = new HashSet<Post>();
            ChildCategory = new HashSet<Category>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public string ImageURL { get; set; }

        public string Description { get; set; }

        #region Category Parent-Child;          
        public virtual int? ParentId { get; set; }
        public virtual Category ParentCategory { get; set; }
        // Lấy ra những mục liên quan

        public virtual ICollection<Category> ChildCategory { get; set; }
        #endregion

        #region Setting
        [DefaultValue(0)]
        public int Priority { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [DefaultValue(true)]
        public bool IsShow { get; set; }

        public string CustomLayout { get; set; }
        #endregion

        #region SEO
        public string SeoTitle { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoDescription { get; set; }
        #endregion

        #region Log
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual string CreateBy { get; set; }
        public virtual User CreateUser { get; set; }    

        public virtual string UpdateBy { get; set; }
        public virtual User UpdateUser { get; set; }
        #endregion

        public virtual ICollection<Post> Posts { get; set; }
    }
}
