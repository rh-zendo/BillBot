using System.ComponentModel.DataAnnotations.Schema;

namespace BillBot.Database.DataModels
{
    [Table("BillBotSettings")]
    public class BillBotSetting : DataModelBase
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
