// Decompiled with JetBrains decompiler
// Type: 딟.딱
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딟
{
  public class 딱 : IDisposable
  {
    private WWW 딟;
    private AssetBundleCreateRequest 딟;
    private TextAsset 딟;

    public 딱([In] TextAsset obj0)
    {
      this.딟 = obj0;
      this.딟 = AssetBundle.CreateFromMemory(obj0.bytes);
    }

    public 딱([In] WWW obj0) => this.딟 = obj0;

    [DebuggerHidden]
    private IEnumerable 딟([In] WWW obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      딱.\u003CFinishLoadRequest\u003Ec__Iterator0 requestCIterator0 = new 딱.\u003CFinishLoadRequest\u003Ec__Iterator0()
      {
        딟 = obj0,
        땄 = obj0
      };
      // ISSUE: reference to a compiler-generated field
      requestCIterator0.딟 = -2;
      return (IEnumerable) requestCIterator0;
    }

    [DebuggerHidden]
    private IEnumerable 딟([In] AsyncOperation obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      딱.\u003CFinishLoadRequest\u003Ec__Iterator1 requestCIterator1 = new 딱.\u003CFinishLoadRequest\u003Ec__Iterator1()
      {
        딟 = obj0,
        땄 = obj0
      };
      // ISSUE: reference to a compiler-generated field
      requestCIterator1.딟 = -2;
      return (IEnumerable) requestCIterator1;
    }

    [SpecialName]
    public bool 딟()
    {
      if (this.딟 != null)
      {
        if ((double) this.딟.progress == 1.0)
          this.딟(this.딟);
        return this.딟.isDone;
      }
      if (this.딟 == null)
        return false;
      if ((double) ((AsyncOperation) this.딟).progress == 1.0)
        this.딟((AsyncOperation) this.딟);
      return ((AsyncOperation) this.딟).isDone;
    }

    [SpecialName]
    public AssetBundle 땄()
    {
      if (this.딟 != null)
        return this.딟.assetBundle;
      return this.딟 != null ? this.딟.assetBundle : (AssetBundle) null;
    }

    public void Dispose()
    {
      if (this.딟 != null)
      {
        this.딟.Dispose();
        this.딟 = (WWW) null;
      }
      if (this.딟 != null)
        this.딟 = (AssetBundleCreateRequest) null;
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      Resources.UnloadAsset((Object) this.딟);
      this.딟 = (TextAsset) null;
    }
  }
}
