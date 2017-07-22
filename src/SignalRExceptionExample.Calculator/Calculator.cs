using System;
using System.Threading.Tasks;
using SignalRExceptionExample.Model;

namespace SignalRExceptionExample.Calculator
{
    public class Calculator
    {
        public Calculator()
        {            
        }

        public async Task<IRootModel> Calculate(IRootModel model)
        {
            model.SubModel.ResultNumber = model.SubModel.SampleNumber1 + model.SubModel.SampleNumber2;

            // Simulate async operation
            await Task.Delay(500);

            return model;
        }
    }
}
