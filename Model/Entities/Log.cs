using Model.Entities.Identity;
using System;

namespace Model.Entities
{
    public partial class Log
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public LogType Type { get; set; }

        public string DataAccess { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual string CreateBy { get; set; }
        public virtual User CreateUser { get; set; }
    }

    public enum LogType
    {
        Info,
        Error,
        Login,
        //User
        UserViewList,
        UserViewInfo,
        UserAdd,
        UserUpdate,
        UserDelete,
        //Category
        CategoryViewList,
        CategoryViewInfo,
        CategoryAdd,
        CategoryUpdate,
        CategoryDelete,
        //Post
        PostViewList,
        PostViewInfo,
        PostAdd,
        PostUpdate,
        PostDelete,
        //Tag
        TagViewList,
        TagViewInfo,
        TagAdd,
        TagUpdate,
        TagDelete,
        //Permission
        PermissionDeny,
        //Setting
        ClearCache,
        SetSetting,
    }
}
