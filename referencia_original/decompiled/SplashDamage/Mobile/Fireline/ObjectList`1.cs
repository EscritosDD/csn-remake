// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireline.ObjectList`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using 딧;

namespace SplashDamage.Mobile.Fireline
{
  [딷]
  [Serializable]
  public sealed class ObjectList<T>
  {
    [떁(Name = "page")]
    public int 딟 { get; [param: In] set; }

    [떁(Name = "prev_page")]
    public int 땄 { get; [param: In] set; }

    [떁(Name = "next_page")]
    public int 딧 { get; [param: In] set; }

    [떁(Name = "pages")]
    public int 딢 { get; [param: In] set; }

    [떁(Name = "total_count")]
    public int 땃 { get; [param: In] set; }

    [떁(Name = "items")]
    public T[] 딶
    {
      get => (T[]) this.딟;
      [param: In] set => this.딟 = (int) value;
    }
  }
}
