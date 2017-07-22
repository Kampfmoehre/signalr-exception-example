namespace SignalRExceptionExample.Model
{
    public class RootModel : IRootModel
    {
        public int Id { get; set; }

        public ISubModel SubModel { get; set; }
    }
}