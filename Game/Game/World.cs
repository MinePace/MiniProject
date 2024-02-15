using System.Diagnostics.Contracts;

class World
{   
    public void Text_Display(string text)
    {
        string[] lines = text.Split('\n');
        foreach (string line in lines)
        {
            for (int i = 0; i < line.Length; ++i)
            {
                Thread.Sleep(20);
                Console.Write("\r{0}", line.Substring(0, i + 1));
            }
            Thread.Sleep(200); // Add a pause between lines
            Console.WriteLine(); // Move to the next line
        }
    }

    public string MovePlayer(string currentPos)
    {
        string NewLocation = currentPos;
        Console.WriteLine("Where do you want to go?");
        Console.WriteLine("These are the directions to go to.");
        Compass(currentPos);

        bool check = true;
        while(check)
        {
            string input = Console.ReadLine();
            if(input == "N" || input =="S" || input =="E" || input =="W")
            {
                if (currentPos == "Your House")
                {
                    switch(input)
                    {
                        case "N":
                            NewLocation = "Town Square";
                            check = false;
                            break;

                        default:
                            Console.WriteLine("That is not a valid input.");
                            break;

                    }
                }

                else if(currentPos == "Town Square")
                {
                    switch(input)
                    {
                        case "N":
                            NewLocation = "Alchemist's Hut";
                            check = false;
                            break;

                        case "S":
                            NewLocation = "Hour House";
                            check = false;
                            break;

                        case "E":
                            NewLocation = "Guard Post";
                            check = false;
                            break;

                        case "W":
                            NewLocation = "Farmer";
                            check = false;
                            break;

                        default:
                            Console.WriteLine("That is not a valid input.");
                            break;

                    }
                }

                else if(currentPos == "Alchemist's Hut")
                {
                    switch(input)
                    {
                        case "N":
                            NewLocation = "Alchemist's Garden";
                            check = false;
                            break;

                        case "S":
                            NewLocation = "Town Square";
                            check = false;
                            break;

                        default:
                            Console.WriteLine("That is not a valid input.");
                            break;                    

                    }
                }

                else if(currentPos == "Alchemist's Garden")
                {
                    switch(input)
                    {
                        case "S":
                            NewLocation = "Alchemist's Hut";
                            check = false;
                            break;

                        default:
                            Console.WriteLine("That is not a valid input.");
                            break;                    

                    }
                }

                else if(currentPos == "Famer")
                {
                    switch(input)
                    {
                        case "E":
                            NewLocation = "Town Square";
                            check = false;
                            break;

                        case "W":
                            NewLocation = "Farmer's Field";
                            check = false;
                            break;

                        default:
                            Console.WriteLine("That is not a valid input.");
                            break;                    

                    }
                }

                else if(currentPos == "Farmer's Field")
                {
                    switch(input)
                    {
                        case "E":
                            NewLocation = "Farmer";
                            check = false;
                            break;

                        default:
                            Console.WriteLine("That is not a valid input.");
                            break;                    

                    }
                }
                else if(currentPos == "Guard Post")
                {
                    switch(input)
                    {
                        case "E":
                            NewLocation = "Bridge";
                            check = false;
                            break;

                        case "W":
                            NewLocation = "Town Square";
                            check = false;
                            break;

                        default:
                            Console.WriteLine("That is not a valid input.");
                            break;                 

                    }
                }

                else if(currentPos == "Bridge")
                {
                    switch(input)
                    {
                        case "E":
                            NewLocation = "Spider Forest";
                            check = false;
                            break;

                        case "W":
                            NewLocation = "Guard Post";
                            check = false;
                            break;

                        default:
                            Console.WriteLine("That is not a valid input.");
                            break;

                    }
                }

                else if(currentPos == "Spider Forest")
                {
                    switch(input)
                    {
                        case "W":
                            NewLocation = "Bridge";
                            check = false;
                            break;

                        default:
                            Console.WriteLine("That is not a valid input.");
                            break;

                    }
                }
            }

            else{Console.WriteLine("That is not a valid input.");}
        

        }
        Console.WriteLine($"Moving to {NewLocation}");
        return NewLocation;
    }

    public void Compass(string Location)
    {
        string North = @"N
|
/
        ";

        string South = @"/
|
S
";

        string East = @"/--E";

        string West = @"W--/";

        string NorthSouth = @"N
|       
/
|
S
";

        string EastWest = @"W--/--E";

        string Centre = @"   N
   |
W--+--E
   |
   S        
";


        if(Location == "Your House")
        {
            Console.WriteLine(North);
        }
        if(Location == "Town Square")
        {
            Console.WriteLine(Centre);
        }
        if(Location == "Farmer")
        {
            Console.WriteLine(EastWest);
        }
        if(Location == "Farmer's Fields")
        {
            Console.WriteLine(East);
        }
        if(Location == "Alchemist’s Hut")
        {
            Console.WriteLine(NorthSouth);
        }
        if(Location == "Alchemist’s Garden")
        {
            Console.WriteLine(South);
        }
        if(Location == "Guard Post")
        {
            Console.WriteLine(EastWest);
        }
        if(Location == "Bridge")
        {
            Console.WriteLine(EastWest);
        }
        if(Location == "Spider Forest")
        {
            Console.WriteLine(West);
        }
    }

    public bool locations(string direction, string location)
    {
        switch(location)
        {
            case "Your House":
                if(direction == "N")
                {
                    return true;
                }
                break;

        }
        Console.WriteLine("That is not a valid direction.");
        return false;
    }
}

 // test