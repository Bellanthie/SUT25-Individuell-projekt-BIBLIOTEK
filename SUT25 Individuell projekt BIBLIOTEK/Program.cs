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

        // Method  to show available books in the library
        static void VisaTillgängligaBöcker()
        {
            Console.WriteLine("\nTillgängliga böcker:");
            for (int i = 0; i < bokTitlar.Length; i++)
            {
                int kvar = totalAntalExemplar[i] - utlånadeExemplar[i];
                Console.WriteLine($"{i + 1}. {bokTitlar[i]} ({kvar}) exemplar kvar");
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                if (inloggadAnvändare == -1)
                {
                    if (!LoggaIn())
                    {
                        Console.WriteLine("Inloggning misslyckades.");
                        break;
                    }
                }
                else
                {
                    VisaHuvudMeny();
                }
            }
        }


        // Below are predefined available copies of the books 
        static int[] totalAntalExemplar = { 5, 2, 3, 4, 6 };


        // To keep track of how many copies of each book are lent/borrowed
        static int[] utlånadeExemplar = { 0, 0, 0, 0, 0 };

        // Each user (5 users) may borrow a total of 3 copies per book
        // The row index shows: userindex, columnindex = place from where it's been borrowed
        static int[,] användareLån = new int[5, 3]
        {
            { -1, -1, -1 },
            { -1, -1, -1 },
            { -1, -1, -1 },
            { -1, -1, -1 },
            { -1, -1, -1 }
        };


        // This method displays the main menu after a successful login
        static void VisaHuvudMeny()
        {
            Console.Clear();
            Console.WriteLine("********** HUVUDMENY **********\n");// giving an extra space between title and menu choices
            Console.WriteLine("1. Visa tillgängliga böcker");
            Console.WriteLine("2. Låna en bok");
            Console.WriteLine("3. Lämna tillbaka en bok");
            Console.WriteLine("4. Logga ut");
            Console.WriteLine("5. Avsluta programmet");
            Console.Write("Välj ett alternativ: ");
            string val = Console.ReadLine();

            switch (val)
            {
                case "1":
                    // Visa tillgängliga böcker (implementera vid behov)
                    //Console.WriteLine("Funktion för att visa böcker saknas.");
                                        Console.ReadKey();
                    break;
                case "2":
                    // Låna en bok (implementera vid behov)
                    Console.WriteLine("Funktion för att låna bok saknas.");
                    Console.ReadKey();
                    break;
                case "3":
                    // Lämna tillbaka en bok (implementera vid behov)
                    Console.WriteLine("Funktion för att lämna tillbaka bok saknas.");
                    Console.ReadKey();
                    break;
                case "4":
                    inloggadAnvändare = -1;
                    Console.WriteLine("Du har loggat ut.");
                    Console.ReadKey();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    Console.ReadKey();
                    break;
            }
        }

        // METHOD 1
        // This method handles the user's login with 3 tries.
        // It returns true if the login is a success. Otherwise, it returns false
        static bool LoggaIn()
        {
            Console.Clear();
            Console.WriteLine("**********************************************");
            Console.WriteLine("   VÄLKOMMEN TILL BIBLIOTEKETS LÅNESYSTEM!");
            Console.WriteLine("**********************************************");


            // The user has a total of 3 tries to log in
            int antalFörsök = 3;

            // The following loop runs 3 times
            for (int försök = 0; försök < antalFörsök; försök++)
            {
                // Ask for username
                Console.Write("Ange ditt användarnamn: ");
                string inputAnvändare = Console.ReadLine().ToLower().Trim(); // makes sure that the user's input is converted to all lowercase to minimise capslock errors

                // Ask user for the Pincode
                Console.Write("Ange PIN-kod: ");
                string inputPin = Console.ReadLine();
                for (int i = 0; i < användarnamn.Length; i++)
                {
                    if (användarnamn[i] == inputAnvändare && pinKoder[i] == inputPin)
                    {
                        inloggadAnvändare = i; // Stores which user logged in.
                        Console.WriteLine("\n Inloggning Lycades!");
                        return true;

                    }

                }

                Console.WriteLine("Fel användarnamn eller PIN-kod. Försök igen.\n");
                return false; // login failed after 3 tries
            }

            return false; // only return false after 3 attempted fails
        }
    }
}










//        Console.WriteLine("Välkommen till detta lånesystem!");
//            Console.WriteLine("Vänligen skriv in ditt användarnamn och PIN kod:\n"); // \n creates an extra space separate to what Console.WriteLine already does, giving a cleaner look.
//            bool isLoggedIn = Login();

//                if (isLoggedIn)
//            {
//                Console.WriteLine("Inloggning lyckades! Välkommen in!");
//            }
//            else
//            {
//                Console.WriteLine("Inloggning misslyckades. Programmet");
//                Environment.Exit(0); //small but powerful code telling the computer to STOP right now.
//                // The zero, tells the computer to STOP the program AND that there are no problems.
//            }                
//        }


//        private static bool Login()


//        // Creating a method to welcome user to the Library system.
//        // Incorporating that user has max 3 attempts to log in.
//        static bool userLogIn()// method used for users Login and pincode
//{
//    Console.Clear(); // gives the user a fresh start if they've written the wrong PIN. When they restart the login screen, we want a new clean message.


//    int attempts = 0;
//    while (attempts < 3) // We tell the program that the User only has 3 attempts to write the correct PIN code
//    {
//        Console.Write("Användarnamn: ");
//        string name = Console.ReadLine()?.Trim().ToLower() ?? ""; // <?. AND ??"">  protects the program from crashing.
//                                                                  // line 34 takes in the users userName, eliminating any accidental spaces <Trim()> and with <ToLower()> the program turns the username to small letters regardless of all capitals or lowercase.

//        Console.Write("PIN: ");
//        string pin = (Console.ReadLine() ?? "").Trim();// Here we see the ? "" usage again.reusing this to prevent the program from crashing.

//        int userId = FindUserIndex(name);
//        if (userId != -1 && pins[userId] == pin)
//        {
//            Console.WriteLine($"\nInloggad som {userNames[userId]}!\n");
//            Pause(); // This is a method that waits for the user to press 
//            return userId;
//        }




//            }

//        }
//    }
//}

