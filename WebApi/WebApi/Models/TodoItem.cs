using Microsoft.AspNetCore.Mvc;

namespace WebApi.Models
{
    [ModelBinder(typeof(CustomModelDetail))]
    public class TodoItem
    {
       

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

    }
}
