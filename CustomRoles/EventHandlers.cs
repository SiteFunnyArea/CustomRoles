namespace CustomRoles;

using System.Collections.Generic;

using CustomRoles.API;

using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Roles;
using Exiled.CustomRoles.API;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp049;
using Exiled.Events.EventArgs.Server;

using PlayerRoles;
using Respawning;

public class EventHandlers
{
    private readonly Plugin plugin;

    public EventHandlers(Plugin plugin)
    {
        this.plugin = plugin;
    }

    public void OnRoundStarted()
    {
        List<ICustomRole>.Enumerator dClassRoles = new();
        List<ICustomRole>.Enumerator scientistRoles = new();
        List<ICustomRole>.Enumerator guardRoles = new();
        List<ICustomRole>.Enumerator scpRoles = new();

        foreach (KeyValuePair<StartTeam, List<ICustomRole>> kvp in plugin.Roles)
        {
            Log.Debug($"Setting enumerator for {kvp.Key} - {kvp.Value.Count}");
            switch (kvp.Key)
            {
                case StartTeam.ClassD:
                    Log.Debug("Class d funny");
                    dClassRoles = kvp.Value.GetEnumerator();
                    break;
                case StartTeam.Scientist:
                    scientistRoles = kvp.Value.GetEnumerator();
                    break;
                case StartTeam.Guard:
                    guardRoles = kvp.Value.GetEnumerator();
                    break;
                case StartTeam.Scp:
                    scpRoles = kvp.Value.GetEnumerator();
                    break;
            }
        }

        foreach (Player player in Player.List)
        {
            if (API.API.ExemptPlayers.TryGetValue(player, out ExemptionType type) && type.HasFlag(ExemptionType.RoundStart))
                continue;

            Log.Debug($"Trying to give {player.Nickname} a role | {player.Role.Type}");
            CustomRole? role = null;
            switch (player.Role.Type)
            {
                case RoleTypeId.FacilityGuard:
                    role = Methods.GetCustomRole(ref guardRoles);
                    break;
                case RoleTypeId.Scientist:
                    role = Methods.GetCustomRole(ref scientistRoles);
                    break;
                case RoleTypeId.ClassD:
                    role = Methods.GetCustomRole(ref dClassRoles);
                    break;
                case { } when player.Role.Side == Side.Scp:
                    role = Methods.GetCustomRole(ref scpRoles);
                    break;
            }
            if (role?.TrackedPlayers.Count != role?.SpawnProperties.Limit)
            {
                role?.AddRole(player);

            }

        }

        guardRoles.Dispose();
        scientistRoles.Dispose();
        dClassRoles.Dispose();
        scpRoles.Dispose();
    }

    public void Spawned(SpawnedEventArgs ev)
    {
        List<ICustomRole>.Enumerator PrivateRoles = new();
        List<ICustomRole>.Enumerator SergeantRoles = new();
        List<ICustomRole>.Enumerator SpecialistRoles = new();
        List<ICustomRole>.Enumerator CaptainRoles = new();
        List<ICustomRole>.Enumerator ConscriptRoles = new();
        List<ICustomRole>.Enumerator MarauderRoles = new();
        List<ICustomRole>.Enumerator RepressorRoles = new();
        List<ICustomRole>.Enumerator RiflemanRoles = new();

        foreach (KeyValuePair<StartTeam, List<ICustomRole>> kvp in plugin.Roles)
        {
            Log.Debug($"Setting enumerator for {kvp.Key} - {kvp.Value.Count}");
            switch (kvp.Key)
            {
                case StartTeam.Private:
                    PrivateRoles = kvp.Value.GetEnumerator();
                    break;
                case StartTeam.Sergeant:
                    SergeantRoles = kvp.Value.GetEnumerator();
                    break;
                case StartTeam.Specialist:
                    SpecialistRoles = kvp.Value.GetEnumerator();
                    break;
                case StartTeam.Captain:
                    CaptainRoles = kvp.Value.GetEnumerator();
                    break;
                case StartTeam.Conscript:
                    ConscriptRoles = kvp.Value.GetEnumerator();
                    break;
                case StartTeam.Marauder:
                    MarauderRoles = kvp.Value.GetEnumerator();
                    break;
                case StartTeam.Repressor:
                    RepressorRoles = kvp.Value.GetEnumerator();
                    break;
                case StartTeam.Rifleman:
                    RiflemanRoles = kvp.Value.GetEnumerator();
                    break;
            }
        }
        if (API.API.ExemptPlayers.TryGetValue(ev.Player, out ExemptionType type) && type.HasFlag(ExemptionType.Respawn))
            return;

        Log.Debug($"Trying to give {ev.Player.Nickname} a role | {ev.Player.Role.Type}");
        CustomRole? role = null;

        switch (ev.Player.Role.Type)
        {
            case RoleTypeId.NtfPrivate:
                role = Methods.GetCustomRole(ref PrivateRoles);
                break;
            case RoleTypeId.NtfSergeant:
                role = Methods.GetCustomRole(ref SergeantRoles);
                break;
            case RoleTypeId.NtfSpecialist:
                role = Methods.GetCustomRole(ref SpecialistRoles);
                break;
            case RoleTypeId.NtfCaptain:
                role = Methods.GetCustomRole(ref CaptainRoles);
                break;
            case RoleTypeId.ChaosConscript:
                role = Methods.GetCustomRole(ref ConscriptRoles);
                break;
            case RoleTypeId.ChaosRepressor:
                role = Methods.GetCustomRole(ref RepressorRoles);
                break;
            case RoleTypeId.ChaosRifleman:
                role = Methods.GetCustomRole(ref RiflemanRoles);
                break;
            case RoleTypeId.ChaosMarauder:
                role = Methods.GetCustomRole(ref MarauderRoles);
                break;
        }
        if (role?.TrackedPlayers.Count != role?.SpawnProperties.Limit)
        {
            role?.AddRole(ev.Player);

        }

        PrivateRoles.Dispose();
        SergeantRoles.Dispose();
        SpecialistRoles.Dispose();
        CaptainRoles.Dispose();
        ConscriptRoles.Dispose();
        MarauderRoles.Dispose();
        RepressorRoles.Dispose();
        RiflemanRoles.Dispose();

    }

