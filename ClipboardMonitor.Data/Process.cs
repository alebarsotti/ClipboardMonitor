namespace ClipboardMonitor.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Process
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ClipboardHistory> ClipboardHistory { get; set; }

        public Process()
        {

        }

        public Process(string name)
        {
            Name = name;
        }
    }
}
