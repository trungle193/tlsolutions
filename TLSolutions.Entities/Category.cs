using System;
namespace TLSolutions.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
