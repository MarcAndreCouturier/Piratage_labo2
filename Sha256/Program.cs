// See https://aka.ms/new-console-template for more information
using System;
using System.Text;
using System.Security.Cryptography;

namespace labo2
{
     class Program
    {
        static void Main(String[] args)
        {
            StreamReader reader = new StreamReader("./input.txt");
            StreamWriter writer = new StreamWriter("./out.txt");
            using (SHA256 sha256Hash = SHA256.Create())
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine(); // donne un warning, mais j'ai déjà vérifier que le stream n'était pas vide?
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(line));
                    StringBuilder sb = new StringBuilder();
                    for(int i = 0; i < bytes.Length; i++)
                    {
                        sb.Append(bytes[i].ToString("x2"));
                        
                    }
                    writer.WriteLine(sb.ToString());
                    
                }
               
            }
            reader.Close();
            writer.Flush();
            writer.Close();
        }
    }
}