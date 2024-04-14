using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Role()
        {
        }
    }
}
