using System;

namespace Aubit.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl;
            string swaggerPath;
            string savePath;

            if (args.Length == 0)
            {
                Console.WriteLine("Please enter the base url:");
                baseUrl = Console.ReadLine();

                Console.WriteLine("Please enter the swagger path:");
                swaggerPath = Console.ReadLine();

                Console.WriteLine("Please enter the save path for the generated file:");
                savePath = Console.ReadLine();
            }
            else
            {
                baseUrl = args[0];
                swaggerPath = args[1];
                savePath = args[2];
            }

            var client = new SwaggerClient(baseUrl);
            var swagger = client.GetSwaggerDefinition(swaggerPath);

            var editor = new SwaggerEditor(swagger);
            editor.SetPathExamples();
            editor.GenerateFile(savePath);

            Console.WriteLine($"Swagger generated at: {savePath}");
        }
    }
}
