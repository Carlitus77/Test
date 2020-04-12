using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SQLiteTest
{
    public class Equipment
    {
        public enum TypeEquipment
        {
            UNKNOWN,
            PC,
            MATRIX,
            PAGING_DESK
        }
        public enum StateBBDD
        {
            NORMAL,
            NEW,
            DELETE
        }
        [Key]
        public string IP { get; set; }
        public string Netmask { get; set; }
        public string Gateway { get; set; }
        public string Name { get; set; }        
        public bool Enabled { get; set; }
        public TypeEquipment Type { get; set; }
        [NotMapped]
        public DateTime LastHB { get; set; }
        [NotMapped]
        public StateBBDD StateDB { get; set; }

        public Equipment()
        {
            this.IP = "10.1.1.1";
            this.Netmask = "255.0.0.0";
            this.Name = "";
            this.Enabled = false;
            this.Type = TypeEquipment.UNKNOWN;
            this.LastHB = DateTime.MinValue;
            this.StateDB = StateBBDD.NORMAL;
        }

        public void print()
        {
            Console.WriteLine(this.Name + " (" + this.IP + ")");
            Console.WriteLine("Last HB: " + this.LastHB.ToString("dd/MM/yyyy HH:mm:ss"));
        }
        public void delete()
        {
            this.StateDB = StateBBDD.DELETE;
        }
    }
}
