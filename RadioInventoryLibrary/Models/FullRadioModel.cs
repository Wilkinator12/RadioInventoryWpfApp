namespace RadioInventoryLibrary.Models
{
    public class FullRadioModel
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int DesignatedLabelNumber { get; set; }
        public string FrontLabel { get; set; } = string.Empty;
        public string InsideLabel { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
    }
}
