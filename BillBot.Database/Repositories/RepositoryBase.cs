using BillBot.Database.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillBot.Database.Repositories
{
    public abstract class RepositoryBase<T> where T : DataModelBase
    {
        // Fields
        protected readonly DatabaseContext context;

        public RepositoryBase(DatabaseContext context)
        {
            this.context = context;
        }


        public void Add(T model)
        {
            this.context.Add(model);
        }

        public void Remove(T model)
        {
            this.context.Add(model);
        }
    }
}
