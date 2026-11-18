// Decompiled with JetBrains decompiler
// Type: TurnTitleDeceasedUnitPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 땓;

public class TurnTitleDeceasedUnitPanel : MonoBehaviour
{
  public GameObject UnitThumb;
  public GameObject UnitThumbBackground;

  public bool SetDeceasedUnitPanelData(땓.땦 Controller, 떀 Character, Shader DeadUnitShader)
  {
    if (Character == null || Controller == null || Controller.땴().딧 > 0 || !Object.op_Inequality((Object) this.UnitThumb, (Object) null))
      return false;
    this.UnitThumb.renderer.sharedMaterial = GlobalAppData.땲().딟(Character.땁().CharacterIcon, DeadUnitShader);
    return true;
  }
}
