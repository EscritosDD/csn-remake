// Decompiled with JetBrains decompiler
// Type: 딧.땲
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딧
{
  public class 땲 : IDisposable, 딝
  {
    private Hashtable 딟;
    private byte[] 딟;
    private 땥 딟;
    private WWW 딟;

    public 땲([In] string obj0, [In] string obj1, [In] byte[] obj2)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0);
      this.딟 = obj2;
      if (obj2 == null)
      {
        if (obj0 != "GET")
          throw new 딶("GET must be used when no payload is provided");
      }
      else if (obj0 != "POST")
        throw new 딶("POST must be used when a payload is provided");
    }

    public void 딟([In] string obj0, [In] string obj1)
    {
      if (this.딟 == null)
        this.딟 = new Hashtable();
      this.딟.Add((object) obj0, (object) obj1);
    }

    public void Dispose()
    {
      if (this.딟 == null)
        return;
      this.딟.Dispose();
      this.딟 = (WWW) null;
    }

    [SpecialName]
    public bool 딧() => this.딟.isDone;

    [CompilerGenerated]
    [SpecialName]
    public string 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 땃() => this.땄;

    public void 딟()
    {
      if (this.딟 != null)
        this.딟 = new WWW(this.땄(), this.딟, this.딟);
      else
        this.딟 = new WWW(this.땄());
    }

    [SpecialName]
    public 땥 딢()
    {
      if (this.딧() && this.딟 == null)
        this.딟 = (땥) new 떏(this.딟);
      return this.딟;
    }
  }
}
