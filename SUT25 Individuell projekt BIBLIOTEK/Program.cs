using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT25_Individuell_projekt_BIBLIOTEK
{
    internal class Program
    {
        // Below are predefined available copies of the books 
        static int[] availableAmount = { 3, 3, 3, 3, 3 };

        static int[] borrowedAmount = { 0, 0, 0, 0, 0 };

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


        // Keeps track of which user is logged in. (-1 means that NO-one is logged in)
        static int loggedInUserIndex = -1;

        static int[,] bookLoans = new int[5, 5]
        {
            {0,0,0,0,0 },
            {0,0,0,0,0 },
            {0,0,0,0,0 },
            {0,0,0,0,0 },
            {0,0,0,0,0 }
        };


        // Global Variables
        // These arrays hold username data for 5 predefined users
        //static string[] användarnamn = { "cornelia", "jojje", "bella", "nathalie", "max" };
        //static string[] pinKoder = { "0000", "1111", "2222", "3333", "4444" };
        static string[] books = { "The Little Mermaid", "Outlander", "My Demon", "Grekiska För Nybörjare", "Programmering 1 med C#" };

        // Available Books in the library: [booktitle, total amount of copies]
        //static string[] VisaTillgängligaBöcker =
        //{
        //    "The Little Mermaid",
        //    "Outlander",
        //    "My Demon",
        //    "Grekiska För Nybörjare",
        //    "Programmering 1 med C#"
        //};


        // Each user (5 users) may borrow a total of 3 copies per book
        // The row index shows: userindex, password index, and which book they've chosen.
        static string[,] userData = new string[5, 2]
        {
            { "cornelia", "0000"},
            { "jojje", "1111"},
            { "bella", "2222"},
            { "nathalie", "3333"},
            { "max", "4444"}

        };

        static void Main(string[] args)
        {
            while (true)
            {
                if (loggedInUserIndex == -1)
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

        // This method displays the main menu after a successful login
        static void VisaHuvudMeny()
        {
            Console.Clear();
            Console.WriteLine("********** HUVUDMENY **********\n");// giving an extra space between title and menu choices
            Console.WriteLine("1. Visa tillgängliga böcker");
            Console.WriteLine("2. Låna en bok");
            Console.WriteLine("3. Lämna tillbaka en bok");
            Console.WriteLine("4. Mina lån");
            Console.WriteLine("5. Logga ut");
            Console.WriteLine("6. Avsluta programmet");
            Console.Write("Välj ett alternativ: ");
            string val = Console.ReadLine();

            switch (val)
            {
                case "1":
                    ShowBooks();// How do i call upon the list to help the user see available books?
                    //Console.WriteLine("Funktion för att visa böcker saknas.");
                    Console.ReadKey();
                    break;
                case "2":
                    LånaBok();
                    Console.WriteLine();
                    Console.ReadKey();
                    break;
                case "3":
                    //ReturnBook();
                    // Lämna tillbaka en bok (implementera vid behov)
                    Console.WriteLine("Lämna tillbaka en bok.");
                    Console.ReadKey();
                    break;
                case "4":
                    MyLoans();
                    break;
                case "5":
                    loggedInUserIndex = -1;
                    Console.WriteLine("Du har loggat ut.");
                    Console.ReadKey();
                    break;
                case "6":
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
                for (int i = 0; i < userData.GetLength(0); i++)
                {
                    if (userData[i, 0] == inputAnvändare && userData[i, 1] == inputPin)
                    {
                        loggedInUserIndex = i; // Stores which user logged in.
                        Console.WriteLine("\n Inloggning Lyckades!");
                        return true;

                    }

                }

                Console.WriteLine("Fel användarnamn eller PIN-kod. Försök igen.\n");
            }

            return false; // only return false after 3 attempted fails
        }

        // This Method is to show the available books existing in the library
        static void ShowBooks()

        {
            Console.WriteLine("\nTillgängliga böcker:");
            for (int i = 0; i < books.Length; i++)
            {
                int total = availableAmount[i] - borrowedAmount[i];
                Console.WriteLine($"{i + 1}. {books[i]} - tillgängliga: {availableAmount[i]}/{total}");
            }
            Console.WriteLine("\nTryck på valfri tangent för att återgå till Huvudmenyn...");

            Console.ReadKey();
        }

        // Method to use and store the CHOICE the user makes from the library of books. 
        // Keywords to remember here are perhaps: LÅNA BOK (title), ANVÄNDARENSVAL, CHOSENBOXINDEX
        static void LånaBok()
        {
            Console.Clear();
            int användarensVal = 0;
            Console.WriteLine("\nLåna en Bok: "); // see below: console.readline is just to make sure that user inputs and ACTUAL NUMBER.
            Console.WriteLine("Choose a number between 1 - 5:");
            for (int i = 0; i < books.Length; i++)
            {
                int available = availableAmount[i] - borrowedAmount[i];
                Console.WriteLine($"{i + 1}. {books[i]} - tillgängliga: {available}/{availableAmount[i]}");
            }


            while (!int.TryParse(Console.ReadLine(), out användarensVal) || användarensVal < 1 || användarensVal > 5)
            {
                Console.WriteLine("Choose a number between 1 - 5:");
            }


            int chosenBookIndex = användarensVal - 1;
            if (availableAmount[chosenBookIndex] > 0)
            {
                Console.WriteLine("Denna bokeen är tillgänglig för lån ");
                Console.WriteLine($"Du har valt att låna {books[chosenBookIndex]}");
                availableAmount[chosenBookIndex] -= 1;
                borrowedAmount[chosenBookIndex] += 1;
                //vilken data vill jag ändra
                bookLoans[loggedInUserIndex, chosenBookIndex] += 1;

            }
            else
            {

                Console.WriteLine("Tyvärr, finns det inga exemplar att låna ut.");
            }
        }

        // MyLoans() - vad förväntar sig användaren att se.
        static void MyLoans()
        {
            Console.Clear();
            Console.WriteLine("==========My Loans=======");
            Console.WriteLine($"Användare: {userData[loggedInUserIndex, 0]}\n");

            //Check if the user has any loans
            bool hasLoans = false;
            //int totalAntalLån = 0;

            for (int i = 0; i < books.Length; i++)
            {
     
                if (bookLoans[loggedInUserIndex, i] > 0)
                {
                    hasLoans = true; // This is set to true ONLY if a book is borrowed
                    Console.WriteLine($"· {books[i]} - Antal: {bookLoans[loggedInUserIndex, i]}");
                }
            }

            // If there are NO loans, show the following info-message to the user.
            if (!hasLoans)
            {
                Console.WriteLine("Du har inga aktiva lån just nu.");
            }
            Console.WriteLine("\nTryck på valfri tangent för att återgå till huvudmenyn...");
            Console.ReadKey();
        }

        

    }
}








//        {
//            ////int chosenBookIndex = -1;
//            //Console.Clear();

//            //// Show the list av all books again so the user can choose the book on the list according to the numerical list
//            //for (int i  = 0; i < VisaTillgängligaBöcker.Length; i++)
//            //{
//            //    Console.WriteLine($"{i + 1}. {VisaTillgängligaBöcker[i]}");
//            //}

//            //// Ask the user which book they'd like to return.
//            //Console.WriteLine("Skriv numre på boken du vill lämna tillbaka: ");
//            //int användarensVal = int.Parse(Console.ReadLine());
//            //int chosenBookIndex = användarensVal - 1;

//            //// 

//            //bool anyLent = false;
//            //// for loop här innan en eventuell if vilkor sats?
//            //if (utlånadeExemplar[chosenBookIndex] > 0)
//            //{
//            //    utlånadeExemplar[chosenBookIndex] -=1;
//            //    totalAntalExemplar[chosenBookIndex] += 1;
//            //    Console.WriteLine($"Du har lämnat tillbaka { [chosenBookIndex]}");
//            //}
//        }
//    }
//}


//    Console.Clear(); // gives the user a fresh start if they've written the wrong PIN. When they restart the login screen, we want a new clean message.


//    int attempts = 0;
//    while (attempts <= 3) // We tell the program that the User only has 3 attempts to write the correct PIN code
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