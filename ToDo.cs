namespace ToDoApp.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; } = false;

    }
}
