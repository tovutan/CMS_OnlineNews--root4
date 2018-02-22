using System;
using System.Linq;

namespace Model.Entities.Identity
{
    [Serializable]
    public class Permission
    {
        public Permission(bool viewSetting = false,
            //setting
            bool setSetting = false,
            bool viewLog = false,
            bool clearCache = false,
            //user
            bool userViewList = false,
            bool userViewDetail = false,
            bool userSetPass = false,
            bool userSetRole = false,
            bool userAdd = false,
            bool userEdit = false,
            bool userDelete = false,
            //category
            bool categoryViewList = false,
            bool categoryViewDetail = false,
            bool categoryAdd = false,
            bool categoryEdit = false,
            bool categoryDelete = false,
            //tag
            bool tagViewList = false,
            bool tagViewDetail = false,
            bool tagAdd = false,
            bool tagEdit = false,
            bool tagDelete = false,
            //post
            bool postViewList = false,
            bool postViewDetail = false,
            bool postAdd = false,
            bool postPublic = false,
            bool postEdit = false,
            bool postDelete = false)
        {
            //setting
            ViewSetting = viewSetting;
            SetSetting = setSetting;
            ViewLog = viewLog;
            ClearCache = clearCache;
            //user
            UserViewList = userViewList;
            UserViewDetail = userViewDetail;
            UserAdd = userAdd;
            UserSetPass= userSetPass;
            UserSetRole = userSetRole;
            UserEdit = userEdit;
            UserDelete = userDelete;
            //cat
            CategoryViewList = categoryViewList;
            CategoryViewDetail = categoryViewDetail;
            CategoryAdd = categoryAdd;
            CategoryEdit = categoryEdit;
            CategoryDelete = categoryDelete;
            //tag
            TagViewList = tagViewList;
            TagViewDetail = tagViewDetail;
            TagAdd = tagAdd;
            TagEdit = tagEdit;
            TagDelete = tagDelete;
            //post
            PostViewList = postViewList;
            PostViewDetail = postViewDetail;
            PostAdd = postAdd;
            PostPublic = postPublic;
            PostEdit = postEdit;
            PostDelete = postDelete;
        }

        #region system
        public bool ViewSetting { get; private set; }
        public bool SetSetting { get; private set; }
        public bool ViewLog { get; private set; }
        public bool ClearCache { get; private set; }
        #endregion

        #region User
        public bool UserViewList { get; private set; }
        public bool UserViewDetail { get; private set; }
        public bool UserAdd { get; private set; }
        public bool UserSetPass { get; private set; }
        public bool UserSetRole { get; private set; }
        public bool UserEdit { get; private set; }
        public bool UserDelete { get; private set; }
        #endregion

        #region Category
        public bool CategoryViewList { get; private set; }
        public bool CategoryViewDetail { get; private set; }
        public bool CategoryAdd { get; private set; }
        public bool CategoryEdit { get; private set; }
        public bool CategoryDelete { get; private set; }
        #endregion

        #region Tag
        public bool TagViewList { get; private set; }
        public bool TagViewDetail { get; private set; }
        public bool TagAdd { get; private set; }
        public bool TagEdit { get; private set; }
        public bool TagDelete { get; private set; }
        #endregion

        #region Post
        public bool PostViewList { get; private set; }
        public bool PostViewDetail { get; private set; }
        public bool PostAdd { get; private set; }
        public bool PostPublic { get; private set; }
        public bool PostEdit { get; private set; }
        public bool PostDelete { get; private set; }
        #endregion

    }
}