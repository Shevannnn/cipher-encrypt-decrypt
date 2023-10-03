using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
            cipherList = ReformatList(cipherList, RemoveDupes(key));

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
                Console.WriteLine(eMessage);
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

        static List<string> ReformatList(List<string> cipherList, string cipher)
        {
            for (int i = 0; i < cipherList.Count; i++)
            {
                for (int j = 0; j < cipher.Length; j++)
                {
                    if (cipher[j].ToString() == cipherList[i])
                    {
                        cipherList.RemoveAt(i);
                        j = 0; // start over first letter just to make sure
                    }
                }
            }

            // Insert the key to list
            for (int j = 0; j < cipher.Length; j++)
            {
                cipherList.Insert(j, cipher[j].ToString());
            }

            return cipherList;
        }

        static string Encrypt(string message, List<string> initialList, List<string> cipherList)
        {
            List<string> temp = new List<string>();
            string eMessage = "";
            List<string> letters = new List<string>();

            foreach (char c in message)
            {
                letters.Add(c.ToString());
            }

            foreach (string letter in letters)
            {
                if (initialList.Contains(letter))
                {
                    int index = temp.IndexOf(letter);
                    temp.Add(cipherList[index]);
                }
                else
                {
                    temp.Add(letter); // special chars
                }
            }

            foreach (string letter in temp)
            {
                eMessage = letter;
                //Console.WriteLine(eMessage);
                //Console.ReadKey();
            }

            return eMessage;
        }

        static string Decrypt(string eMessage, List<string> initialList, List<string> cipherList)
        {
            //string message = "";

            List<string> message = new List<string>();

            foreach (char c in eMessage)
            {
                if (cipherList.Contains(c.ToString()))
                {
                    int index = cipherList.IndexOf(c.ToString());
                    message.Add(initialList[index]);
                }
                else
                {
                    message.Add(c.ToString()); // special chars
                }
            }

            return string.Join("", message);

            //return message;
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
