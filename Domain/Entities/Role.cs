namespace Domain.Entities;

public class Role
{
    public Role(Guid roleId, string roleName, List<User> users)
    {
        RoleId = roleId;
        RoleName = roleName;
        Users = users;
    }

    public Guid RoleId { get; set; }
    public string RoleName { get; set; }

    public List<User> Users { get; set; }
}