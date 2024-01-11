
namespace HuffmanTree
{

    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2 || (args.Length > 3 && args[1] == "-d") || (args.Length > 2 && args[1] == "-d"))
            {
                Console.WriteLine("Invalid CLI arguments");
                return;
            }


            try
            {
                if (args[0] == "d" || args[0] == "decode")
                    _ = new HuffmanDecoder(args[1], args[2]);
                else
                    _ = new HuffmanEncoder(File.ReadAllText(args[0]), args[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}
