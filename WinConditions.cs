using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class WinConditions
    {
        public static bool CheckFinished(Avatar avatar)
        {
            foreach (var i in avatar.Inventory)
            {
                if(i.Title == "Medikament")
                {
                    Console.WriteLine("Gratuliere! Du hast das Medikament gefunden. Du kannst nun deine Freundin retten!");
                    Environment.Exit(0);
                }
            }

            return true;
        }
    }
}