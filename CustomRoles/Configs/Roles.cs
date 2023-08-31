namespace CustomRoles.Configs;

using System.Collections.Generic;
using CustomItems_SFA.Roles;
using CustomRoles.Roles;

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
    public List<FacilityGuardSupervisor> FacilityGuardSupervisors { get; set; } = new()
    {
        new FacilityGuardSupervisor(),
    };
}