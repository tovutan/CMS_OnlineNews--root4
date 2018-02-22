using System;
using System.Linq;

namespace Model.IEntities
{
    public interface IBaseEntity
    {
        bool IsDeleted { get; set; }
    }
}
