using AlexaIOTInfraredRemoteAPI.Domain;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Specifications
{
    public class InfraredSignalsWithBasicInformation : BaseSpecification<InfraredSignal>
    {
        public InfraredSignalsWithBasicInformation(string sort)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "dateAsc":
                        AddOrderBy(s => s.CreatedAt);
                        break;
                    case "dateDesc":
                        AddOrderByDescending(s => s.CreatedAt);
                        break;
                    default:
                        AddOrderBy(s => s.Description);
                        break;
                }
            }
        }
    }
}
