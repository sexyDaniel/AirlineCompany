using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Captains.Queries.GetCaptains
{
    public class GetCaptainsQuery:IRequest<CaptainsVm>
    {
        public bool SortByFirstName { get; set; }
        public bool SortByLastName { get; set; }
        public bool SortByPatronymic { get; set; }
        public bool SortByStatus { get; set; }
        public string SearchByFirstName { get; set; }
        public string SearchByLastName { get; set; }
        public string SearchByPatronymic { get; set; }
    }
}
