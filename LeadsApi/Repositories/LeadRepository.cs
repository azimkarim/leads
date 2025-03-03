using LeadsApi.Models;

namespace LeadsApi.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private static readonly List<Lead> _leads = new List<Lead>
        {
            new Lead { Name = "Azim Karim", PhoneNumber = "916.693.4592", ZipCode = "95742", AllowEmail  = true, AllowText = true, Email = "azim@testing.com" },
            new Lead { Name = "Bill Smith", PhoneNumber = "123-100-1888", ZipCode = "96023",AllowEmail  = false, AllowText = true, Email = "bill@att.com" },
            new Lead { Name = "John Doe", PhoneNumber = "402-122-9900", ZipCode = "94303", AllowEmail  = false, AllowText = false },
            new Lead { Name = "Chris Doe", PhoneNumber = "944.819.3701", ZipCode = "19303", AllowEmail  = true, AllowText = false },
            new Lead { Name = "Smith Will", PhoneNumber = "233-244-9901", ZipCode = "96573", AllowEmail  = true, AllowText = false, Email = "smith@meninblack.com" },
        };

        public IEnumerable<Lead> GetLeads()
        {
            return _leads;
        }

        public bool TryGetLeadById(Guid id, out Lead? lead)
        {
            lead = _leads.Find(l => l.Id == id);
            return lead != null;
        }
    }
}
