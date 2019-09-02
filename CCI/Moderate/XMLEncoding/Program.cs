using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static string EncodeToString(Element root)
        {
            StringBuilder sb = new StringBuilder();
            Encode(root, sb);
            return sb.ToString();
        }

        public static void Encode(Element root, StringBuilder sb)
        {
            // Get mapping of <family>
            Encode(root.GetNameCode(), sb);
            foreach (Attr a in root.Attributes)
            {
                Encode(a, sb);
            }
            Encode("0", sb);

            if (root.Value != null && root.Value != "")
            {
                Encode(root.Value, sb);
            }
            else
            {
                foreach (Element e in root.Children)
                {
                    Encode(e, sb);
                }
            }
            Encode("0", sb);
        }

        private static void Encode(Attr attr, StringBuilder sb)
        {
            Encode(attr.GetTagCode(), sb);
            Encode(attr.Value, sb);
        }

        private static void Encode(string value, StringBuilder sb)
        {
            sb.Append(value);
            sb.Append(" ");
        }

        public class Element
        {
            public IEnumerable<Attr> Attributes { get; set; }
            public string Value { get; set; }
            public IEnumerable<Element> Children { get; set; }

            public string GetNameCode()
            {
                throw new NotImplementedException();
            }
        }

        public class Attr
        {
            public Element Value { get; set; }
            public Element GetTagCode()
            {
                throw new NotImplementedException();
            }
        }
    }
}
