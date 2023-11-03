namespace CustomRoles;

using System;
using System.Collections.Generic;

using CustomRoles.API;

using Exiled.API.Features;
using Exiled.CustomRoles.API;
using Exiled.CustomRoles.API.Features;

using PlayerRoles;

using Config = Configs.Config;
using CustomRole = Exiled.CustomRoles.API.Features.CustomRole;
using PlayerEvents = Exiled.Events.Handlers.Player;
using Scp049Events = Exiled.Events.Handlers.Scp049;
using ServerEvents = Exiled.Events.Handlers.Server;

public class Plugin : Plugin<Config>
{
    public static Plugin Singleton { get; private set; } = null!;

    public Dictionary<StartTeam, List<ICustomRole>> Roles { get; } = new();

    public List<Player> StopRagdollList { get; } = new ();

    public override string Author { get; } = "Joker119 | Modified by KadotCom and SiteFunnyArea";

    public override string Name { get; } = "CustomRoles";

    public override string Prefix { get; } = "CustomRolesSFA";

    public override Version RequiredExiledVersion { get; } = new (8, 0, 0);

    public Methods Methods { get; private set; } = null!;

    public EventHandlers EventHandlers { get; private set; } = null!;

    public override void OnEnabled()
    {
        Singleton = this;
        EventHandlers = new EventHandlers(this);
        Methods = new Methods(this);

        Config.LoadConfigs();

        CustomRole.RegisterRoles(false, Config.RoleConfigs);

        foreach (CustomRole role in CustomRole.Registered)
        {
            if (role.CustomAbilities is not null)
            {
                foreach (CustomAbility ability in role.CustomAbilities)
                {
                    ability.Register();
                }
            }

            if (role is ICustomRole custom)
            {
                Log.Debug($"Adding {role.Name} to dictionary..");
                StartTeam team;
                if (custom.StartTeam.HasFlag(StartTeam.Chaos))
                    team = StartTeam.Chaos;
                else if (custom.StartTeam.HasFlag(StartTeam.Guard))
                    team = StartTeam.Guard;
                else if (custom.StartTeam.HasFlag(StartTeam.Ntf))
                    team = StartTeam.Ntf;
                else if (custom.StartTeam.HasFlag(StartTeam.Scientist))
                    team = StartTeam.Scientist;
                else if (custom.StartTeam.HasFlag(StartTeam.ClassD))
                    team = StartTeam.ClassD;
                else if (custom.StartTeam.HasFlag(StartTeam.Scp))
                    team = StartTeam.Scp;
                else if (custom.StartTeam.HasFlag(StartTeam.Escape))
                    team = StartTeam.Escape;
                else if (custom.StartTeam.HasFlag(StartTeam.Private))
                    team = StartTeam.Private;
                else if (custom.StartTeam.HasFlag(StartTeam.Sergeant))
                    team = StartTeam.Sergeant;
                else if (custom.StartTeam.HasFlag(StartTeam.Specialist))
                    team = StartTeam.Specialist;
                else if (custom.StartTeam.HasFlag(StartTeam.Captain))
                    team = StartTeam.Captain;
                else if (custom.StartTeam.HasFlag(StartTeam.Conscript))
                    team = StartTeam.Conscript;
                else if (custom.StartTeam.HasFlag(StartTeam.Marauder))
                    team = StartTeam.Marauder;
                else if (custom.StartTeam.HasFlag(StartTeam.Repressor))
                    team = StartTeam.Repressor;
                else if (custom.StartTeam.HasFlag(StartTeam.Rifleman))
                    team = StartTeam.Rifleman;
                else
                    team = StartTeam.Other;

                if (!Roles.ContainsKey(team))
                    Roles.Add(team, new());

                for (int i = 0; i < role.SpawnProperties.Limit; i++)
                    Roles[team].Add(custom);
                Log.Debug($"Roles {team} now has {Roles[team].Count} elements.");
            }
        }

        ServerEvents.RoundStarted += EventHandlers.OnRoundStarted;
        ServerEvents.RespawningTeam += EventHandlers.OnRespawningTeam;
        ServerEvents.ReloadedConfigs += EventHandlers.OnReloadedConfigs;
        Scp049Events.FinishingRecall += EventHandlers.FinishingRecall;
        PlayerEvents.SpawningRagdoll += EventHandlers.OnSpawningRagdoll;
        PlayerEvents.Spawned += EventHandlers.Spawned;

        PlayerEvents.Escaping += EventHandlers.OnEscaping;
        base.OnEnabled();
    }
    
    public override void OnDisabled()
    {
        CustomRole.UnregisterRoles();

        ServerEvents.RoundStarted -= EventHandlers.OnRoundStarted;
        ServerEvents.RespawningTeam -= EventHandlers.OnRespawningTeam;
        ServerEvents.ReloadedConfigs -= EventHandlers.OnReloadedConfigs;
        base.OnDisabled();
    }
}