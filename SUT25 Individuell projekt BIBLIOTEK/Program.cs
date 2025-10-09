using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT25_Individuell_projekt_BIBLIOTEK
{
    internal class Program
    {
        // Global Variables
        // These arrays hold username data for 5 predefined users
        static string[] användarnamn = { "cornelia", "jojje", "bella", "nathalie", "max" };
        static string[] pinKoder = { "0000", "1111", "2222", "3333", "4444" };

        // Keeps track of which user is logged in. (-1 means that NO-one is logged in)
        static int inloggadAnvändare = -1;

        // Available Books in the library: [booktitle, total amount of copies]
        static string[] bokTitlar =
        {
            "The Little Mermaid",
            "Outlander",
            "My Demon",
            "Grekiska För Nybörjare",
            "Programmering 1 med C#"
        };

        // Below are predefined available copies of the books 
        static int[] totalAntalExemplar = { 5, 2, 3, 4, 6 };


        // To keep track of how many copies of each book are lent/borrowed
        static int[] utlånadeExemplar = { 0, 0, 0, 0, 0 };





        static void Welcome_User_Main(string[] args)
        {
            var users = AmountUsers();
            var books = AmountBooks();

            while (true)
            {
                var user = Login(users);
                if (user == null)
                {
                    Console.WriteLine("för många felaktiga försök. Starta om programmet för att försöka igen.");
                    return;
                }

                RunMeny(user, books)
            }

        }    


            Console.WriteLine("Välkommen till detta lånesystem!");
            Console.WriteLine("Vänligen skriv in ditt användarnamn och PIN kod:\n"); // \n creates an extra space separate to what Console.WriteLine already does, giving a cleaner look.
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
        }
    

        private static bool Login()


        // Creating a method to welcome user to the Library system.
        // Incorporating that user has max 3 attempts to log in.
        static bool userLogIn()// method used for users Login and pincode
        {
            Console.Clear(); // gives the user a fresh start if they've written the wrong PIN. When they restart the login screen, we want a new clean message.
            

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

