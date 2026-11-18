// Decompiled with JetBrains decompiler
// Type: 땥.떎
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  internal class 떎
  {
    private const float 딟 = 3.1f;
    public List<List<땽>> 딟;
    private HashSet<땽> 딟;
    private 땽 딟;
    private List<땽> 딟;
    private bool 딟;
    private int 딟;
    private 땽 땄;

    public 떎()
    {
      this.딟 = 0;
      this.땄 = (땽) null;
      this.딟 = (땽) null;
      this.딟 = false;
      this.딟 = new HashSet<땽>();
      this.딟 = new List<땽>();
      this.딟 = new List<List<땽>>();
    }

    public void 딟([In] 땽 obj0)
    {
      if (this.딟 == 0)
      {
        this.딟 = obj0;
        this.딟 = 1;
      }
      else if (this.딟 == 1)
      {
        this.땄 = obj0;
        this.땄.땄 = this.딟;
        this.딟.딟 = this.땄;
        this.딟 = 2;
      }
      else
      {
        this.땄.딟 = obj0;
        obj0.땄 = this.땄;
        this.땄 = obj0;
        ++this.딟;
      }
    }

    public void 땄([In] 땽 obj0)
    {
      땽 딟 = obj0.딟;
      땽 땄 = obj0.땄;
      obj0.땄.딟 = 딟;
      obj0.딟.땄 = 땄;
      --this.딟;
    }

    public void 딟()
    {
      this.딟 = this.딢();
      this.딧();
      for (땽 딟 = this.딟.딟; 딟.딧(this.땄); 딟 = 딟.딟)
      {
        float num = this.딢(딟);
        if ((double) num >= 3.09999990463257 || (double) num <= -3.09999990463257 || (double) num == 0.0)
          this.땄(딟);
        else if (this.땃(딟))
          this.딟.Add(딟);
      }
      this.땄();
    }

    private void 땄()
    {
      while (this.딟.Count != 0)
      {
        IEnumerator<땽> enumerator = (IEnumerator<땽>) this.딟.GetEnumerator();
        enumerator.MoveNext();
        땽 current = enumerator.Current;
        this.딟.Remove(current);
        땽 땄 = current.땄;
        땽 땽 = current;
        땽 딟 = current.딟;
        this.딟.Add(new List<땽>(3) { 땄, 땽, 딟 });
        this.땄(current);
        if (this.딧(땄))
          this.딟.Add(땄);
        if (this.딧(딟))
          this.딟.Add(딟);
      }
    }

    private bool 딧([In] 땽 obj0) => obj0.딧(this.딟) && obj0.딧(this.땄) && this.땃(obj0);

    private void 딧()
    {
      for (땽 딟 = this.딟; 딟 != null; 딟 = 딟.딟)
        this.딟.Add(딟);
    }

    private float 딢([In] 땽 obj0)
    {
      땽 땽1 = obj0.딟 - obj0;
      땽 땽2 = obj0.땄 - obj0;
      return (float) Math.Atan2((double) 땽1.딟(땽2), (double) 땽1.땄(땽2));
    }

    private bool 딢()
    {
      땽 땽1 = this.딟.딟 - this.딟;
      땽 땽2 = this.땄 - this.딟;
      return Math.Atan2((double) 땽1.딟(땽2), (double) 땽1.땄(땽2)) >= 0.0;
    }

    private bool 땃([In] 땽 obj0) => this.딟 == (double) this.딢(obj0) >= 0.0;
  }
}
