// Decompiled with JetBrains decompiler
// Type: 땥.땢
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  internal class 땢
  {
    public List<땲> 딟;
    public List<List<땽>> 딟;
    private 땲 딟;
    private List<땋> 딟;
    private 땭 딟;
    private float 딟 = 1f / 1000f;
    private 땤 딟;
    private List<떎> 딟;

    public 땢([In] List<땽> obj0, [In] float obj1)
    {
      this.딟 = obj1;
      this.딟 = new List<List<땽>>();
      this.딟 = new List<땲>();
      this.딟 = new List<떎>();
      this.딟 = this.딟(obj0);
      this.딟 = new 땤();
      this.딟 = this.딟.딟(this.딟);
      this.딟 = new 땭((떂) 딦.딟(this.딟));
      this.딟();
    }

    private void 딟()
    {
      foreach (땋 땋 in this.딟)
      {
        foreach (땲 땲1 in this.딟.땄(땋))
        {
          this.딟.딟.Remove(땲1);
          bool flag1 = 땲1.딟(땋.딟);
          bool flag2 = 땲1.딟(땋.땄);
          땲[] 땲Array;
          if (flag1 && flag2)
          {
            땲Array = this.딟.딟(땲1, 땋);
            this.딟.딟(땲1.딟, 땋, 땲Array);
          }
          else if (flag1 && !flag2)
          {
            땲Array = this.딟.땄(땲1, 땋);
            this.딟.땄(땲1.딟, 땋, 땲Array);
          }
          else if (!flag1 && !flag2)
          {
            땲Array = this.딟.딧(땲1, 땋);
            this.딟.딧(땲1.딟, 땋, 땲Array);
          }
          else
          {
            땲Array = this.딟.딢(땲1, 땋);
            this.딟.딢(땲1.딟, 땋, 땲Array);
          }
          foreach (땲 땲2 in 땲Array)
            this.딟.딟.Add(땲2);
        }
        this.딟.딟();
      }
      foreach (땲 땲 in this.딟.딟)
        this.딟(땲);
      foreach (땲 땲 in this.딟.딟)
      {
        if (땲.딟)
        {
          this.딟.Add(땲);
          땲.딧();
        }
      }
      this.땄();
    }

    private void 땄()
    {
      foreach (땋 땋 in this.딟)
      {
        if (땋.딟.Count > 2)
        {
          떎 떎 = new 떎();
          List<땽> 땽List1 = new List<땽>((IEnumerable<땽>) 땋.딟);
          땽List1.Sort((Comparison<땽>) ((obj0, obj1) => obj0.딟.CompareTo(obj1.딟)));
          foreach (땽 땽 in 땽List1)
            떎.딟(땽);
          떎.딟();
          foreach (List<땽> 땽List2 in 떎.딟)
            this.딟.Add(땽List2);
          this.딟.Add(떎);
        }
      }
    }

    private void 딟([In] 땲 obj0)
    {
      if (obj0.땄 != this.딟.땄 && obj0.딟 != this.딟.딟)
        return;
      obj0.딟();
    }

    private List<땋> 딟([In] List<땽> obj0)
    {
      List<땋> 땋List = new List<땋>();
      for (int index = 0; index < obj0.Count - 1; ++index)
        땋List.Add(new 땋(obj0[index], obj0[index + 1]));
      땋List.Add(new 땋(obj0[0], obj0[obj0.Count - 1]));
      return this.딟(땋List);
    }

    private List<땋> 딟([In] List<땋> obj0)
    {
      List<땋> 땋List = new List<땋>();
      foreach (땋 땋 in obj0)
      {
        땽 땽1 = this.딟(땋.딟);
        땽 땽2 = this.딟(땋.땄);
        if ((double) 땽1.딟 > (double) 땽2.딟)
          땋List.Add(new 땋(땽2, 땽1));
        else if ((double) 땽1.딟 < (double) 땽2.딟)
          땋List.Add(new 땋(땽1, 땽2));
      }
      땢.딟<땋>((IList<땋>) 땋List);
      return 땋List;
    }

    private static void 딟<딟>([In] IList<딟> obj0)
    {
      Random random = new Random();
      int count = obj0.Count;
      while (count > 1)
      {
        --count;
        int index = random.Next(count + 1);
        딟 딟 = obj0[index];
        obj0[index] = obj0[count];
        obj0[count] = 딟;
      }
    }

    private 땽 딟([In] 땽 obj0) => new 땽(obj0.딟 + this.딟 * obj0.땄, obj0.땄);
  }
}
