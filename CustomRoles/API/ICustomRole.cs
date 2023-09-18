using PlayerRoles;
using YamlDotNet.Serialization;

namespace CustomRoles.API;

public interface ICustomRole
{
    public StartTeam StartTeam { get; set; }
    public int Chance { get; set; }
    [YamlIgnore] public RoleTypeId RoleToBe { get; set; }
}