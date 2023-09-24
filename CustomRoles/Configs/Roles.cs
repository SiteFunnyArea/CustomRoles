namespace CustomRoles.Configs;

using System.Collections.Generic;
using CustomRoles.Roles;
using Exiled.CustomRoles.API.Features;
using YamlDotNet.Serialization;

public class Roles
{
    public List<BallisticZombie> BallisticZombies { get; set; } = new()
    {
        new BallisticZombie(),
    };

    public List<BerserkZombie> BerserkZombies { get; set; } = new()
    {
        new BerserkZombie(),
    };

    public List<ChargerZombie> ChargerZombies { get; set; } = new()
    {
        new ChargerZombie(),
    };

    public List<Demolitionist> Demolitionists { get; set; } = new()
    {
        new Demolitionist(),
    };

    public List<Dwarf> Dwarves { get; set; } = new()
    {
        new Dwarf(),
    };

    public List<DwarfZombie> DwarfZombies { get; set; } = new()
    {
        new DwarfZombie(),
    };

    public List<Medic> Medics { get; set; } = new()
    {
        new Medic(),
    };

    public List<MedicZombie> MedicZombies { get; set; } = new()
    {
        new MedicZombie(),
    };

    public List<PDZombie> PdZombies { get; set; } = new()
    {
        new PDZombie(),
    };

    public List<Phantom> Phantoms { get; set; } = new()
    {
        new Phantom(),
    };

    public List<PlagueZombie> PlagueZombies { get; set; } = new()
    {
        new PlagueZombie(),
    };

    public List<TankZombie> TankZombies { get; set; } = new()
    {
        new TankZombie(),
    };
    public List<HammerDownCombatant> HammerDownCombatants { get; set; } = new()
    {
        new HammerDownCombatant(),
    };

    public List<Epsilon9FireEater> Epsilon9FireEaters { get; set; } = new()
    {
        new Epsilon9FireEater(),
    };

    public List<Beta7MazHattersCombatant> Beta7MazHattersCombatants { get; set; } = new()
    {
        new Beta7MazHattersCombatant(),
    };

    public List<Captain> Captains { get; set; } = new()
    {
        new Captain(),
    };

    public List<Silencer> Silencers { get; set; } = new()
    {
        new Silencer(),
    };
    public List<Bulldozer> Bulldozers { get; set; } = new()
    {
        new Bulldozer(),
    };
    public List<Sniper> Snipers { get; set; } = new()
    {
        new Sniper(),
    };

    public List<Brute> Brutes { get; set; } = new()
    {
        new Brute(),
    };

    public List<ClassD9341> ClassD9341s { get; set; } = new()
    {
        new ClassD9341(),
    };

    public List<FlashlightMan> FlashlightMans { get; set; } = new()
    {
        new FlashlightMan(),
    };



    public List<FacilityGuardSupervisor> FacilityGuardSupervisors { get; set; } = new()
    {
        new FacilityGuardSupervisor(),
    };

    public List<FacilityGuardGunslinger> FacilityGuardGunslingers { get; set; } = new()
    {
        new FacilityGuardGunslinger(),
    };

    public List<FacilityGuardMedic> FacilityGuardMedics { get; set; } = new()
    {
        new FacilityGuardMedic(),
    };

    public List<FacilityGuardZM> FacilityGuardZMs { get; set; } = new()
    {
        new FacilityGuardZM(),
    };

    public List<ContainmentEngineer> ContainmentEngineers { get; set; } = new()
    {
        new ContainmentEngineer(),
    };

    public List<Major> Majors { get; set; } = new()
    {
        new Major(),
    };
}