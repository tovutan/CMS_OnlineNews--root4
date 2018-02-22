
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model.Services
{
    public class BaseServices
    {
        private static ApplicationDbContext _onlineNews;
        public static ApplicationDbContext GetDBContext()
        {
            if (_onlineNews == null)
            {
                lock (typeof(ApplicationDbContext))
                {
                    _onlineNews = new ApplicationDbContext();
                }
            }
            return _onlineNews;
        }

        protected internal ApplicationDbContext _db => GetDBContext();

   

    #region Log

    public void AddLog(string message, string dataAccess, string detail, string userId)
    {
        var newLog = new Log()
        {
            Message = message,
            DataAccess = dataAccess,
            Description = detail,
            CreateBy = userId,
            CreateDate = DateTime.Now
        };
            _db.Logs.Add(newLog);
            _db.SaveChanges();
    }
        #endregion
    }
}
