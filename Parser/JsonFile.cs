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

        public JsonFile(string path)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public string ParseFile()
        {
            // Reads The File Text And Then Prse It To Json Object.
            var jsonObject = JObject.Parse(File.ReadAllText(Path));

            // Convert The Json Object To Dictionary Struct.
            var ObjectsDic = jsonObject.ToObject<Dictionary<string, object>>();


            // Pstr: Parsed String.
            StringBuilder Pstr = new StringBuilder("");

            // The First Loop Iterates Over The First Level And The Second One Iterates Over The Attributes Of Each One.
            foreach (var obj in ObjectsDic)
            {
                Pstr.Append($"type: {obj.Key}\n----------\n");
                foreach (var attribute in ((JObject)obj.Value).ToObject<Dictionary<string, object>>())
                {
                    Pstr.Append($"{attribute.Key}: {attribute.Value}\n");
                }
                Pstr.Append('\n');
            }

            return Pstr.ToString();
        }
    }
}
