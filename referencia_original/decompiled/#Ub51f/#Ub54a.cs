// Decompiled with JetBrains decompiler
// Type: 딟.땊
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using 땄;

namespace 딟
{
  public class 땊 : 땷
  {
    private 땧 딟;
    private Action 딟;
    private Action<Texture2D> 딟;

    public 땊([In] 땇 obj0, [In] 땧 obj1, [In] string obj2, [In] Action obj3, [In] Action<Texture2D> obj4)
      : base(obj0)
    {
      this.딟 = obj1;
      this.딟 = obj3;
      this.딟 = obj4;
      this.딟("GET", obj2, (byte[]) null, 땷.딸.딧);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        this.딟.딟 = new Texture2D(4, 4);
        ((Texture) this.딟.딟).wrapMode = (TextureWrapMode) 1;
        this.딟.딧(this.딟.딟.LoadImage(this.딝().딟()));
      }
      this.딟.땄(true);
      this.딢();
    }

    public override void 땄() => this.딟.땄(true);

    private new void 딢()
    {
      if (this.딟.딧())
        this.딟(this.딟.딟);
      else
        this.딟();
    }

    [SpecialName]
    public override 땄.땘 딧() => (땄.땘) this.딟;

    private struct 땍
    {
      public int 딟;
      public int 땄;
      public long 딟;
      public int 딧;
      public int 딢;
      public int 땃;
      public int 딶;
      public int 땓;
      public int 땺;
      public int 땥;
      public int 딝;
      public int 떎;

      public 땍([In] BinaryReader obj0)
      {
        this.딟 = obj0.ReadInt32();
        this.땄 = obj0.ReadInt32();
        this.딟 = obj0.ReadInt64();
        this.딧 = obj0.ReadInt32();
        this.딢 = obj0.ReadInt32();
        this.땃 = obj0.ReadInt32();
        this.딶 = obj0.ReadInt32();
        this.땓 = obj0.ReadInt32();
        this.땺 = obj0.ReadInt32();
        this.땥 = obj0.ReadInt32();
        this.딝 = obj0.ReadInt32();
        this.떎 = obj0.ReadInt32();
      }

      [SpecialName]
      public int 딟() => 52 + this.떎;
    }
  }
}
