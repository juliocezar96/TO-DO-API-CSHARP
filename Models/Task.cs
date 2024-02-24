using crud.Enums;

namespace crud.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusTask Status { get; set; }
    }
}
