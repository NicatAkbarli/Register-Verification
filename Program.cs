using System;
using EmailVerificationApp.Helpers;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                Register();
            }
            else if (option == "2")
            {
                Login();
            }
            else if (option == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }

    private static void Register()
    {
        Console.Write("Enter your email: ");
        string email = Console.ReadLine();
        
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        // Doğrulama kodunu gönder
        VerificationCodeHelper.SendVerificationCode(email);

        // Kullanıcıdan doğrulama kodunu al
        Console.Write("Enter the verification code sent to your email: ");
        string userInputCode = Console.ReadLine();

        if (VerificationCodeHelper.ValidateCode(userInputCode))
        {
            UserHelper.RegisterUser(email, password);
            Console.WriteLine("Registration successful!");
        }
        else
        {
            Console.WriteLine("Invalid verification code. Registration failed.");
        }
    }

    private static void Login()
    {
        Console.Write("Enter your email: ");
        string email = Console.ReadLine();
        
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        if (UserHelper.ValidateUser(email, password))
        {
            Console.WriteLine("Login successful!");
        }
        else
        {
            Console.WriteLine("Invalid email or password. Login failed.");
        }
    }
}
