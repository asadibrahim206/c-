using System;


class PaymentProcessor
{
    static void Main()
    {
        string path = "README.md";
        if(File.Exists(path))
        {
            string content = File.ReadAllText(path);
            Console.WriteLine("file content");
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("file does not exist");
        }
    }
}