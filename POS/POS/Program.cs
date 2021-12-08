using System;
using POS_Views;
namespace POS
{
        class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************** WELCOME TO POS ***************");
            App app = new App();
            app.mainMenu();
        }
    }
}
