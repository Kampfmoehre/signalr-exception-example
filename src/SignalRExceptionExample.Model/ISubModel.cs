namespace SignalRExceptionExample.Model
{
    public interface ISubModel
    {
         int Id { get; set; }

         string Name { get; set; }

         int SampleNumber1 { get; set; }

         int SampleNumber2 { get; set; }

         int ResultNumber { get; set; }
    }
}