namespace CustomRoles.Roles;

using System.Collections.Generic;
using CustomRoles.Abilities;
using CustomRoles.API;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

using Player = Exiled.Events.Handlers.Player;

[CustomRole(RoleTypeId.FacilityGuard)]
public class FacilityGuardGunslinger : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 80;
    protected override void SubscribeEvents()
    {
        Player.Hurting += Hurt;
        base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
        Player.Hurting -= Hurt;
        base.UnsubscribeEvents();
    }
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.FacilityGuard;

    public StartTeam StartTeam { get; set; } = StartTeam.Guard;

    public override uint Id { get; set; } = 2511;

    public override RoleTypeId Role { get; set; } = RoleTypeId.FacilityGuard;

    public override int MaxHealth { get; set; } = 110;

    public override string Name { get; set; } = "<color=#727472><b>Facility Guard Gunslinger</b></color>";

    public override string Description { get; set; } =
        "You spawn with <color=#FFEA00>two extra weapons</color> and <color=#FFEA00>better armour</color>. You can tank a bit of shots and deal extra damage to <color=#EE7600>Rogue Class D Personnel</color> and <color=#228B22>Chaos Insurgency</color>.\r\n";
    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override string CustomInfo { get; set; } = "Gunslinger";
    public override bool DisplayCustomItemMessages { get; set; } = false;

    public override List<string> Inventory { get; set; } = new()
    {
        $"{ItemType.GunRevolver}",
        $"{ItemType.GunCrossvec}",
        $"{ItemType.GunA7}",
        $"{ItemType.Medkit}",
        $"{ItemType.Radio}",
        $"{ItemType.ArmorHeavy}",
        $"{ItemType.KeycardGuard}",
    };

    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {
            AmmoType.Nato762,
            60
        },
        {
            AmmoType.Nato9,
            60
        },
        {
            AmmoType.Ammo44Cal,
            16
        },
    };

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

    public override List<CustomAbility>? CustomAbilities { get; set; } = new()
    {
        //new HealingMist(),
    };

    public void Hurt(HurtingEventArgs e)
    {
        if(e.Attacker.Role.Team == Team.ChaosInsurgency || e.Attacker.Role.Team == Team.ClassD)
        {
            e.Amount = e.Amount * 1.15f;
        }
    }
}