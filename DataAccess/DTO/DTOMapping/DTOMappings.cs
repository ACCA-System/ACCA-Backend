using Challenge.DataAccess.Entities;

namespace Challenge.DataAccess.DTO.DTOMapping

{
    public static class DTOMappings
    {
        #region UsersMapping
        public static Users Map(this UserDTO users) =>
    new Users
    {
        UserId = users.UserId,
        Name = users.Name,
        Email = users.Email,
        Password = users.Password,
        TypeId = users.TypeId,
    };
        public static Accounts Map(this AccountsDTO accounts) =>
    new Accounts
    {
        AccountId = accounts.AccountId,
        Name = accounts.Name,
        ClientName = accounts.ClientName,
        OperationsManager = accounts.OperationsManager,
        CreatedDate= accounts.CreatedDate,
    };
        public static Teams Map(this TeamsDTO teams) =>
new Teams
{
TeamId = teams.TeamId,
Name = teams.Name,
AccountId = teams.AccountId,
};
    }

    #endregion
}

