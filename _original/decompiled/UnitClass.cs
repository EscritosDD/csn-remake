// Decompiled with JetBrains decompiler
// Type: UnitClass
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class UnitClass : ScriptableObject
{
  public LocalisationEntry ClassName;
  public LocalisationEntry DefaultName;
  public LocalisationEntry Bio;
  public LocalisationEntry FlavourText;
  public string BodyTypeId;
  public 땓.땅 ClassType;
  public 딢.딴[] Abilities;
  public 땓.땍[] SupportedWeaponCategories;
  public Material GUIIcon;
  public Material CharacterIcon;
  public 땓.딽 Gender;

  public bool 딟()
  {
    for (int index = 0; index < this.Abilities.Length; ++index)
    {
      if (땓.땎.딧(this.Abilities[index]))
        return true;
    }
    return false;
  }
}
