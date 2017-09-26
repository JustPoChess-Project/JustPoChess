using System;
using JustPoChess.Remaster.Client.MVC.View.Contracts;


namespace JustPoChess.Remaster.Client.MVC.View.ConsoleClient
{
    public class ConsoleReader:IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}