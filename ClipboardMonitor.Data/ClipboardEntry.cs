namespace ClipboardMonitor.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ClipboardEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CopiedText { get; set; }
        public DateTime Time { get; set; }
        public string ProcessName { get; set; }
        public string WindowTitle { get; set; }
    }
}
