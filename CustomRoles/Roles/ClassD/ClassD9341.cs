namespace CustomRoles.Roles;

using CustomRoles.Abilities;
using CustomRoles.API;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Scp330;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
using UnityEngine;

[CustomRole(RoleTypeId.ChaosConscript)]
public class ClassD9341 : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 20;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.ChaosConscript;
    public StartTeam StartTeam { get; set; } = StartTeam.ClassD;

    public override uint Id { get; set; } = 11;

    public override RoleTypeId Role { get; set; } = RoleTypeId.ChaosConscript;

    public override int MaxHealth { get; set; } = 100;

    public override string Name { get; set; } = "Class D-9341";
    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "You have been spawned in as <color=#EE7600><b>Class D Personnel:</b></color> <color=#EFC01A><b>D-9341</b></color><br><i>Back at Site -- once again, D-9341...</i><br><i>Rescue any Class D Personnel and get your revenge.</i>\r\n",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };
    public override string Description { get; set; } =
        "<color=#EFC01A><b>D-9341</b></color>";

    public override string CustomInfo { get; set; } = "Brute";

    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override bool KeepRoleOnDeath { get; set; } = true;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
        StaticSpawnPoints = new List<StaticSpawnPoint>()
        {
            new()
            {
                Chance = 100,
                Name = "Surface", 
                Position = new Vector3(63f,991.6f,-50.8f),
            },
        },
    };

    public override List<CustomAbility>? CustomAbilities { get; set; } = new() {};

    public override List<string> Inventory { get; set; } = new()
    {
        $"{ItemType.GunAK}",
        $"{ItemType.KeycardChaosInsurgency}",
        $"{ItemType.ArmorCombat}",
        $"{ItemType.Radio}",
        $"{ItemType.GrenadeFlash}",
        $"{ItemType.SCP500}",
        $"{ItemType.Medkit}",

    };

    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {
            AmmoType.Nato762,
            60
        },
    };
    protected override void RoleAdded(Player player)
    {
        Effect e = new Effect();
        e.Type = Exiled.API.Enums.EffectType.DamageReduction;
        e.Intensity = 2;
        player.EnableEffect(e);
    }

    protected override void RoleRemoved(Player player)
    {
        player.DisableAllEffects();
    }

}