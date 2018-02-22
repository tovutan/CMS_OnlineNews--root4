using System;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace Model.Mapping
{
    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : class
    {
        protected BaseMap()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }
    }
}
