using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi
{
    public class CustomModelDetail : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var value = bindingContext.ValueProvider.GetValue(modelName);
            var result = value.FirstValue;
            if(!long.TryParse(result, out var id)){
                return Task.CompletedTask;
            }
            var model = new TodoItem
            {
                Id = id,
                Name = "Le Tuan Anh",
                IsComplete = true
            };
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
