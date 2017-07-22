using System;
using SignalRExceptionExample.Model;

namespace SignalRExceptionExample.Calculator
{
    public class Calculator
    {
        public Calculator()
        {            
        }

        public IRootModel Calculate(IRootModel model)
        {
            model.SubModel.ResultNumber = model.SubModel.SampleNumber1 + model.SubModel.SampleNumber2;

            return model;
        }
    }
}
