// Decompiled with JetBrains decompiler
// Type: 땥.땾
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 땾
  {
    public bool 딟;
    public 딺 딟;
    public List<떀> 딟 = new List<떀>(8);
    public float 딟 = 500f;
    private float[] 딟 = new float[8];
    private bool 땄;
    private 떁[] 딟 = new 떁[8];
    private 땱 딟;

    public 땾([In] IEnumerable<땨> obj0, [In] 땱 obj1, [In] float obj2)
      : this(obj0, obj1, obj2, (object) null)
    {
    }

    public 땾([In] IEnumerable<땨> obj0, [In] 땱 obj1, [In] float obj2, [In] object obj3)
    {
      this.딟 = obj1;
      this.딟.떎().딟 += new 딝.땠(this.딟);
      this.딟 = new 딺(this.딟);
      this.딟.딟(땎.딧);
      foreach (땨 땨 in obj0)
        this.딟.Add(this.딟.딟((땺.땏) new 땺.떅(땨, obj2), obj3));
    }

    private void 딟([In] 떆 obj0, [In] 딜 obj1)
    {
      if (this.딟 || !this.딟.Contains(obj0.딟) && !this.딟.Contains(obj0.땄))
        return;
      float val1 = 0.0f;
      int 딟 = obj0.딟.딟;
      for (int index = 0; index < 딟; ++index)
        val1 = Math.Max(val1, obj1.딟[index].딟);
      if ((double) val1 <= (double) this.딟)
        return;
      this.땄 = true;
    }

    public void 딟()
    {
      if (this.땄)
      {
        this.땄();
        this.딟 = true;
        this.땄 = false;
      }
      if (this.딟)
        return;
      if (this.딟.Count > this.딟.Length)
      {
        this.딟 = new 떁[this.딟.Count];
        this.딟 = new float[this.딟.Count];
      }
      for (int index = 0; index < this.딟.Count; ++index)
      {
        this.딟[index] = this.딟[index].땓().딢();
        this.딟[index] = this.딟[index].땓().땃();
      }
    }

    private void 땄()
    {
      this.딟.떎().딟 -= new 딝.땠(this.딟);
      for (int index = 0; index < this.딟.Count; ++index)
      {
        떀 떀 = this.딟[index];
        땺.땏 땏 = 떀.땃().땄();
        object obj = 떀.땺();
        this.딟.딟(떀);
        딺 딺 = 딝.딝.딟(this.딟);
        딺.딟(땎.딧);
        딺.땄(this.딟.땼());
        딺.땃(this.딟.땢());
        딺.딟(this.딟.땋());
        딺.딟(땏, obj);
        딺.땄(this.딟[index]);
        딺.딟(this.딟[index]);
      }
      this.딟.땄(this.딟);
      this.딟.땄(this);
    }

    public void 딧() => this.땄 = true;
  }
}
