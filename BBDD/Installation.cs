using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteTest
{
    public class Installation
    {
        public Dictionary<string, Equipment> EquipmentDic { get; set; }

        public Installation()
        {
            this.EquipmentDic = new Dictionary<string, Equipment>();
            this.load();
        }
        private void clear()
        {
            this.EquipmentDic.Clear();
        }
        public bool load()
        {
            bool ok = true;
            this.clear();
            try
            {
                
                using (var db = new SQLiteDBContext())
                {
                    foreach (Equipment eq in db.Equipment)
                        this.EquipmentDic.Add(eq.IP, eq);
                }

                if (this.EquipmentDic.Count == 0)
                {
                    Random rand = new Random();
                    for (int i = 1; i <= 9; i++)
                        this.EquipmentDic.Add("10.1.1." + i, new Equipment() { IP = "10.1.1." + i, Name = "EQ" + i, Type = (Equipment.TypeEquipment)rand.Next(1, 3), StateDB = Equipment.StateBBDD.NEW });

                    this.saveDataBase();
                }
            }
            catch (Exception ex)
            {
                ok = false;
                Console.WriteLine("Error: " + ex.Message);
            }
            return ok;
        }
        public void saveDataBase()
        {
            using (var db = new SQLiteDBContext())
            {
                foreach (Equipment eq in this.EquipmentDic.Values)
                {
                    if (eq.StateDB == Equipment.StateBBDD.DELETE)
                        db.Remove(eq);
                    if (eq.StateDB == Equipment.StateBBDD.NEW)
                        db.Add(eq);
                }
                db.SaveChanges();
            }
        }
    }
}
