using LeadsApi.Models;
namespace LeadsApi.Repositories
{
    public interface ILeadRepository
    {
        IEnumerable<Lead> GetLeads();
        bool TryGetLeadById(Guid id, out Lead? lead);
    }
}
