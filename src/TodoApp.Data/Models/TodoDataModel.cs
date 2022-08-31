namespace TodoApp.Data.Models
{
    public class TodoDataModel
    {
        public int Id { get; set; }
        public string Todo { get; set; }
        public DateTime Created { get; set; }
        public bool IsComplete { get; set; }
    }
}