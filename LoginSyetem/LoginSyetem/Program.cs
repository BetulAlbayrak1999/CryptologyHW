using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
/*
 * this program is written by Betül ALBAYRAK for the encryption homework
 * Here we create a small login system. 
 * 1.fucntion we used for Registering new user,
 * 2. function for login operation. (in this fucntion using SHA256 hash, we controled the user if she/he registered before or not)
 * other details you can see them in the code
 */
namespace LoginSyetem
{
    class Program
    {
        static List<User> users = new List<User>();

        //register function
        public static void AddUser(User user) 
        {
            string hashedPassword = getHash(user.Password);

            users.Add(new User() { UserName = user.UserName, Password = hashedPassword });
        }

        //login function
        public static string Login(User user) 
        {
            string hashedPassword = getHash(user.Password);
            User currentUser = users.Find(c => (c.UserName == user.UserName) && (c.Password == hashedPassword));
            if (currentUser is null)
                return "you cannot enter to our website";
            return "Welcome to our website";
        } 
        static void Main(string[] args)
        {
            int number;

            do {                        //instructions
                Console.WriteLine("Hello! For entering new user press 1\n");
                Console.WriteLine("       For login press 2\n");
                Console.WriteLine("       For exit press 0\n");
                 number = int.Parse(Console.ReadLine());

                if (number == 1) {      //Registering new user
                    Console.WriteLine("Hello! Enter your UserName, then your Password please.\n");
                    User user = new User();
                    Console.WriteLine("Enter your UserName:");
                    user.UserName = Console.ReadLine();
                    Console.WriteLine("Enter your Password:");
                    user.Password = Console.ReadLine();
                    AddUser(user);
                }
                else if (number == 2) {  //login
                    Console.WriteLine("Hello! Enter your UserName, then your Password please.\n");
                    User user = new User();
                    Console.WriteLine("Enter your UserName:");
                    user.UserName = Console.ReadLine();
                    Console.WriteLine("Enter your Password:");
                    user.Password = Console.ReadLine();
                    string result = Login(user);
                    Console.WriteLine(result);
                }
                else if (number != 0){ Console.WriteLine("Opss, You have entered a wrong number, so enter agian\n"); }

            } while (number != 0);
        }

        //hash function
        private static string getHash(string text)
        {
            // SHA512 is disposable by inheritance.  
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                // Get the hashed string.  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

    }
    public class User 
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
