﻿namespace SkillsApp
{
    internal class Program
    {
        private const int MAX_LOGIN_ATTEMPTS = 3;
        static void Main(string[] args)
        {
            WelcomeMsg("Liam");
            // OLD CODE LoginUser("abc");

            if (LoginUser("abc"))
            {
                Console.WriteLine("Access granted to the application.");
            }
            else
            {
                Console.WriteLine("Maximum login attempts exceeded. Application will now exit");
            }

            //User Roles Method
            List<string> listOfRoles = new List<string> { "Noob", "Mid", "Sweat" };
            UserRoles(listOfRoles);
        }

        static void WelcomeMsg(string message)
        {
            Console.WriteLine($"Welcome, "+ message);
        }

        static void WelcomeUser(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username cannot be empty or null.", nameof(username));
            }

            Console.WriteLine($"Welcome, {username}");
        }

        static bool LoginUser(string correctPassword)
        {
            if (string.IsNullOrEmpty(correctPassword))
            {
                throw new ArgumentException("Password cannot be empty or null.", nameof (correctPassword));
            }

            int remainingAttempts = MAX_LOGIN_ATTEMPTS;

            while (remainingAttempts > 0)
            {
                Console.WriteLine("Please enter your password to access this application");
                Console.WriteLine($"Remaining attempts: {remainingAttempts}");

                string? userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Error: No password entered. Please try again");
                    remainingAttempts--;
                    continue;
                }

                if (correctPassword == userInput)
                {
                    Console.WriteLine("Login successful!");
                    return true;
                }

                Console.WriteLine("Incorrect Password. Please try again.");
                remainingAttempts--;
            }

            return false;
        }

        // OLD CODE
        //static void LoginUser(string password)
        //{
        //    for (int i = 3; i > 0; i--)
        //    {
        //        Console.WriteLine($"Please enter your password to access this application.\nYou will have {i} tries.");
        //        string? userInput = Console.ReadLine();
        //        if (string.IsNullOrEmpty(userInput))
        //        {
        //            Console.WriteLine("No password entered.");
        //        }
        //        else if (password == userInput)
        //        {
        //            Console.WriteLine("Login Successful.");
        //            break;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Incorrect Password");
        //        }
        //    }
        //}

        static void UserRoles(List <string> listOfRoles)
        {
            var i = 0;
            foreach (string role in listOfRoles)
            {
                i++;
                Console.WriteLine($"{i}. {role}");
            }

            Console.WriteLine("Please select a role to assign to your user");
            string? roleSelected = Console.ReadLine();

            if (string.IsNullOrEmpty(roleSelected))
            {
                Console.WriteLine("No role selected");
            }
            else if (!listOfRoles.Contains(roleSelected))
            {
                Console.WriteLine("Invalid role selected");
            }
            else
            {
                Console.WriteLine($"{roleSelected} added to user");
            }
        }
    }
}