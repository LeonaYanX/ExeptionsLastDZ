using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeptionsLastDZ
   
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the user info Name birthDate tel. Number sex ");
            string myInput = Console.ReadLine();
            string[] strArrayInput = myInput.Split(new char[] { ' ' });
            int telNumber = -1;
            DateTime birthDate = DateTime.Now.AddDays(2);
            string name = String.Empty;
            char sex = 'u';
            

            if (strArrayInput.Length<4) 
            {
                
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("You have entered less info!");
            }
            if (strArrayInput.Length >= 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("You have entered more info than needed!");
            }
            else
            {
                name = strArrayInput[0];
                char[] nameParts = name.ToCharArray();
                bool isLetter = false;
                for (int i = 0; i < nameParts.Length; i++)
                {
                    isLetter = Char.IsLetter(nameParts[i]);
                    if (!isLetter)
                    {
                        throw new Exception("Name is not written in write format");
                    }

                }

                if (DateTime.TryParse(strArrayInput[1], out birthDate))
                {
                    birthDate = DateTime.Parse(strArrayInput[1]);
                }
                else
                {
                    throw new Exception("There is no birth date in it's place");
                }
                if (int.TryParse(strArrayInput[2], out telNumber))
                {
                    telNumber = int.Parse(strArrayInput[2]);
                }
                else
                {
                    throw new InvalidOperationException("There is no telephone number on it's place");
                }

                if (strArrayInput[3] == "m" || strArrayInput[3] == "f")
                {
                    sex = char.Parse(strArrayInput[3]);
                }
                else
                {
                    throw new FormatException("There is no sex in it's place");
                }
                try 
                {
                    using (StreamWriter writer = new StreamWriter($"{name}.txt", true))
                    {
                        writer.WriteLine($"Name: {name} , birth date : {birthDate} , Telephone number : {telNumber} , gender: {(sex == 'f' ? "female" : "male")}");
                    }
                    Console.WriteLine("Done.");
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error {e.Message}");
                }


            }

              







            
        }
    }
}
