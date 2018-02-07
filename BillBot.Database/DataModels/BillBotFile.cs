using System.ComponentModel.DataAnnotations.Schema;

namespace BillBot.Database.DataModels
{
    [Table("BillBotFiles")]
    public class BillBotFile : DataModelBase
    {
        public string FileName { get; set; }
        public string FileType { get; set; }

        public byte[] Bytes { get; set; }
    }
}
