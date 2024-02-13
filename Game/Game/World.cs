class World
{   
    public void Text_Display(string text)
    {
        for (int i = 0; i < text.Length + 1; ++i)
        {
            Thread.Sleep(20);
            Console.Write("\r{0}", text.Substring(0, i));
        }
    }
}