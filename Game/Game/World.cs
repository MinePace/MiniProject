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

    public void MovePlayer(string currentPos)
    {
        Console.WriteLine("Where do you want to go?");
        Console.WriteLine("These are the directions to go.");
        Compass(currentPos);
        while(true)
        {
            string input = Console.ReadLine();
            if(input == "N" || input =="S" || input =="E" || input =="W")
            {
                locations(input, currentPos);
            }
        }

        //Console.WriteLine($"Moving to {NewLocation}"); 
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

    public void locations(string diraction, string location)
    {
        switch(location)
        {
            case "Your House":
                if(diraction != "N")
                {
                    Console.WriteLine("That is not a valid diraction.");
                }
                break;

        }
    }
}

 // test