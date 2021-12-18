using MediatR;


namespace AirlineCompany.Application.Planes.Commands.Create
{
    public class CreatePlaneCommand:IRequest<bool>
    {
        public int ModelId { get; set; }
        public int Capacity { get; set; }
        public int Rows { get; set; }
        public int SitsInRow { get; set; }
    }
}
