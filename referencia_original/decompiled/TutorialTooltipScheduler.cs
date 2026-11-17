// Decompiled with JetBrains decompiler
// Type: TutorialTooltipScheduler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class TutorialTooltipScheduler : MonoBehaviour
{
  private GameObject 딟;
  private GameObject 땄;
  private int 딟;
  public GameObject MainOverlay;
  public GameObject[] TooltipOverlays;

  public void Restart()
  {
    this.딟 = -1;
    this.AdvanceTooltip();
  }

  public bool AdvanceTooltip()
  {
    this.CloseTooltipOverlay();
    ++this.딟;
    if (this.딟 >= this.TooltipOverlays.Length)
    {
      if (Object.op_Inequality((Object) this.딟, (Object) null))
      {
        Object.Destroy((Object) this.딟);
        this.딟 = (GameObject) null;
      }
      return false;
    }
    if (Object.op_Equality((Object) this.딟, (Object) null) && Object.op_Inequality((Object) this.MainOverlay, (Object) null))
    {
      this.딟 = Object.Instantiate((Object) this.MainOverlay) as GameObject;
      this.딟.transform.localPosition = new Vector3(0.0f, 1f, 0.0f);
    }
    this.땄 = Object.Instantiate((Object) this.TooltipOverlays[this.딟]) as GameObject;
    this.땄.transform.parent = ((Component) this).transform;
    return true;
  }

  private void CloseTooltipOverlay()
  {
    if (!Object.op_Inequality((Object) this.땄, (Object) null))
      return;
    Object.Destroy((Object) this.땄);
    this.땄 = (GameObject) null;
  }
}
