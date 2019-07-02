using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Aubit.Judge
{
    public class SwaggerEditor
    {
        public SwaggerEditor(string swagger)
        {
            Swagger = swagger;
        }

        public string Swagger { get; set; }

        public void SetPathExamples()
        {
            var json = JObject.Parse(Swagger);
            InsertXExample(json, "$..delete.parameters[?(@.in == 'path')]", 3);
            InsertXExample(json, "$..parameters[?(@.in == 'path')]", 1);        

            Swagger = json.ToString();
        }

        private void InsertXExample(JObject json, string jsonPath, int exampleId)
        {
            var pathParameters = json.SelectTokens(jsonPath);

            foreach (var param in pathParameters)
            {
                var o = (JObject)param;

                if (o["x-example"] == null)
                    o.Add("x-example", exampleId);
            }
        }

        public void GenerateFile(string path)
        {
            File.WriteAllText(path, Swagger);
        }
    }
}
