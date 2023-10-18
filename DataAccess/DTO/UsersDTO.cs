namespace ACCA_Backend.DataAccess.DTO
{
    public class UsersDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
    }
}
