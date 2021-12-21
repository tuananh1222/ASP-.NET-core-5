namespace WebApi.Models
{
    public class TodoItem
    {
        public TodoItem()
        {
            Id = 1;
            Name = "Le Tuan Anh";
            IsComplete = true;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

    }
}
