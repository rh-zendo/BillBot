using System;

namespace BillBot.Database.DataModels
{
    public abstract class DataModelBase
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
