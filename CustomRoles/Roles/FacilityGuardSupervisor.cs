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

[CustomRole(RoleTypeId.FacilityGuard)]
public class FacilityGuardSupervisor : CustomRole, ICustomRole
{
        public override uint Id { get; set; } = 11;
        public override int MaxHealth { get; set; } = 100;
        public override string Name { get; set; } = "Facility Guard Supervisor";
        public override string Description { get; set; } = "Test";
        public override string CustomInfo { get; set; } = "Facility Guard Supervisor";
        public StartTeam StartTeam { get; set; } = StartTeam.Guard;
        public int Chance { get; set; } = 100;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
        RoleSpawnPoints = new List<RoleSpawnPoint>
        {
            new()
            {
                Role = RoleTypeId.FacilityGuard,
                Chance = 100,
            },
        },
    };
 
    public override RoleTypeId Role { get; set; } = RoleTypeId.FacilityGuard;
        public override List<string> Inventory { get; set; } = new() {
            $"{ItemType.GunCrossvec}",
            $"{ItemType.KeycardNTFOfficer}",
            $"{ItemType.Adrenaline}",
            $"{ItemType.Medkit}",
            $"{ItemType.Flashlight}",
            $"{ItemType.GrenadeFlash}",
            $"{ItemType.ArmorCombat}",
        };
        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new() {
                {
                AmmoType.Nato9, 75
                },
        };
}
