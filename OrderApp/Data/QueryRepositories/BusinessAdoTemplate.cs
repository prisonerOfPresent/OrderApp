using Microsoft.Extensions.Configuration;
using OrderApp.Data.ConnectionTemplates;
using OrderApp.Data.Entities;

namespace OrderApp.Data.QueryRepositories
{
    public class BusinessAdoTemplate : AdoTemplate<Business>
    {
        public BusinessAdoTemplate(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
