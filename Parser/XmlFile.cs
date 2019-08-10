using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Parser
{
    class XmlFile : IFile
    {
        public string Path { get; set; }

        public XmlFile(string path)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }


        public string ParseFile()
        {
            // Reads The File Text And Parse It To Xml Document Object.
            var doc = XDocument.Parse(File.ReadAllText(Path));

            //  Create The Dictitonary In Witch The Extracted Data Will Be Saved.
            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();

            // Recursively Loops Over Each Elemnt(Node) In The Xml Oject.
            int keyInt;
            foreach (XElement element in doc.Descendants().Where(p => p.HasElements == false))
            {
                keyInt = 0;
                StringBuilder keyName = new StringBuilder(element.Name.LocalName);

                var parent = element.Parent;
                while (parent != null)
                {
                    parent = parent.Parent;
                }

                while (dataDictionary.ContainsKey(keyName.ToString()))
                {
                    keyName.Append(keyName + "_" + keyInt++);
                }

                dataDictionary.Add(keyName.ToString(), element.Value);
            }

            // Pstr: Parsed String.
            var Pstr = new StringBuilder("type: note\n---------\n");

            foreach (var x in dataDictionary)
            {
                Pstr.Append($"{x.Key}: {x.Value}\n");
            }
            Pstr.Append('\n');

            return Pstr.ToString();
        }
    }
}
