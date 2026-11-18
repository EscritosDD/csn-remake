// Decompiled with JetBrains decompiler
// Type: XPProgressBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 땓;

public class XPProgressBar : MonoBehaviour
{
  private Vector3 딟;
  private Vector3 땄;

  private void Awake()
  {
    Bounds bounds = ((Component) this).renderer.bounds;
    this.딟 = ((Bounds) ref bounds).extents;
    this.땄 = ((Component) this).transform.localPosition;
  }

  public void InitForPlayer()
  {
    int num;
    PlayerLevel playerLevel = GlobalAppData.딢().GenericData.딟(GlobalAppData.땽().딣(), out num);
    this.UpdateSizeAndPosition((float) num / (float) playerLevel.RequiredXP);
  }

  public void InitForPlayer(int XP)
  {
    int num;
    PlayerLevel playerLevel = GlobalAppData.딢().GenericData.딟(XP, out num);
    this.UpdateSizeAndPosition((float) num / (float) playerLevel.RequiredXP);
  }

  public void InitForUnit(떀 Char)
  {
    int num;
    UnitLevel unitLevel;
    GlobalAppData.딢().딟(Char.땝(), out num, out unitLevel);
    this.UpdateSizeAndPosition(unitLevel != null ? (float) num / (float) unitLevel.RequiredXP : 1f);
  }

  public void UpdateSizeAndPosition(float Scale)
  {
    Vector3 땄 = this.땄;
    ref Vector3 local = ref 땄;
    local.x = (__Null) (local.x - this.딟.x * (1.0 - (double) Scale));
    ((Component) this).transform.localPosition = 땄;
    ((Component) this).transform.localScale = new Vector3(Scale, 1f, 1f);
  }
}
