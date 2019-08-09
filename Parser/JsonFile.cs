using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Parser
{
    class JsonFile : IFile
    {
        public string Path { get; set; }
        public string ParsedText { get; private set; }

        public JsonFile(string path)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            ParsedText = null;
        }

        public string ParseFile()
        {
            var jsonObject = JObject.Parse(File.ReadAllText(Path));

            var Objects = jsonObject.ToObject<Dictionary<string, object>>();


            StringBuilder Pstr = new StringBuilder("");
            foreach (var obj in Objects)
            {
                Pstr.Append($"type: {obj.Key}\n----------\n");
                foreach (var attribute in ((JObject)obj.Value).ToObject<Dictionary<string, object>>())
                {
                    Pstr.Append($"{attribute.Key}: {attribute.Value}\n");
                }
                Pstr.Append('\n');
            }

            ParsedText = Pstr.ToString();
            return ParsedText;
        }
    }
}
