// Decompiled with JetBrains decompiler
// Type: 땺.땸
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땺
{
  public class 땸 : 땫
  {
    public 땸([In] List<땮> obj0) => this.딟((IList<땮>) new List<땮>((IEnumerable<땮>) obj0));

    [CompilerGenerated]
    [SpecialName]
    public IList<땮> 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public IList<딽> 땄() => this.딟;

    [SpecialName]
    public virtual 떒 딧() => 떒.딟;

    public void 딟([In] 딽 obj0) => this.땄().Add(obj0);

    public void 딟([In] IEnumerable<딽> obj0)
    {
      foreach (딽 딽 in obj0)
        this.땄().Add(딽);
    }

    public void 딢() => this.땄().Clear();

    public virtual void 딟([In] 떊 obj0)
    {
      if (this.땄() == null)
      {
        // ISSUE: reference to a compiler-generated method
        this.딟((IList<딽>) new List<딽>(this.딟().Count));
      }
      else
        this.땄().Clear();
      obj0.딟.AddRange((IEnumerable<땮>) this.딟());
    }
  }
}
