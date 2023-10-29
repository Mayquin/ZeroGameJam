using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GAMEMODE
{
    IDLE,
    LAUNCHED,
    SHOP,
    END
}

public enum LAYERS
{
    GOODPUMPKIN = 6,
    BADPUMPKIN,
    GROUND
}

public enum SKILLS
{
    GOLDENPUMPKINS,
    SPRINGPUMPKINS,
    BOOST,
    CROWS,
    COUNT
}

public enum BEHAVIORS
{
    MOVE
}

public enum INTERACTIONTYPE
{
    PUMPKIN,
    GOLDENPUMPKIN,
    CROW
}

public enum ANIMATIONS
{
    CANNON,
    FALL,
    DASHDOWN,
    JUMPDOWN
}

public enum AUDIOS
{
    MUSIC,
    CANNON,
    BUTTONCONFIRM,
    BUTTONSELECTION,
    DASH,
    GOLDENPUMPKIN,
    PUMPKINGAMEOVER,
    PUMPKINSMASH,
    BOUNCE,
    ROULLETTE
}