using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_2324_OOP_Prelim_Palo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string uInput = Method1();

            // Try to make cipher manually, then try in given program
            // substitution cipher

            if (uInput == "E")
                Encrypt();
            else if (uInput == "D")
                Decrypt();

            Console.WriteLine("Press any key to close the program");
            Console.ReadKey();
        }

        static string Method1() 
        {
            while (true)
            {
                Console.Write("Would you like to encrypt or decrypt a message? [E / D] : ");
                string uInput = Console.ReadLine().ToUpper();
                if (uInput == "E")
                    return "E";
                else if (uInput == "D")
                    return "D";
                else
                {
                    Console.WriteLine("Invalid Setting please try again. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void Encrypt()
        {
            string cipher = "";
            string message = "";
            string eMessage = "";

            Console.WriteLine("Machine Mode has been set.");
            Console.ReadKey();
            Console.Clear();
            Console.Write("What is the key you want to set? : ");
            cipher = Console.ReadLine();
            Console.WriteLine("Cipher has been set.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Please input the message you want to encrypt :");
            message = Console.ReadLine();

            //Encrypt program here
            eMessage = message;

            WriteFile(eMessage);
            Console.WriteLine("Message has been successfully encrypted and written to eMessage.txt.");
        }

        static void Decrypt()
        {
            string cipher = "";
            string message = "";
            string eMessage = "";

            Console.WriteLine("Machine Mode has been set.");
            Console.ReadKey();
            Console.Clear();
            Console.Write("What is the key you want to set? : ");
            cipher = Console.ReadLine();
            Console.WriteLine("Cipher has been set.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Reading eMessage.txt and decrypting using the provided key.");

            ReadFile(out eMessage);
            //decrypt
            message = eMessage;



            Console.WriteLine("The decrypted message is: ");
            Console.WriteLine(message);
            Console.WriteLine("Message has been successfully decrypted.");
        }

        static void WriteFile(string eMessage)
        {
            using (StreamWriter sw = new StreamWriter("eMessage.txt"))
            {
                sw.Write(eMessage);
            }
        }

        static void ReadFile(out string eMessage)
        {
            string line = "";
            string temp = "";
            using (StreamReader sr = new StreamReader("eMessage.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    temp = line;
                }
            }
            eMessage = temp;
        }

    }
}
