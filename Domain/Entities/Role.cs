using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    [NotMapped]
    public RoleEnum RoleEnum
    {
        get => (RoleEnum)RoleId;
        set => RoleId = (int)value;
    }
    public List<User> Users { get; set; }
}