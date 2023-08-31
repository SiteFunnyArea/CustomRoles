namespace CustomItems_SFA.Roles;

using CustomRoles.API;
using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[CustomRole(RoleTypeId.None)]
public class TemplateRole : CustomRole, ICustomRole
{
        public override uint Id { get; set; } = 9999;
        public override int MaxHealth { get; set; } = 0;
        public override string Name { get; set; } = string.Empty;
        public override string Description { get; set; } = string.Empty;
        public override string CustomInfo { get; set; } = string.Empty;
        public StartTeam StartTeam { get; set; } = StartTeam.Other;
        public int Chance { get; set; } = 0;
       public override SpawnProperties SpawnProperties { get; set; } = new()
       {
            Limit = 1,
            RoleSpawnPoints = new List<RoleSpawnPoint>
             {
                new()
                {
                    Role = RoleTypeId.None,
                   Chance = 100,
                },
             },
        };

    public override RoleTypeId Role { get; set; } = RoleTypeId.None;
        public override List<string> Inventory { get; set; } = new() {};
        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new() {};

}
