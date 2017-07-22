using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SignalRExceptionExample.Model;

namespace SignalRExceptionExample.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var tester = new ClientTester();
                IRootModel result = null;
                switch (args[0])
                {
                    case "-n":
                    case "--normal":
                        result = tester.Run(false).Result;
                        break;

                    case "-w":
                    case "--with-converter":
                        result = tester.Run(true).Result;
                        break;
                    default:
                        throw new ArgumentException("Please use either -n or -c parameter");
                }

                Console.WriteLine($"Test finished, result: {result.SubModel.ResultNumber}, press any key to close");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    class ClientTester
    {

        public async Task<IRootModel> Run(bool withConverter)
        {
            if (withConverter)
            {
                using (var client = new CalculateClient<RootModelWithConverter>(new Uri("http://localhost:5000"), new LoggerFactory()))
                {
                    await client.ConnectAsync();

                    var model = new RootModelWithConverter { Id = 1, SubModel = new SubModel { Id = 2, Name = "Test", SampleNumber1 = 14, SampleNumber2 = 234 } };

                    IRootModel result = await client.CalculateWithConverter(model);

                    return result;
                }
            }
            else
            {
                using (var client = new CalculateClient<RootModel>(new Uri("http://localhost:5000"), new LoggerFactory()))
                {
                    await client.ConnectAsync();

                    var model = new RootModel { Id = 3, SubModel = new SubModel { Id = 4, Name = "Test", SampleNumber1 = 564, SampleNumber2 = 464 } };

                    IRootModel result = await client.Calculate(model);

                    return result;
                }
            }
        }
    }
}
