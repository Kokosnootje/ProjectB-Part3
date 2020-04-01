using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class LogedIn
    {
        public static void LogedInMain()
        {
            Console.WriteLine("Type the number where you want to go");
            Console.WriteLine("[1] Home");
            Console.WriteLine("[2] Movies");
            Console.WriteLine("[3] Contact");
            Console.WriteLine("[4] Snacks");
            Console.WriteLine("[5] Log out");
            Console.Write("> ");
            string menuNumber = Console.ReadLine();
            if (menuNumber == "1")
            {
                LogedIn.LogedInMain();
            }
            else if (menuNumber == "2")
            {
                /// Movies
                Console.WriteLine("Movies");
                Console.WriteLine("Press ESC to go to Home");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {

                }
                else
                {
                    LogedIn.LogedInMain();
                }
            }
            else if (menuNumber == "3")
            {
                /// Movies
                Console.WriteLine("Contact");
                Console.WriteLine("Press ESC to go to Home");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    
                }
                else
                {
                    LogedIn.LogedInMain();
                }

            }
            else if (menuNumber == "4")
            {
                /// Movies
                Console.WriteLine("Snacks");
                Console.WriteLine("Press ESC to go to Home");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {

                }
                else
                {
                    LogedIn.LogedInMain();
                }
            }
            else if (menuNumber == "5")
            {
                /// Movies
                Console.WriteLine("Succesfully loged out");
                Login.loginMain();
            }
            else
            {
                Console.WriteLine("Please enter a valid option!");
                LogedIn.LogedInMain();
            }

        }
        }
    }