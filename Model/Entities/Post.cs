using Model.Entities.Identity;
using Model.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model.Entities
{
    public partial class Post : IBaseEntity, ILogEntity, ISeoEntity
    {
        public Post()
        {
            Tags = new HashSet<Tag>();
            Categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string URL { get; set; }

        public string ShortDesc { get; set; }

        public string FullDesc { get; set; }

        public string ImageURL { get; set; }

        [DefaultValue(0)]
        public int View { get; set; }

        #region Setting
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [DefaultValue(false)]
        public bool IsShow { get; set; }

        [DefaultValue(false)]
        public bool IsHot { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [DefaultValue(true)]
        public bool IsAllowComment { get; set; }

        [DefaultValue(true)]
        public bool IsDraft { get; set; }
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

        public DateTime? PublicDate { get; set; }
        public virtual string PublicBy { get; set; }
        public virtual User PublicUser { get; set; }
        #endregion

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
