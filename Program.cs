using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;


namespace HuffmanTree
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter your desired string!");
            string input = Console.ReadLine();

            try
            {
                string programPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                string filePath = Path.Combine(programPath, "data.txt");
                string encodedDataPath = Path.Combine(programPath, "encoded.txt");
                string decodedDataPath = Path.Combine(programPath, "dncoded.txt");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(input);
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        HuffTree huffTree = new HuffTree(line);

                        string encoded = huffTree.Encode(line);
                        Console.WriteLine("Encoded: " + encoded);
                        using (StreamWriter sw1 = new StreamWriter(encodedDataPath))
                        {
                            sw1.WriteLine(encoded);
                            //long fileSizeInKB = fs.FileSizeConverter.ConvertFileSizeToKB(fileSizeInBytes);
                        }

                        string decoded = huffTree.Decode(encoded);
                        Console.WriteLine("Decoded: " + decoded);
                        using (StreamWriter sw2 = new StreamWriter(decodedDataPath))
                        {
                            sw2.WriteLine(decoded);
                        }

                        line = reader.ReadLine();
                    }
                }


                FileStream fs0 = File.OpenRead(filePath);
                Console.WriteLine("original data file's size: " + fs0.Length);

                FileStream fs1 = File.OpenRead(encodedDataPath);
                Console.WriteLine("encoded data file's size: " + fs1.Length);

                FileStream fs2 = File.OpenRead(decodedDataPath);
                Console.WriteLine("decoded data file's size: " + fs2.Length);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("null reference, file doesn't exist dude!");
            }
            
        }
    }
    
}
