using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Items
    {
        public string InteractionName;
        public string Description;
        public string Title;
        public bool Usable;

        public Items(string interactionName, string title, string description, bool usable)
        {
            InteractionName = interactionName;
            Title = title;
            Description = description;
            Usable = usable;
        }
        public static void TakeItem(string _words, Location location, Avatar avatar)
        {
            bool find_item = false;
   
            foreach(var _item in location.Items)
            {
                if (_item.Title == _words)
                {
                    find_item = true;

                    if (_item.Usable == true)
                    {
                        Console.WriteLine("Du hast " + _item.Title + " zu deinem Inventar hinzugefügt.\n-----------------");
                        avatar.Inventory.Add(_item);
                        location.Items.Remove(_item);
                    }
                    else
                    {
                        Console.WriteLine("Du kannst das Objekt nicht in deinen Inventar hinzufügen!\n-----------------");
                    }
                }

            }

            if  (find_item == false)
            {
                Console.WriteLine("Falsche eingabe, beachte bitte Groß-und Kleinschreibung!");
            }
        }

        public static void ShowInventory(Avatar avatar)
        {
            Console.WriteLine("In deinem Inventar befindet sich folgende Items: ");
            foreach (var i in avatar.Inventory)
            {
                Console.Write(i.Title + " | ");
            }
            Console.WriteLine("\n-----------------");
        }

        public static void DropItem(string _words, Location location, Avatar avatar)
        {
            bool find_item = false;

            foreach(var _item in avatar.Inventory)
            {
                if (_item.Title == _words)
                {
                    find_item = true;
                    Console.WriteLine("Du hast " + _item.Title + " aus deinem Inventar entfernt.\n-----------------");
                    location.Items.Add(_item);
                    avatar.Inventory.Remove(_item);
                }
            }

            if  (find_item == false)
            {
                Console.WriteLine("Dieses Objekt ist nicht in deinem Inventar vorhanden!");
            }
        }
       
        public static void GetInformation(string _words)
        {
            Items findItem = Avatar.Characters["Hatice"].Inventory.Find(x => x.InteractionName.Contains(_words.ToLower()));
            Console.WriteLine(findItem.Title + "\n" + findItem.Description);
        }

        public static void DropLoot(string _words, Location location, Enemy enemy)
        {
            Console.WriteLine("Der Gegner hat einige Items verloren\n-----------------");
                
            foreach(var i in enemy.Inventory)
            {
                location.Items.Add(i);
            } 
        }
    }
}