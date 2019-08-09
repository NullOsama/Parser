using System;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            //JObject jo = JObject.Parse(File.ReadAllText("S1.json"));

            //var Objects = jo.ToObject<Dictionary<string, object>>();


            //StringBuilder Pstr = new StringBuilder("");
            //foreach (var obj in Objects)
            //{
            //    Pstr.Append($"type: {obj.Key}\n----------\n");
            //    foreach (var attribute in ((JObject)obj.Value).ToObject<Dictionary<string, object>>())
            //    {
            //        Pstr.Append($"{attribute.Key}: {attribute.Value}\n");
            //    }
            //    Pstr.Append('\n');
            //}
            //Console.WriteLine(Pstr);

            var JF = new JsonFile(path: "S1.json");
            Console.WriteLine(JF.ParseFile());

            Console.ReadKey();
        }
    }
}
