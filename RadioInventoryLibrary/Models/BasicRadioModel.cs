using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadioInventoryLibrary.Models
{
    [Table("Radios")]
    public class BasicRadioModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int DesignatedDepartmentId { get; set; }
        public int DesignatedLabelNumber { get; set; }
        public string FrontLabel { get; set; } = string.Empty;
        public string InsideLabel { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
    }
}
