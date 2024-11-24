using System;
using _Project.Data;
using _Project.Source;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public abstract class Unit
{
    public CMSEntity model { get; protected set; }

    public int Gold;
    public int Column;
    public float MaxHealth;
    public float Health;
    public Vector2 DamageRange;
    public float Evasion;
    public float DamageReduction;
    public float HitChance;
    public float CritChance;
    public float Blockage;
    public int HealthRegeneration;
    public TraitContainer Traits = new();
    
    public float RelativeHealth => Health / MaxHealth;

    public bool CanAttack()
    {
        return !model.Is<TagHealAttack>();
    }
    
    
}