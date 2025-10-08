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
            Console.WriteLine("Välkommen till detta lånesystem!");
            Console.WriteLine("Vänligen skriv in ditt användarnamn och PIN kod:");
            Console.ReadLine();




        }

        // Creating a method to welcome user to the Library system.
        // Incorporating that user has max 3 attempts to log in.
        static int userLogIn()
        {
            Console.Clear(); // gives the user a fresh start if they've written the wrong PIN. When they restart the login screen, we want a new clean message.
            Console.WriteLine("Välkommen till bibliotekets lånesystem!\n"); // by adding \n, we create another space EVEN after CW giving a cleaner look.


        }
    }
}

