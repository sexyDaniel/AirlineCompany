
namespace AirlineCompany.Application.Captains.Queries.GetCaptains
{
    public class CaptainDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int FlightCount { get; set; }
    }
}