    public void OnRespawningTeam(RespawningTeamEventArgs ev)
    {
        if (ev.Players.Count == 0)
        {
            Log.Warn(
                $"{nameof(OnRespawningTeam)}: The respawn list is empty ?!? -- {ev.NextKnownTeam} / {ev.MaximumRespawnAmount}");

            foreach (Player player in Player.Get(RoleTypeId.Spectator))
                ev.Players.Add(player);
            ev.MaximumRespawnAmount = ev.Players.Count;
        }

        List<ICustomRole>.Enumerator roles = new();
        switch (ev.NextKnownTeam)
        {
            case SpawnableTeamType.ChaosInsurgency:
                if (plugin.Roles.TryGetValue(StartTeam.Chaos, out List<ICustomRole>? role))
                    roles = role.GetEnumerator();
                Log.Debug("Team is CI");
                break;
            case SpawnableTeamType.NineTailedFox:
                if (plugin.Roles.TryGetValue(StartTeam.Ntf, out List<ICustomRole>? pluginRole))
                    roles = pluginRole.GetEnumerator();
                Log.Debug("Team is NTF");
                break;
        }

        foreach (Player player in ev.Players)
        {
            if (API.API.ExemptPlayers.TryGetValue(player, out ExemptionType type) && type.HasFlag(ExemptionType.Respawn))
                continue;

            CustomRole? role = Methods.GetCustomRole(ref roles);

            if (role?.TrackedPlayers.Count != role?.SpawnProperties.Limit)
            {
                role?.AddRole(player);

            }
        }

        roles.Dispose();
    }

    public void OnReloadedConfigs()
    {
        plugin.Config.LoadConfigs();
    }

    public void FinishingRecall(FinishingRecallEventArgs ev)
    {
        Log.Debug($"{nameof(FinishingRecall)}: Selecting random zombie role.");
        if (plugin.Roles.ContainsKey(StartTeam.Scp) && ev.Target is not null)
        {
            if (API.API.ExemptPlayers.TryGetValue(ev.Target, out ExemptionType type) && type.HasFlag(ExemptionType.Revive))
                return;
            Log.Debug($"{nameof(FinishingRecall)}: List count {plugin.Roles[StartTeam.Scp].Count}");
            List<ICustomRole>.Enumerator roles = plugin.Roles[StartTeam.Scp].GetEnumerator();
            CustomRole? role = Methods.GetCustomRole(ref roles, false, true);

            Log.Debug($"Got custom role {role?.Name}");
            if (ev.Target.GetCustomRoles().Count == 0)
            {
                if (role?.TrackedPlayers.Count != role?.SpawnProperties.Limit)
                {
                    role?.AddRole(ev.Target);

                }

            }

            roles.Dispose();
        }
    }

    public void OnEscaping(EscapingEventArgs ev)
    {
        Log.Debug($"{nameof(OnEscaping)}: Selecting random escapee role.");
        if (plugin.Roles.ContainsKey(StartTeam.Escape))
        {
            Log.Debug($"{nameof(OnEscaping)}: List count {plugin.Roles[StartTeam.Escape].Count}");
            List<ICustomRole>.Enumerator roles = plugin.Roles[StartTeam.Escape].GetEnumerator();
            CustomRole? role = Methods.GetCustomRole(ref roles, ev.NewRole.GetRoleBase().RoleTypeId, true, false);

            Log.Debug($"Got custom role {role?.Name}");

            if (ev.Player.GetCustomRoles().Count == 0)
            {
                if (role?.TrackedPlayers.Count != role?.SpawnProperties.Limit)
                {
                    role?.AddRole(ev.Player);

                }

            }

            roles.Dispose();
        }
    }

    public void OnSpawningRagdoll(SpawningRagdollEventArgs ev)
    {
        if (!plugin.StopRagdollList.Contains(ev.Player))
            return;

        Log.Warn($"Stopped doll for {ev.Player.Nickname}");
        ev.IsAllowed = false;
        plugin.StopRagdollList.Remove(ev.Player);
    }
        

    }
