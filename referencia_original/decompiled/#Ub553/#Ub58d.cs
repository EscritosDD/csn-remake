// Decompiled with JetBrains decompiler
// Type: 땓.떍
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace 땓
{
  public class 떍
  {
    public Action 딟;
    private string 딟;
    private float 딟;
    private bool 딟;
    private bool 땄;
    private 딢.땿 딟 = new 딢.땿();
    private bool 딧;
    private bool 딢;
    private bool 땃;

    public 떍([In] string obj0, [In] float obj1)
    {
      this.딟 = obj0;
      this.딟 = obj1;
    }

    public void 딟()
    {
      if (!this.땃 || !this.딟)
        return;
      this.딟.딟();
      if (!this.딟.땄())
        return;
      GlobalAppData.딟("unity_is_video_playing", string.Empty, new Action<object>(this.땄));
      if (this.땄)
        this.딧();
      else
        this.딟.딟(this.딟);
    }

    public void 땄()
    {
      this.땃 = true;
      this.딟 = new 딢.땿();
      GlobalAppData.딟("unity_start_video", this.딟, new Action<object>(this.딟));
    }

    private void 딟([In] object obj0)
    {
      this.딟.딟(this.딟);
      this.딟 = true;
      if (GlobalAppData.딝())
      {
        this.딧 = true;
        GlobalAppData.땺();
      }
      if (!GlobalAppData.떎())
        return;
      this.딢 = true;
      GlobalAppData.땥();
    }

    private void 땄([In] object obj0) => this.땄 = string.Compare((string) obj0, "false") == 0;

    private void 딧()
    {
      this.땃 = false;
      this.딟();
      if (this.딧)
        GlobalAppData.딶();
      if (!this.딢)
        return;
      GlobalAppData.땓();
    }
  }
}
