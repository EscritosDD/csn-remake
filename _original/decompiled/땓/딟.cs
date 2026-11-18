// Decompiled with JetBrains decompiler
// Type: 땓.딟
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 딟
  {
    private int 딟;
    private int 땄;
    private bool 딟 = true;

    public 딟() => this.딟(new List<딶.땏>());

    [CompilerGenerated]
    [SpecialName]
    public List<딶.땏> 딟() => this.딟;

    public void 딟([In] 딶.땏 obj0) => this.딟().Add(obj0);

    public bool 땄() => this.딟;

    public void 딟([In] bool obj0) => this.딟 = obj0;

    public void 딟([In] 땓.딟 obj0)
    {
      if (obj0 == null)
        return;
      this.딟 = obj0.땄();
      this.딟().AddRange((IEnumerable<딶.땏>) obj0.딟());
      obj0.딢();
    }

    public bool 딧() => this.딟().Count == 0;

    public void 딢()
    {
      this.딟().Clear();
      this.딟 = 0;
    }

    public void 땄([In] bool obj0)
    {
      for (; this.딟 < this.딟().Count; ++this.딟)
      {
        if (obj0 || !(this.딟()[this.딟] is 딶.떒))
          this.딟()[this.딟].땓();
      }
      this.땄 = this.딟;
      this.딢();
    }

    public void 딟([In] int obj0, [In] 딶.땮 obj1)
    {
      int num = Mathf.Min(this.딟, this.딟().Count - 1);
      for (int 땄 = this.땄; 땄 <= num; ++땄)
      {
        if (this.딟()[땄].딢() && this.딟()[땄] is 딶.떒 떒1)
          떒1.딟(obj0, obj1);
      }
    }

    public void 땃()
    {
      bool flag = false;
      for (int 땄 = this.땄; 땄 < this.딟; ++땄)
      {
        if (this.딟()[땄].딢())
        {
          flag = true;
          this.딟()[땄].딶();
        }
        else if (!flag)
          ++this.땄;
      }
      for (float num = Time.realtimeSinceStartup + 1f / 500f; this.딟 < this.딟().Count && (double) Time.realtimeSinceStartup <= (double) num; ++this.딟)
      {
        this.딟()[this.딟].딶();
        if (!this.딟()[this.딟].땃())
          break;
      }
    }

    public bool 딶() => this.딟 >= this.딟().Count && this.땄 == this.딟;
  }
}
