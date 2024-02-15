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
}

 // test