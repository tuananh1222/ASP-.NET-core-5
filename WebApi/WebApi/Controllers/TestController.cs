using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController: ControllerBase
    {
        [Route("[action]")]
        public string Get()
        {
            return "My name is Tuan ANh";
        }

        //[Route("{Department:int}")]
        //public string Search(string Department)
        //{
        //    return $"Return Employees with Department : {Department}";
        //}
        //[Route("{EmployeeId:int}")]
        //public string GetEmployeeDetails(int EmployeeId)
        //{
        //    return $"Response from GetEmployeeDetails Method, EmployeeId : {EmployeeId}";
        //}

        // return types: specific type
        [Route("deatail")]
        public TodoItem GetTodo()
        {
            return new TodoItem
            {
                Id = 1,
                Name = "Le Tuan Anh",
                IsComplete = true,
            };
        }
        [Route("all")]
        public List<TodoItem> GetAllTodo()
        {
            return new List<TodoItem>
            {
                 new TodoItem{  Id = 1,   Name = "Le Tuan Anh",   IsComplete = true },
                 new TodoItem{  Id = 2,   Name = "Le Tuan Anh",   IsComplete = true },
                 new TodoItem{  Id = 3,   Name = "Le Tuan Anh",   IsComplete = true },
                 new TodoItem{  Id = 4,   Name = "Le Tuan Anh",   IsComplete = true, }
            };
        }
        [Route("alldeatail")]
        public IEnumerable<TodoItem> GetAllDeatailTodo()
        {
            return new List<TodoItem>
            {
                 new TodoItem{  Id = 1,   Name = "Le Tuan Anh",   IsComplete = true },
                 new TodoItem{  Id = 2,   Name = "Le Tuan Anh",   IsComplete = true },
                 new TodoItem{  Id = 3,   Name = "Le Tuan Anh",   IsComplete = true },
                 new TodoItem{  Id = 4,   Name = "Le Tuan Anh",   IsComplete = true, }
            };
        }
        [Route("all/async")]
        public async IAsyncEnumerable<TodoItem> GetAllDeatailTodoAsync()
        {
            var todoItem = new List<TodoItem>
            {
                new TodoItem{  Id = 1,   Name = "Le Tuan Anh",   IsComplete = true },
                 new TodoItem{  Id = 2,   Name = "Le Tuan Anh",   IsComplete = true },
                 new TodoItem{  Id = 3,   Name = "Le Tuan Anh",   IsComplete = true },
                 new TodoItem{  Id = 4,   Name = "Le Tuan Anh",   IsComplete = true, }
            };
             foreach(var item in todoItem)
            {
                yield return item;
            }
        }

        // IActionResult type
        [Route("all/iaction")]
        public IActionResult GetTodos()
        {
            var todoItem = new List<TodoItem>
            {
                new TodoItem{  Id = 1,   Name = "Le Tuan Anh",   IsComplete = true },
                 new TodoItem{  Id = 2,   Name = "Le Tuan Anh",   IsComplete = true },
                 new TodoItem{  Id = 3,   Name = "Le Tuan Anh",   IsComplete = true },
                 new TodoItem{  Id = 4,   Name = "Le Tuan Anh",   IsComplete = true, }
            };
            if (todoItem.Count > 0)
            {
                return Ok(todoItem);
            }
            else
            {
                return NotFound();
            }
        }

        //ActionResult
        [Route("all/actionresult")]
        public ActionResult<TodoItem> Actions(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            else
            {
                return new TodoItem { Id = 4, Name = "Le Tuan Anh", IsComplete = true};
            }
        }
        [HttpGet("search")]
        public IActionResult SearchCountries([ModelBinder(typeof(CustomModelBinder))] string[] todoitem)
        {
            return Ok(todoitem);
        }
        [HttpGet("{Id}")]
        public IActionResult DetailCountries([ModelBinder(Name = "Id")] TodoItem todo)
        {
            return Ok(todo);
        }
    }
}
