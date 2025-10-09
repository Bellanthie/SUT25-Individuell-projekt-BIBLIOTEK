using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT25_Individuell_projekt_BIBLIOTEK
{
    internal class Program
    {

        static void Main(string[] args)
        {
            /* static void SayHello()
             * {
             *      Console.WriteLine("Hej där!");
             *      *** EVERYTHING STARTS HERE. THE PROGRAM STARTS HERE. ALWAYS
             * */

            Console.WriteLine("Välkommen till detta lånesystem!");
            Console.WriteLine("Vänligen skriv in ditt användarnamn och PIN kod:");
            bool isLoggedIn = Login();
                if (isLoggedIn)
            {
                Console.WriteLine("Inloggning lyckades! Välkommen in!");
            }
            else
            {
                Console.WriteLine("Inloggning misslyckades. Programmet");
                Environment.Exit(0); //small but powerful code telling the computer to STOP right now.
                // The zero, tells the computer to STOP the program AND that there are no problems.
            }
                userLogIn();



        }

        // Creating a method to welcome user to the Library system.
        // Incorporating that user has max 3 attempts to log in.
        static void userLogIn()
        {
            Console.Clear(); // gives the user a fresh start if they've written the wrong PIN. When they restart the login screen, we want a new clean message.
            Console.WriteLine("Välkommen till bibliotekets lånesystem!\n"); // by adding \n, we create another space EVEN after CW giving a cleaner look. En visuell andnings paus för användaren.

            int attempts = 0;
            while (attempts < 3) // We tell the program that the User only has 3 attempts to write the correct PIN code
            {
                Console.Write("Användarnamn: ");
                string name = Console.ReadLine()?.Trim().ToLower() ?? ""; // <?. AND ??"">  protects the program from crashing.
                // line 34 takes in the users userName, eliminating any accidental spaces <Trim()> and with <ToLower()> the program turns the username to small letters regardless of all capitals or lowercase.

                Console.Write("PIN: ");
                string pin = (Console.ReadLine() ?? "").Trim();// Here we see the ? "" usage again.reusing this to prevent the program from crashing.

                int userId = FindUserIndex(name);
                if (userId != -1 && pins[userId] == pin)
                {
                    Console.WriteLine($"\nInloggad som {userNames[userId]}!\n");
                    Pause(); // This is a method that waits for the user to press 
                    return userId;
                }




            }

        }
    }
}

