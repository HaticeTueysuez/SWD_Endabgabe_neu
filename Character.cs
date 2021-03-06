using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class GameCharacter
    {
        public string Name;
        public int Health;
        public List<Items> Inventory = new List<Items>();
        public int CurrentRoom;
    }

    class Avatar : GameCharacter
    {
        public static Dictionary<string, GameCharacter> Characters;
        
        public Avatar(string name, int health, int currentRoom)
        {
            Name = name;
            Health = health;
            CurrentRoom = currentRoom;
        }

        public static Avatar setupAvatar(string name, int health, int currentRoom)
        {
            Avatar player = new Avatar(
                name, health, currentRoom
            );
            Characters = new Dictionary<string, GameCharacter>();
            Characters[name] = player;
            return player;
        }

        public static int AvatarMove(string name, Location location, Avatar avatar, Enemy enemy, int number_cha, List<Avatar> characters)
        {

            Avatar.Characters[name].CurrentRoom = location.RoomNumber;
            
            ConsoleOutput.DescribeLocation(location);
            for(int i=0; i<number_cha; i++)
            {
                if (location.RoomNumber == characters[i].CurrentRoom)
                {
                    Console.WriteLine(characters[i].Name + " befindet sich in dem Raum");
                }
            }
            Enemy.EnemySameRoom(location, avatar, enemy);
            
            return Avatar.Characters[name].CurrentRoom;
        }

    }

    class Enemy : GameCharacter
    {
        public static Dictionary<string, GameCharacter> Characters;

        public Enemy(string name, int health, List<Items> inventory, int currentRoom)
        {
            Name = name;
            Health = health;
            Inventory = inventory;
            CurrentRoom = currentRoom;
        }

        public static Enemy SetupEnemy(string name, int health, List<Items> inventory, int currentRoom)
        {
            Enemy myenemy = new Enemy(
                name, health, inventory, currentRoom
            );

            Characters = new Dictionary<string, GameCharacter>();
            Characters[name] = myenemy;
            return myenemy;
        }

        public static void EnemySameRoom(Location location, Avatar avatar, Enemy enemy)
        {
            if(enemy.Health != 0)
            {
                if(avatar.CurrentRoom == enemy.CurrentRoom)
                    {
                        Attack.EnemyCurrentRoom(avatar, enemy);
                    }
            }
        }

    }
}