namespace LeadsApi.Models
{
    public class Lead
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ZipCode { get; set; }
        public bool AllowEmail { get; set; }
        public bool AllowText { get; set; }
        public string? Email { get; set; }
    }
}
