// Decompiled with JetBrains decompiler
// Type: 딢.땂`3
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 딟;

namespace 딢
{
  public class 땂<딟, 땄, 딧> where 딟 : 땠<땄, 딧>, new()
  {
    private List<딟> 딟;
    private Dictionary<string, 딟> 딟;

    public bool 딟([In] 딧[] obj0, [In] 딟.때 obj1)
    {
      this.딟 = new List<딟>();
      this.딟 = (List<딟>) new Dictionary<string, 딟>();
      for (int index = 0; index < obj0.Length; ++index)
      {
        딟 딟 = new 딟();
        딟.딟(obj0[index], obj1);
        ((Dictionary<string, 딟>) this.딟).Add(딟.딧(), 딟);
        this.딟.Add(딟);
      }
      return true;
    }

    public 딟 딟([In] string obj0)
    {
      if (string.IsNullOrEmpty(obj0))
        return default (딟);
      딟 딟;
      return !((Dictionary<string, 딟>) this.딟).TryGetValue(obj0, out 딟) ? default (딟) : 딟;
    }

    public 땄 땄([In] string obj0)
    {
      딟 딟 = this.딟(obj0);
      return (object) 딟 == null ? default (땄) : 딟.딶();
    }

    public void 딟()
    {
      foreach (딟 딟 in this.딟)
        딟.땃();
      this.딟 = (List<딟>) null;
      this.딟 = (List<딟>) null;
    }

    public List<string> 땄()
    {
      List<string> stringList = new List<string>();
      foreach (딟 딟 in this.딟)
        stringList.Add(딟.딧());
      return stringList;
    }

    [SpecialName]
    public List<딟> 딧() => this.딟;

    public bool 딟([In] 딛 obj0, [In] string obj1)
    {
      딟 딟 = this.딟(obj1);
      return (object) 딟 != null && obj0.딧((딟.땩) 딟);
    }

    public void 딟([In] 딛 obj0)
    {
      foreach (딟 딟 in this.딟)
      {
        if (obj0.딢((딟.땩) 딟))
          obj0.딧((딟.땩) 딟);
      }
    }
  }
}
