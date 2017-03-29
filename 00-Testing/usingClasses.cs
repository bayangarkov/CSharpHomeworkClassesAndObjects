using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace _00_Testing
{
    class usingClasses
    {
        static void Main()
        {
            Console.WriteLine("Login or Register?");
            
            var inputLine = Console.ReadLine();

            var allUsers = new users();

            int counter = 0;

            allUsers.Name = new List<string>();
            allUsers.Pass = new List<string>();

            // registration form

            if (inputLine == "register")
            {
                Console.WriteLine("Enter User and Pass and type login:");
                inputLine = Console.ReadLine();

                while (inputLine != "login")
                {
                    var splitted = inputLine.Split(' ');

                    var inputName = splitted[0];
                    var inputPass = splitted[1];
                    
                    allUsers.Name.Add(inputName);
                    allUsers.Pass.Add(inputPass);

                    Console.WriteLine("Enter Username and Password:");
                    inputLine = Console.ReadLine();
                }
            }

            // validation logic for checking if user exist and password for current user is same

            if (inputLine == "login")
            {
                loginForm:

                inputLine = Console.ReadLine();

                while (true)
                {
                    var splitted = inputLine.Split(' ');

                    var inputName = splitted[0];
                    var inputPass = splitted[1];

                    if (allUsers.Name.Contains(inputName)) // if username exist?
                    {
                        counter = checkForPosition(allUsers, counter, inputName);

                        // if pass on specific user exist?

                        if (allUsers.Name.Contains(inputName) && allUsers.Pass[counter] == inputPass)
                        {
                            Console.WriteLine(Environment.NewLine + "Login successfull!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong Username or Password");
                            goto loginForm;
                        }
                    }

                    inputLine = Console.ReadLine();
                }
            }

            // printing some output
            printWelcomeMessage(allUsers, counter);

        }

        private static void printWelcomeMessage(users allUsers, int counter)
        {
            Console.WriteLine($"Hello {allUsers.Name[counter]} !!!");
            Console.WriteLine("Welcome to Home Page!");

            DateTime dt = DateTime.Now;

            Console.WriteLine($"Today is: {dt}");

            Console.WriteLine("---------------------");
        }

        // method for checking on witch position are username and pass
        private static int checkForPosition(users allUsers, int counter, string inputName)
        {
            foreach (var name in allUsers.Name)
            {
                if (inputName != name)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            return counter;
        }
    }
}