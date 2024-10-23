namespace radlab2_0.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public int Priority { get; set; }  // Added priority field
    }
}