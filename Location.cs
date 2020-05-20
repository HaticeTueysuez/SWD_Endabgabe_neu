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

        public Location(int roomNumber, string title, string description, bool open, bool gameFinished)
        {
            RoomNumber = roomNumber;
            Title = title;
            Description = description;
            Open = open;
            GameFinished = gameFinished;
        }
        public static Location MapSetUp(List<Location> locations)
        {
            Location entrance = new Location(locations[0].RoomNumber, locations[0].Title, locations[0].Description, locations[0].Open, locations[0].GameFinished);
            Location hall = new Location(locations[1].RoomNumber, locations[1].Title, locations[1].Description, locations[1].Open, locations[1].GameFinished);
            Location cafeteria = new Location(locations[2].RoomNumber, locations[2].Title, locations[2].Description, locations[2].Open, locations[2].GameFinished);
            Location patientroom = new Location(locations[3].RoomNumber, locations[3].Title, locations[3].Description, locations[3].Open, locations[3].GameFinished);
            Location operationroom = new Location(locations[4].RoomNumber, locations[4].Title, locations[4].Description, locations[4].Open, locations[4].GameFinished);

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