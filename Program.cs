using System;
using System.Threading;

namespace SQLiteTest
{
    /* NOTES
     * FER selects directes
                 *  string cs = @"URI=file:C:\UXXX\sqliteTes.db";
                    using var con = new SQLiteConnection(cs);
                    con.Open();

                    string stm = "SELECT * FROM cars LIMIT 5";

                    using var cmd = new SQLiteCommand(stm, con);
                    using SQLiteDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())  
                    {
                        Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetInt32(2)}");
                    }

        * https://docs.microsoft.com/es-es/ef/core/managing-schemas/migrations/?tabs=vs
        * Crear una migración --> Add-Migration InitialCreate
        * Actualizar la base de datos --> Update-Database
        * Canvis posteriors a la BBDD --> Add-Migration NOMqueVolguem
        * Quitar una migración Treure la última -->Remove-Migration
        */

    class Program
    {
        static Installation inst = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            inst = new Installation();
            bool quit = false;
            DateTime lastHB = DateTime.MinValue;
            while (!quit)
            {
                simulateHB();
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.WriteLine();
                    switch (key.Key)
                    {
                        case ConsoleKey.H:
                            displayHelp();
                            break;
                        case ConsoleKey.Q:
                            quit = true;
                            Console.WriteLine("Exit application by user");
                            break;
                        default:
                            if (char.IsDigit(key.KeyChar) && key.KeyChar != 48)
                            {
                                int number = int.Parse(key.KeyChar.ToString());
                                inst.EquipmentDic["10.1.1." + number].print(); 
                            }
                            else
                                Console.WriteLine("Command not found. Use h for command information.");
                            break;
                    }


                }
                Thread.Sleep(1000); // 1 segon
            }
        }

        private static void simulateHB()
        {
            Random rand = new Random();
            foreach (Equipment eq in inst.EquipmentDic.Values)
            {
                if (eq.LastHB < DateTime.Now.AddSeconds(-30)) // si fa mes de 30 segons que no rebem el hb el tornem a rebre.
                    eq.LastHB = DateTime.Now.AddSeconds(rand.Next(-5, 5));
            }
        }

        private static void displayHelp()
        {
            Console.WriteLine("Keyboard commands:");
            Console.WriteLine("\tH: Help");
            Console.WriteLine("\t1..9: Number between 1 and 9, show information for this equipment.");
            Console.WriteLine("\tQ: Quit, Exit application)");
        }
    }
}
