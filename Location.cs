using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Location
    {
        public string Title;
        public string Description;

        public int RoomNumber;

        public bool Open;

        public bool GameFinished;

        public static bool final_key = false;

        public Location North;
        public Location East;
        public Location South;
        public Location West;

        public List<Items> Items = new List<Items>();
        public static Dictionary<string, Location> rooms;

        public Location(int roomNumber, string title, string description, bool open, bool gameFinished, List<Items> items)
        {
            RoomNumber = roomNumber;
            Title = title;
            Description = description;
            Open = open;
            GameFinished = gameFinished;
            Items = items;

        }
        public static Location MapSetUp()
        {
            
            /*#region Object Rooms
            Location entrance = new Location
            (
                0,
                "Eingang",
                "Du befindest dich im Eingang des Krankenhauses. Du siehst:",
                true, true
            );

            Location hall = new Location
            (
                1,
                "Flur",
                "Du Befindest dich im Flur. Hier siehst du:", 
                true ,true
            );

            Location cafeteria = new Location
            (
                2,
                "Cafeteria", 
                "Du befindest dich in der Cafeteria des Krankenhauses. Du siehst:", 
                true, true
            );
            
            Location patientroom = new Location
            (
                3,
                "Patientenzimmer", 
                "Du bist im Patientenzimmer. Hier siehst du: ", 
                true, true
            );
            Location operationroom = new Location
            (
                4,
                "Operationssaal", 
                "Du bist endlich im Operationssaal. Schau dich um und hole das Medikament, um deine Freundin zu retten!", 
                false, false
            );
            #endregion*/

            #region Object Items
            Items spoon = new Items
            (
                "löffel", "Löffel", "-----------------\nDer Löffel könnte dir für das Medikament nützlich sein.\n-----------------", 
                true
            ); 

            Items chair = new Items
            (
                "stuhl", "Stuhl", "-----------------\nDer Stuhl kann für verschiedene Zwecke genutzt werden.\n-----------------", 
                true
            );

            Items cake = new Items
            (
                "kuchen", "Kuchen", "-----------------\nIn der Cafeteria befindet sich ein leckeres Stück Kuchen. Damit kannst du Energie tanken.\n-----------------", 
                true
            );

            Items coffee = new Items
            (
                "kaffee","Kaffee", "-----------------\nIn der Cafeteria befindet sich eine Tasse Kaffee.\n-----------------", 
                true
            );

            Items scalpel = new Items
            (
                "skalpell", "Skalpell", "-----------------\nIm Operationssaal befindet sich ein Skalpell. Damit könntest du die Wunde deiner Freundin säubern.\n-----------------",
                true
            );

            Items medicine = new Items
            (
                "medikament", "Medikament", "-----------------\nDas Medikament ist das Wundermittel für deine Freundin.\n-----------------", 
                true 
            );

            Items key = new Items
            (
                "schlüssel", "Schlüssel", "-----------------\nSchlüssel zum Aufschließen eines Raumes\nVielleicht ist das der Schlüssel um in den Operationssaal zu kommen.\n-----------------", 
                true
            );
            #endregion

            #region not usable Object Items
            Items vendingMachine = new Items
            (
                "getränke automat", "Getränke Automat", "",false
            );
            Items bed = new Items
            (
                "bett", "Bett", "", false
            );
            Items television = new Items
            (
                "fernseher", "Fernseher", "", false
            );
            Items plant = new Items
            (
                "pflanze", "Pflanze", "", false
            );
            #endregion


            entrance.North= hall; 
            entrance.Items.AddRange(new List<Items>
            {
                plant, vendingMachine
            });

            hall.North= patientroom;
            hall.South=entrance;
            hall.Items.Add(chair);

            patientroom.West= cafeteria;
            patientroom.East= operationroom;
            patientroom.South= hall;
            patientroom.Items.AddRange(new List<Items>
            {
                bed, television, key
            });

            cafeteria.East= patientroom;
            cafeteria.Items.AddRange(new List<Items>
            {
                cake, coffee, spoon
            });

            operationroom.South = patientroom;
            operationroom.Items.AddRange(new List<Items>
            {
                scalpel, medicine
            });

            rooms = new Dictionary<string, Location>();
            rooms["Eingang"] = entrance;
            rooms["Flur"] = hall;
            rooms["Patientenzimmer"] = patientroom;
            rooms["Cafeteria"] = cafeteria;
            rooms["Operationssaal"] = operationroom;

            return entrance;
        }
        public static bool RoomOpen(Location location, Avatar avatar)
        {
            if(location.Open == false && location.GameFinished == false)
                {
                    
                    foreach (var i in avatar.Inventory)
                        {
                            if(i.Title == "Geheimschlüssel")
                            {
                                final_key = true;
                            }
                            
                        }
                    if (final_key == true)
                    {
                        Console.WriteLine("Geschafft");
                        Console.WriteLine("Der Geheimschlüssel ist in deinem Besitz. Die Tür öffnet sich");
                        return location.Open = true;
                    }
                    else
                    {
                        Console.WriteLine("Der Geheimschlüssel ist nicht in deinem Besitz. Geh und finde ihn und versuche es nochmal");
                        return location.Open = false;
                    }
                }
            else return location.Open = true;
        }
    }
}