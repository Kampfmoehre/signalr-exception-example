using System;

namespace SignalRExceptionExample.Model
{
    public interface IRootModel
    {
        int Id { get; set; }

        ISubModel SubModel { get; set; }
    }
}
