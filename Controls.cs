using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

namespace swd_endaufgabe
{
    class Controls
    {
        public static string[] words;
        public static int number_cha;
        public static List<Avatar> mainCharacter = new List<Avatar>();
        public static List<Enemy> allEnemies = new List<Enemy>();
        public static List<Avatar> characters = new List<Avatar>();
        public static List<Location> locations = new List<Location>();
        
        public static void GameControls()
        {
            ConsoleOutput.GameDescription();
            fillListsWithJsonData();
            Location currentLocation = Location.MapSetUp(locations);
            
            Avatar avatar = Avatar.setupAvatar(mainCharacter[0].Name, mainCharacter[0].Health, mainCharacter[0].CurrentRoom);
            Enemy enemy = Enemy.SetupEnemy(allEnemies[0].Name, allEnemies[0].Health, allEnemies[0].Inventory, allEnemies[0].CurrentRoom);
            ConsoleOutput.DescribeLocation(currentLocation);
            for(;;)
            {
                SplitInput();

                switch (words[0])
                {   
                    case "north":
                    case "n":
                        if (currentLocation.North!= null) 
                        {
                            if(Location.RoomOpen(currentLocation.North, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.North;
                            Avatar.AvatarMove(mainCharacter[0].Name, currentLocation, avatar, enemy, number_cha, characters);
                            }
                        }
                        else
                        {
                            Console.WriteLine("In diese Richtung gibt es keinen Weg! Bitte gehe in eine andere Richtung!");
                        }
                        break;
                    case "east":
                    case "e":
                        if (currentLocation.East!= null)
                        {
                            if(Location.RoomOpen(currentLocation.East, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                                currentLocation = currentLocation.East;
                                Avatar.AvatarMove(mainCharacter[0].Name, currentLocation, avatar, enemy, number_cha, characters);
                            }
                        }
                        else
                        {
                            Console.WriteLine("In diese Richtung gibt es keinen Weg! Bitte gehe in eine andere Richtung!");
                        }
                        break;
                    case "south":
                    case "s":
                        if (currentLocation.South!= null)
                        {
                            if(Location.RoomOpen(currentLocation.South, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.South;
                            Avatar.AvatarMove(mainCharacter[0].Name, currentLocation, avatar, enemy, number_cha, characters);
                            }
                        }
                        else
                        {
                            Console.WriteLine("In diese Richtung gibt es keinen Weg! Bitte gehe in eine andere Richtung!");
                        }
                        break;
                    case "west":
                    case "w":
                        if (currentLocation.West != null)
                        {
                            if(Location.RoomOpen(currentLocation.West, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.West;
                            Avatar.AvatarMove(mainCharacter[0].Name, currentLocation, avatar, enemy, number_cha, characters);
                            }
                        }
                        else
                        {
                            Console.WriteLine("In diese Richtung gibt es keinen Weg! Bitte gehe in eine andere Richtung!");
                        }
                        break;
                    case "take":
                    case "t":
                        try
                        {
                            if(words[1] != "")
                            {
                                Items.TakeItem(words[1],currentLocation, avatar);
                            }
                            else
                            {
                                ConsoleOutput.TakeAnyInput();
                            }
                        }
                        catch
                        {
                            ConsoleOutput.TakeAnyInput();
                        }
                        break;
                    case "drop":
                    case "d":
                        try
                        {
                            if(words[1] != "")
                            {
                                Items.DropItem(words[1],currentLocation, avatar);
                            }
                            else
                            {
                                ConsoleOutput.DropAnyInput();
                            }
                        }
                        catch
                        {
                            ConsoleOutput.DropAnyInput();
                        }
                        break;
                    case "Inventory":
                    case "i":
                            Items.ShowInventory(avatar);
                        break;
                    case "look":
                    case "l":
                        ConsoleOutput.DescribeLocation(currentLocation);
                        break;
                   
                    case "commands":
                    case "c":
                        Console.WriteLine("commands(c), look(l), inventory(i), take(t)<Item>, drop(d)<Item>, getinformation(g)<Item>, quit(q)");
                        break;
                    case "quit":
                    case "q":
                        Environment.Exit(0);
                        break;
                    case "attack":
                    case "a":
                        try
                        {
                            if(words[1] != "")
                            {
                                if(enemy.CurrentRoom == avatar.CurrentRoom)
                                {
                                    Attack.AttackEnemy(words[1] ,currentLocation, avatar, enemy);
                                }
                                else
                                {
                                    Console.WriteLine("Du kannst diesen Knopf nicht benutzen. Bitte drücke c für Hilfe!");
                                    break;
                                }
                            }
                        }
                        catch
                        {
                            ConsoleOutput.AttackWrongInput();
                        }
                        break;
                        case "getinformation":
                        case "g":
                        try
                        {
                            if(words[1] != "")
                            {
                                Items.GetInformation(words[1]);
                            }
                            else
                            {
                                Console.WriteLine("Falsche eingabe");
                            }
                        }
                        catch
                        {

                        }
                        break;
                        default:
                        Console.WriteLine("Du kannst diesen Knopf nicht benutzen. Bitte drücke c für Hilfe!");
                        break;
                }
                WinConditions.CheckFinished(avatar);
            }
        }

        public static Array SplitInput()
        {
            string _input = Console.ReadLine();
            words = _input.Split(' ');
            return words;
        }

        private static void fillListsWithJsonData()
        {
            StreamReader readerAvatar = new StreamReader("Avatar.json");
            {
                string json = readerAvatar.ReadToEnd();
                List<Avatar> deserializedCharacters = JsonConvert.DeserializeObject<List<Avatar>>(json);
                for (int i = 0; i < deserializedCharacters.Count; i++)
                {
                    mainCharacter.Add(deserializedCharacters[i]);
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

            StreamReader readerCharacters = new StreamReader("Characters.json");
            {
                string json = readerCharacters.ReadToEnd();
                List<Avatar> deserializedCharacters = JsonConvert.DeserializeObject<List<Avatar>>(json);
                number_cha = deserializedCharacters.Count;
                for (int i = 0; i < deserializedCharacters.Count; i++)
                {
                    characters.Add(deserializedCharacters[i]);
                }
            }

            StreamReader readerLocations = new StreamReader("Location.json");
            {
                string json = readerLocations.ReadToEnd();
                List<Location> deserializedLocations = JsonConvert.DeserializeObject<List<Location>>(json);
                for (int i = 0; i < deserializedLocations.Count; i++)
                {
                    locations.Add(deserializedLocations[i]);
                }
            }
        }
    }

}