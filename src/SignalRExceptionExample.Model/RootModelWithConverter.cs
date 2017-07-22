using System;
using Newtonsoft.Json;

namespace SignalRExceptionExample.Model
{
    public class RootModelWithConverter : IRootModel
    {
        public int Id { get; set; }
        
        [JsonConverter(typeof(ConcreteTypeConverter<SubModel>))]
        public ISubModel SubModel { get; set; }
    }
}