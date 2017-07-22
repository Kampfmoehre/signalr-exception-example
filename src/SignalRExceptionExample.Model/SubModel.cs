using System;

namespace SignalRExceptionExample.Model
{
    public class SubModel : ISubModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SampleNumber1 { get; set; }

        public int SampleNumber2 { get; set; }

        public int ResultNumber { get; set; }
    }
}