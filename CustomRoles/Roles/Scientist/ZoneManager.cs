namespace CustomRoles.Roles;

using CustomRoles.Abilities;
using CustomRoles.API;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Doors;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp330;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
using UnityEngine;
using YamlDotNet.Serialization;

[CustomRole(RoleTypeId.Scientist)]
public class WeaponsResearcher : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 80;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.Scientist;
    public StartTeam StartTeam { get; set; } = StartTeam.Scientist;

    public override uint Id { get; set; } = 2503;

    public override RoleTypeId Role { get; set; } = RoleTypeId.Scientist;

    public override int MaxHealth { get; set; } = 110;

    public override string Name { get; set; } = "<color=#FAFF86><b>Scientist Zone Manager</b></color>";
    public override string Description { get; set; } =
        "You spawn with a <color=#FFEA00>Lockdown Device</color> that locks down any door for <color=#FFEA00>15 seconds.</color> There is a <color=#FFEA00>25 second cooldown</color> on it however.";
    
    public override string CustomInfo { get; set; } = "Zone Manager";

    public override bool KeepInventoryOnSpawn { get; set; } = false;
    [YamlIgnore]
    public bool Cooldown;

    public override bool KeepRoleOnDeath { get; set; } = false;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,

    };
    // Mass Lockdown
    protected override void SubscribeEvents()
    {
        Exiled.Events.Handlers.Player.TogglingNoClip += NoClip;
        base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
        Exiled.Events.Handlers.Player.TogglingNoClip -= NoClip;
        base.UnsubscribeEvents();
    }

    public override bool DisplayCustomItemMessages { get; set; } = false;

    public void NoClip(TogglingNoClipEventArgs ev)
    {
        if (!Check(ev.Player))
            return;
        if (Cooldown == true)
        {
            ev.Player.ShowHint("<align=center>Ability: Mass Lockdown on Cooldown</align>", 5f);
            return;
        }
            

        ev.IsAllowed = false;
        Cooldown = true;
        ev.Player.ShowHint("<align=center>Ability: Mass Lockdown Activated</align>", 5f);
        foreach (Door d in ev.Player.CurrentRoom.Doors)
        {
            if (d.Type == DoorType.Scp079First || d.Type == DoorType.Scp079Second || d.Type == DoorType.Scp079Armory || d.IsElevator)
                return;
            if (d.IsOpen)
            {
                d.IsOpen = false;
            }
            else
            {
                d.IsOpen = true;
            }
            d.Lock(10, DoorLockType.Lockdown079);
        }

        Timing.CallDelayed(20f, () =>
        {
            Cooldown = false;
            ev.Player.ShowHint("<align=center>Ability: Mass Lockdown Ready</align>", 5f);

        });
    }

    public override List<CustomAbility>? CustomAbilities { get; set; } = new() {};

    public override List<string> Inventory { get; set; } = new()
    {
        $"Lockdown Device",
        $"{ItemType.Medkit}",
        $"{ItemType.KeycardZoneManager}",
        $"{ItemType.Radio}",
        $"{ItemType.ArmorLight}",
    };

    protected override void RoleAdded(Player player)
    {
        Timing.KillCoroutines();
        //player.Teleport(Room.Get((RoomType)SpawnLocationType.InsideNukeArmory));
    }

    protected override void RoleRemoved(Player player)
    {
        player.DisableAllEffects();
    }

}