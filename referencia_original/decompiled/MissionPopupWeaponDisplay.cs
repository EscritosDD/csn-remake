// Decompiled with JetBrains decompiler
// Type: MissionPopupWeaponDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class MissionPopupWeaponDisplay : MonoBehaviour
{
  private 딢.땻 딟;
  public GameObject WeaponImage;

  public void Init(땓.떀 Unit)
  {
    GlobalAppData.땼().땃(Unit.딸());
    this.딟 = GlobalAppData.땼().땔(Unit.딸());
  }

  private void Update()
  {
    if (this.딟 == null || !this.딟.딢())
      return;
    this.WeaponImage.renderer.sharedMaterial = this.딟.땥().Icon;
    this.딟 = (딢.땻) null;
  }
}
