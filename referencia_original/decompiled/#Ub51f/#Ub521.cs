// Decompiled with JetBrains decompiler
// Type: 딟.딡
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딟
{
  public sealed class 딡 : IDisposable
  {
    public const string 딟 = "x-fireteam-aes";
    private 딧.딝 딟;
    private string 땄;

    public 딡([In] string obj0, [In] string obj1, [In] byte[] obj2)
    {
      this.딟 = (딧.딝) new 딧.땭(obj0, obj1, obj2);
      this.땄 = obj0;
    }

    public void 딟() => this.딟.딟();

    public void 딟([In] string obj0, [In] string obj1) => this.딟.딟(obj0, obj1);

    [SpecialName]
    public bool 땄() => this.딟.딧();

    public void 딧()
    {
      if (this.딟.딢() == null)
      {
        this.딟(new 땀(딴.땄));
      }
      else
      {
        딨 딨 = new 딨(this.딟.딢());
        if (딨.딟())
          this.딟(딨);
        else
          this.딟(new 땀(딴.딧, 딨));
      }
    }

    private void 딟([In] 딨 obj0)
    {
      if (this.딶() == null)
        return;
      this.딶()(obj0);
    }

    private void 딟([In] 땀 obj0)
    {
      if (this.땓() == null)
        return;
      this.땓()(obj0);
    }

    public void Dispose()
    {
      if (this.딟 == null)
        return;
      this.딟 = (딧.딝) null;
    }

    [SpecialName]
    public string 딢() => this.딟.땄();

    [SpecialName]
    public string 땃() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public Action<딨> 딶() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] Action<딨> obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public Action<땀> 땓() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] Action<땀> obj0) => this.딟 = obj0;
  }
}
