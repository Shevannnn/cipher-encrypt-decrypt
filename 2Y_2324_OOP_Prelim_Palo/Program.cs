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
            //string uInput = Method1();
            string cipher = "";
            List<string> initialList = new List<string>() {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
            List<string> cipherList = InitializeList(initialList);

            CheckLists(initialList, cipherList);

            // Try to make cipher manually, then try in given program
            // substitution cipher

            Encrypt(initialList, cipherList);

            Console.WriteLine("Press any key to close the program");
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

        static void Encrypt(List<string> initialList, List<string> cipherList)
        {
            string cipher = "";
            string message = "";
            string eMessage = "";

            Console.WriteLine("Machine Mode has been set.");
            Console.ReadKey();
            Console.Clear();
            Console.Write("What is the key you want to set? : ");

            cipher = Console.ReadLine().ToUpper();
            cipherList = ReformatList(cipherList, RemoveDupes(cipher));

            Console.WriteLine("Cipher has been set.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Please input the message you want to encrypt :");
            message = Console.ReadLine();





            //Encrypt program here
            cipher = message;




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
