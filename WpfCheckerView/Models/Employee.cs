namespace WpfCheckerView.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string IdProof { get; set; } = string.Empty;
        public string PanNo { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
    }
}
