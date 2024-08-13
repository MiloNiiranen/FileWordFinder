using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Give file path: ");
        string filepath = Console.ReadLine();

        if (File.Exists(filepath))
        {
            Console.WriteLine("File has found!");

            string[] lines = File.ReadAllLines(filepath); // Reads files lines
            Console.WriteLine("Give a word you want to find, from the file: ");
            string srcWord = Console.ReadLine();

            int lineNumber = 0;
            bool found = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(new char[] { ' ', '\r', '\n', '\t', '.', ',', ';', '!', '?', '-', '_', '<', '>', '&', '"', '\'', ':', '(', ')', '[', ']', '{', '}', '|', '\\', '/', '+', '*', '#', '@', '~', '`', '^', '$', '%' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    if (word.Equals(srcWord, StringComparison.OrdinalIgnoreCase)) // Case-sensitive
                    {
                        lineNumber++;
                        Console.WriteLine($"Word '{srcWord}' found on line {i + 1}"); // Prints linenumber (i+1, because lines are zero-indexed)
                        found = true;
                    }
                }
            }

            if (found)
            {
                Console.WriteLine($"Word '{srcWord}' was found {lineNumber} time(s) in '{filepath}'");
            }

            else
            {
                Console.WriteLine($"Word '{srcWord}' does not exist in '{filepath}'");
            }
        }

        else
        {
            Console.WriteLine("File does not exist!");
        }

    }
}
