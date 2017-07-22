using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalRExceptionExample.Model;

namespace SignalRExceptionExample.Server
{
    public class CalculatorHub : Hub
    {
        private readonly Calculator.Calculator _calculator;
        private readonly ILogger _logger;

        public CalculatorHub(ILogger<CalculatorHub> logger, Calculator.Calculator calculator)
        {
            _logger = logger;
            _calculator = calculator;
        }

        public async Task<IRootModel> Calculate(RootModel model)
        {
            _logger.LogWarning("Starting calculation of {id}", model.Id);

            IRootModel result = await _calculator.Calculate(model);

            _logger.LogWarning("Finished calculation of {id}", model.Id);

            return result;
        }

        public async Task<IRootModel> CalculateWithConverter(RootModelWithConverter model)
        {
            _logger.LogWarning("Starting calculation of {id}", model.Id);

            IRootModel result = await _calculator.Calculate(model);

            _logger.LogWarning("Finished calculation of {id}", model.Id);

            return result;
        }
    }
}