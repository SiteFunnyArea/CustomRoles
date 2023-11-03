namespace CustomRoles.API;

using System;

[Flags]
public enum StartTeam
{
    ClassD = 1,
    Scientist = 2,
    Guard = 4,
    Ntf = 8,
    Chaos = 16,
    Scp = 32,
    Revived = 64,
    Escape = 128,
    Other = 256,

    Private = 512,
    Sergeant = 1024,
    Specialist = 2048,
    Captain = 4096,
    Conscript = 8192,
    Repressor = 16384,
    Marauder = 32768,
    Rifleman = 65536,
}