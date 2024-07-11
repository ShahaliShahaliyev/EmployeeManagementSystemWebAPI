namespace EmployeeManagementAPI.Application.Features.Queries.Users.GetUsers
{
    public class GetAllUsersQueryResponse
    {
        public object Users { get; set; }
        public int TotalUsersCount { get; set; }
    }
}