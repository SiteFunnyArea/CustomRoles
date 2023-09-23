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

[CustomRole(RoleTypeId.None)]
public class Major : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 100;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.None;
    public StartTeam StartTeam { get; set; } = StartTeam.Scientist;

    public override uint Id { get; set; } = 472;

    public override RoleTypeId Role { get; set; } = RoleTypeId.None;

    public override int MaxHealth { get; set; } = 120;

    public override string Name { get; set; } = "Major";
    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "You have been spawned in as <color=#fdca02><b>Science Personnel:</b></color> <color=#2bad33><b>Major Researcher</b></color><br><i>There has been a containment breach at the site.</i><br><i>Work with other</i> <color=#727472>Facility Guards</color> <i>on the team.</i>\r\nYou have been spawned in as <color=#fdca02><b>Science Personnel:</b></color> <color=#2bad33><b>Major Researcher</b></color><br><i>There has been a containment breach at the site.</i><br><i>Work with other</i> <color=#727472>Facility Guards</color> <i>on the team.</i>\r\n",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };
    public override string Description { get; set; } =
        "<color=#2bad33><b>Major Researcher</b></color>";
    
    public override string CustomInfo { get; set; } = "Major";

    public override bool KeepInventoryOnSpawn { get; set; } = true;

    public override bool KeepRoleOnDeath { get; set; } = true;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
    };

    public override List<CustomAbility>? CustomAbilities { get; set; } = new() {};

    public override List<string> Inventory { get; set; } = new()
    {
        $"{ItemType.KeycardResearchCoordinator}",
        $"{ItemType.Medkit}",
        $"{ItemType.Medkit}",
        $"{ItemType.Radio}",
        $"{ItemType.ArmorLight}",
        $"{ItemType.Coin}",

    };

    protected override void RoleAdded(Player player)
    {

    }

    protected override void RoleRemoved(Player player)
    {
        player.DisableAllEffects();
    }

}