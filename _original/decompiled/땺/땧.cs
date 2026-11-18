// Decompiled with JetBrains decompiler
// Type: 땺.땧
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땺
{
  public class 땧 : 땫
  {
    protected List<땧> 딟;
    protected 땊 딟;
    protected List<땮> 딟 = new List<땮>();
    protected List<땮> 땄;
    protected List<딽> 딟;

    public 땧([In] IList<땊> obj0)
    {
      if (obj0.Count < 3)
        throw new ArgumentException("List has fewer than 3 points", "points");
      if (obj0[0].Equals((object) obj0[obj0.Count - 1]))
        obj0.RemoveAt(obj0.Count - 1);
      this.딟.AddRange(obj0.Cast<땮>());
    }

    public 땧([In] IEnumerable<땊> obj0)
      : this((IList<땊>) ((object) (obj0 as IList<땊>) ?? (object) obj0.ToArray<땊>()))
    {
    }

    public 땧()
    {
    }

    [SpecialName]
    public IList<땧> 땃() => (IList<땧>) this.딟;

    [SpecialName]
    public 떒 딧() => 떒.딧;

    [SpecialName]
    public IList<땮> 딟() => (IList<땮>) this.딟;

    [SpecialName]
    public IList<딽> 땄() => (IList<딽>) this.딟;

    public void 딟([In] 딽 obj0) => this.딟.Add(obj0);

    public void 딟([In] IEnumerable<딽> obj0) => this.딟.AddRange(obj0);

    public void 딢()
    {
      if (this.딟 == null)
        return;
      this.딟.Clear();
    }

    public void 딟([In] 떊 obj0)
    {
      if (this.딟 == null)
        this.딟 = new List<딽>(this.딟.Count);
      else
        this.딟.Clear();
      for (int index = 0; index < this.딟.Count - 1; ++index)
        obj0.딟(this.딟[index], this.딟[index + 1]);
      obj0.딟(this.딟[0], this.딟[this.딟.Count - 1]);
      obj0.딟.AddRange((IEnumerable<땮>) this.딟);
      if (this.딟 != null)
      {
        foreach (땧 땧 in this.딟)
        {
          for (int index = 0; index < 땧.딟.Count - 1; ++index)
            obj0.딟(땧.딟[index], 땧.딟[index + 1]);
          obj0.딟(땧.딟[0], 땧.딟[땧.딟.Count - 1]);
          obj0.딟.AddRange((IEnumerable<땮>) 땧.딟);
        }
      }
      if (this.땄 == null)
        return;
      obj0.딟.AddRange((IEnumerable<땮>) this.땄);
    }

    public void 딟([In] 땮 obj0)
    {
      if (this.땄 == null)
        this.땄 = new List<땮>();
      this.땄.Add(obj0);
    }

    public void 딟([In] List<땮> obj0)
    {
      if (this.땄 == null)
        this.땄 = new List<땮>();
      this.땄.AddRange((IEnumerable<땮>) obj0);
    }

    public void 딶()
    {
      if (this.땄 == null)
        return;
      this.땄.Clear();
    }

    public void 딟([In] 땧 obj0)
    {
      if (this.딟 == null)
        this.딟 = new List<땧>();
      this.딟.Add(obj0);
    }

    public void 딟([In] 땊 obj0, [In] 땊 obj1)
    {
      int num = this.딟.IndexOf((땮) obj0);
      if (num == -1)
        throw new ArgumentException("Tried to insert a point into a Polygon after a point not belonging to the Polygon", "point");
      obj1.딟(obj0.딟());
      obj1.땄(obj0);
      obj0.딟().땄(obj1);
      obj0.딟(obj1);
      this.딟.Insert(num + 1, (땮) obj1);
    }

    public void 딟([In] IEnumerable<땊> obj0)
    {
      foreach (땊 땊 in obj0)
      {
        땊.땄(this.딟);
        if (this.딟 != null)
        {
          땊.딟(this.딟.딟());
          this.딟.딟(땊);
        }
        this.딟 = 땊;
        this.딟.Add((땮) 땊);
      }
      땊 땊1 = (땊) this.딟[0];
      this.딟.딟(땊1);
      땊1.땄(this.딟);
    }

    public void 딟([In] 땊 obj0)
    {
      obj0.땄(this.딟);
      obj0.딟(this.딟.딟());
      this.딟.딟(obj0);
      this.딟.Add((땮) obj0);
    }

    public void 땄([In] 땊 obj0)
    {
      땊 땊1 = obj0.딟();
      땊 땊2 = obj0.땄();
      땊2.딟(땊1);
      땊1.땄(땊2);
      this.딟.Remove((땮) obj0);
    }
  }
}
