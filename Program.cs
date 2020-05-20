using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

namespace swd_endaufgabe
{
    class Program
    {

        //public static List<Avatar> allCharacters = new List<Avatar>();
        //public static List<Enemy> allEnemies = new List<Enemy>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //fillListsWithJsonData();

            //Console.WriteLine(allCharacters[0].Name);
            //Console.WriteLine(allEnemies[0].Inventory[0].Title);
            Controls.GameControls();
        }

        /*private static void fillListsWithJsonData()
        {
            StreamReader readerAvatar = new StreamReader("Avatar.json");
            {
                string json = readerAvatar.ReadToEnd();
                List<Avatar> deserializedCharacters = JsonConvert.DeserializeObject<List<Avatar>>(json);
                for (int i = 0; i < deserializedCharacters.Count; i++)
                {
                    allCharacters.Add(deserializedCharacters[i]);
                }
            }

            StreamReader readerEnemies = new StreamReader("Enemies.json");
            {
                string json = readerEnemies.ReadToEnd();
                List<Enemy> deserializedAnamies = JsonConvert.DeserializeObject<List<Enemy>>(json);
                for (int i = 0; i < deserializedAnamies.Count; i++)
                {
                    allEnemies.Add(deserializedAnamies[i]);
                }
            }
        }*/
    }
}
