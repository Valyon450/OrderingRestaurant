using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.DTO
{
    public abstract class BaseDTO
    {
        [NotMapped]
        public Guid Id { get; set; }
    }      
    
}
