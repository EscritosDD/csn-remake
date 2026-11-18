// Decompiled with JetBrains decompiler
// Type: UnitSelector
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("Scripts/Units/Selector")]
public class UnitSelector : MonoBehaviour
{
  public void OnClicked()
  {
    if (this.get_Controller() == null)
      return;
    this.get_Controller().땼();
  }

  public void OnHoldStart()
  {
    if (this.get_Controller() == null)
      return;
    this.get_Controller().땢();
  }

  public void OnHoldStop()
  {
    if (this.get_Controller() == null)
      return;
    this.get_Controller().딷();
  }

  [CompilerGenerated]
  [SpecialName]
  public 땓.땦 get_Controller() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_Controller(땓.땦 value) => this.딟 = value;
}
