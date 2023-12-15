namespace ExpenseTracker.Models
{
    public class Category
    {
        private static int id = 0;
        public Category()
        {
            Id = ++id;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}