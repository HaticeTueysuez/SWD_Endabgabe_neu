using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class ConsoleOutput
    {
        public static void GameDescription()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.WriteLine("Willkommen in Seattle! Die größte Stadt im Bundesstaat Washington, umgeben von Wasser, Bergen und  immergrünen Wäldern. Jedoch ist die Zombieapokalypse ausgebrochen und die ganze Stadt ist in Gefahr!\nUnd es wird noch schlimmer: deine Freundin Rachel wurde von einem Zombie angegriffen und braucht dringend ein Medikament. \nDein Ziel: in den Operationssaal des Phantom Hospital gelangen und Rachel ihr Medikament bringen. Dafür brauchst du aber zuerst den passenden Schlüssel, finde ihn.  \nAber Achtung! Du musst vorsichtig sein, denn Dr.Scalp, der Anführer der Zombies befindet sich derzeit im Phantom Hospital.. ");
            Console.ResetColor();
        }

        public static void DescribeLocation(Location location)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.WriteLine(location.Description);

            foreach(var i in location.Items)
            {
                Console.WriteLine(i.Title);
            }
            Console.WriteLine("Was möchtest du tun?:");
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.ResetColor();
        }

        public static void TakeAnyInput()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Bitte gebe ein, was du gerne tun möchtest. Mit take(t) <item> nimmst du ein Item auf. Mit c kannst du dir die Befehle ansehen.\nDu kannst den nächsten Raum betreten.\n-----------------");
            Console.ResetColor();
        }

        public static void DropAnyInput()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Bitte gebe ein, was du in den Raum legen möchtest. Mit inventory(i) siehst du, was du bereits gesammelt hast.\nMit drop(d) <item> kannst du das Item hier ablegen.\n-----------------");
            Console.ResetColor();
        }

        public static void AttackWrongInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("attack(a) ist noch nicht möglich");
            Console.ResetColor();   
        }

        public static void AttackDraw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Draw\n-----------------");
            Console.ResetColor();
        }

        public static void EnemyHit(string Input, string arr)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Input.ToUpper() + " schlägt " + arr.ToUpper() + "\n-----------------");
            Console.ResetColor();
        }

        public static void AvatarHit(string Input, string arr)
        {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(Input.ToUpper() + " verliert gegen " + arr.ToUpper() + "\n-----------------");
        Console.ResetColor();
        }

        public static void AvatarWin()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.WriteLine("Du hast Dr.Scalp besiegt!");
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.ResetColor(); 
        }
        
        public static void AvatarLose()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Du wurdest besiegt.");
            Console.ResetColor();  
        }
    }
}