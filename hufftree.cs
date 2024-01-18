using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanTree
{
    public class HuffTree
    {
        public Node Root { get; set; }
        public Dictionary<char, string> Dictionary { get; set; }

        public HuffTree(string input)
        {
            Dictionary = new Dictionary<char, string>();

            var frequencies = input.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var nodes = frequencies.Select(x => new Node { Symbol = x.Key, Frequency = x.Value }).ToList();

            while (nodes.Count > 1)
            {
                var orderedNodes = nodes.OrderBy(node => node.Frequency).ToList();

                if (orderedNodes.Count >= 2)
                {
                    var parent = new Node()
                    {
                        Symbol = '0',
                        Frequency = orderedNodes[0].Frequency + orderedNodes[1].Frequency,
                        Left = orderedNodes[0],
                        Right = orderedNodes[1]
                    };

                    nodes.Remove(orderedNodes[0]);
                    nodes.Remove(orderedNodes[1]);
                    nodes.Add(parent);
                }

                this.Root = nodes.FirstOrDefault();
            }

            Root = nodes.FirstOrDefault();

            CreateDictionary(Root, string.Empty);
        }

        //public void CreateDictionary(Node node, string prefix)
        //{
        //    if (node == null)
        //        return;

        //    if (!node.Symbol.Equals('0'))
        //        Dictionary.Add(node.Symbol, prefix);

        //    CreateDictionary(node.Left, prefix + "0");
        //    CreateDictionary(node.Right, prefix + "1");
        //}

        public void CreateDictionary(Node node, string prefix)
        {
            if (node == null)
                return;
            if (!Dictionary.ContainsKey(node.Symbol))
            {
                Dictionary.Add(node.Symbol, prefix);
            }
            CreateDictionary(node.Left, prefix + "0");
            CreateDictionary(node.Right, prefix + "1");
        }

        public string Encode(string input)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                string encodedSymbol = Dictionary[input[i]];
                output.Append(encodedSymbol);
            }

            return output.ToString();
        }

        public string Decode(string input)
        {
            Node current = Root;
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                current = input[i] == '0' ? current.Left : current.Right;

                if (current.Left == null && current.Right == null)
                {
                    output.Append(current.Symbol);
                    current = Root;
                }
            }

            return output.ToString();
        }
    }
}
