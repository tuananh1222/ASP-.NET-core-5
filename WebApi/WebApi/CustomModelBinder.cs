using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace WebApi
{
    public class CustomModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Query;
            var result = data.TryGetValue("todoitem", out var todoitem);
            if (result)
            {
                var array = todoitem.ToString().Split('|');
                
                bindingContext.Result = ModelBindingResult.Success(array);

            }


            return Task.CompletedTask;
        }
    }
}
