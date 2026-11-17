// Decompiled with JetBrains decompiler
// Type: 딢.땆
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딢
{
  public class 땆
  {
    public string 딟;
    public string 땄;
    public int 딟;
    public Material 딟;
    private 땄.땣 딟;
    private 땓.땶 딟;
    private bool 딟;
    private bool 땄;

    public 땆([In] string obj0, [In] int obj1)
    {
      this.딟 = obj0;
      this.딟 = obj1;
    }

    public 땆([In] string obj0, [In] string obj1, [In] int obj2)
    {
      this.땄 = obj0;
      this.딟 = obj1;
      this.딟 = obj2;
    }

    public void 딟()
    {
      if (this.땄 == null)
      {
        this.딟 = GlobalAppData.떏().땄(this.딟, false);
        this.딟 = (this.딟.딟.땃() as 땓.땇).딧();
      }
      else
      {
        this.딟 = true;
        this.딟 = 땓.땶.딟(GlobalAppData.땽().딳());
      }
    }

    public void 땄()
    {
      if (this.딟 != null && this.딟.땄())
      {
        if (this.딟.딧())
          this.땄 = this.딟.딟.땄();
        this.딟 = (땄.땣) null;
        this.딟 = true;
      }
      if (this.딟 == null || !this.딟.딟())
        return;
      if (this.딟.땄())
        this.딟 = this.딟.딧();
      this.딟 = (땓.땶) null;
      this.땄 = true;
    }

    [SpecialName]
    public bool 딧() => this.딟 && this.땄;

    [SpecialName]
    public void 딟([In] bool obj0)
    {
    }
  }
}
