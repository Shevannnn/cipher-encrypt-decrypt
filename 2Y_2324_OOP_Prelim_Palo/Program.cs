using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_2324_OOP_Prelim_Palo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> initialList = new List<string>() {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
            List<string> cipherList = InitializeList(initialList);

            //CheckLists(initialList, cipherList);
            Choice(initialList, cipherList);
        }

        static void CheckLists(List<string> initialList, List<string> cipherList)
        {
            foreach (string l in initialList)
            {
                Console.Write(l + ",");
            }
            Console.WriteLine("");
            foreach (string l in cipherList)
            {
                Console.Write(l + ",");
            }
            Console.WriteLine("\n\nPress any key to cont");
            Console.ReadKey();
        }

        static List<string> InitializeList(List<string> initialList)
        {
            List<string> temp = new List<string>();
            foreach (string l in initialList)
            {
                temp.Add(l);
            }
            return temp;
        }

        static void Choice(List<string> initialList, List<string> cipherList)
        {
            string key = "";
            string message = "";
            string eMessage = "";
            string uInput = GetuInput();

            Console.WriteLine("Machine Mode has been set.");
            Console.ReadKey();
            Console.Clear();
            Console.Write("What is the key you want to set? : ");

            key = Console.ReadLine().ToUpper();
            cipherList = ReformatList(initialList, RemoveDupes(key));

            Console.WriteLine("Cipher has been set.");
            Console.ReadKey();
            Console.Clear();

            if (uInput == "E")
            {
                Console.WriteLine("Please input the message you want to encrypt :");
                message = Console.ReadLine().ToUpper();
                eMessage = Encrypt(message, initialList, cipherList);
                WriteFile(eMessage);
            }
            else if (uInput == "D")
            {
                Console.WriteLine("Reading eMessage.txt and decrypting using the provided key.");
                eMessage = ReadFile();
                message = Decrypt(eMessage, initialList, cipherList);
                Console.WriteLine("The decrypted message is: ");
                Console.WriteLine(message);
                Console.WriteLine("Message has been successfully decrypted.");
            }

            Console.WriteLine("Press any key to close the program");
            Console.ReadKey();
        }

        static string GetuInput()
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

        static string RemoveDupes(string cipher)
        {
            string temp = "";
            foreach(char c in cipher)
            {
                if (!temp.Contains(c))
                    temp += c;
            }
            return temp;
        }

        static List<string> ReformatList(List<string> initialList, string cipher)
        {
            List<string> temp = new List<string>();
            string filter = "";
            int index = 0;

            // filter special chars
            foreach (char c in cipher)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    filter += c;
                }
            }
            cipher = filter;

            // if letter is not in cipher add it
            foreach (string c in initialList)
            {
                if (!cipher.Contains(c))
                {
                    temp.Add(c);
                }
            }

            // insert the letters in cipher to the list(no dupes thanks to previous method)
            foreach (char c in cipher)
            {
                if (index < temp.Count)
                {
                    temp.Insert(index, c.ToString());
                    index++;
                }
                else
                {
                    temp.Add(c.ToString());
                }
            }

            return temp;
        }

        static string Encrypt(string message, List<string> initialList, List<string> cipherList)
        {
            List<string> temp = new List<string>();
            string eMessage = "";

            foreach (char c in message)
            {
                string letter = c.ToString();
                int index = initialList.IndexOf(letter);

                if (index != -1)
                {
                    temp.Add(cipherList[index]);
                }
                else
                {
                    temp.Add(letter); // Special characters or spaces remain unchanged
                }
            }

            eMessage = string.Join("", temp); // Combine the encrypted letters
            return eMessage;
        }

        static string Decrypt(string eMessage, List<string> initialList, List<string> cipherList)
        {
            List<string> message = new List<string>();

            foreach (char c in eMessage)
            {
                string letter = c.ToString();
                int index = cipherList.IndexOf(letter);

                if (index != -1)
                {
                    message.Add(initialList[index]);
                }
                else
                {
                    message.Add(letter); // Special characters or spaces remain unchanged
                }
            }

            return string.Join("", message);
        }

        static void WriteFile(string eMessage)
        {
            using (StreamWriter sw = new StreamWriter("eMessage.txt"))
            {
                sw.Write(eMessage);
            }
            Console.WriteLine("Message has been successfully encrypted and written to eMessage.txt.");

        }

        static string ReadFile()
        {
            string line = "";
            string temp = "";
            string eMessage = "";
            using (StreamReader sr = new StreamReader("eMessage.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    temp = line;
                }
            }
            return eMessage = temp;
        }
    }
}
