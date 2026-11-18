// Decompiled with JetBrains decompiler
// Type: 땥.딶
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  public static class 딶
  {
    public static List<땨> 딟([In] 땨 obj0)
    {
      땺.땧 땧 = new 땺.땧();
      foreach (떁 떁 in (List<떁>) obj0)
        땧.딟().Add(new 땺.땮((double) 떁.딟, (double) 떁.땄));
      땺.땣 땣 = new 땺.땣();
      땣.딟((땺.땫) 땧);
      땺.딤.딟(땣);
      List<땨> 땨List = new List<땨>();
      foreach (땺.딽 딽 in (IEnumerable<땺.딽>) 땧.땄())
      {
        땨 땨 = new 땨();
        foreach (땺.땮 땮 in 딽.딟)
          땨.Add(new 떁((float) 땮.딟, (float) 땮.땄));
        땨List.Add(땨);
      }
      return 땨List;
    }

    public static List<땨> 딟([In] 땇 obj0)
    {
      땺.땧 땧1 = new 땺.땧();
      foreach (떁 떁 in (List<떁>) obj0)
        땧1.딟().Add(new 땺.땮((double) 떁.딟, (double) 떁.땄));
      if (obj0.딟() != null)
      {
        foreach (땨 땨 in obj0.딟())
        {
          땺.땧 땧2 = new 땺.땧();
          foreach (떁 떁 in (List<떁>) 땨)
            땧2.딟().Add(new 땺.땮((double) 떁.딟, (double) 떁.땄));
          땧1.딟(땧2);
        }
      }
      땺.땣 땣 = new 땺.땣();
      땣.딟((땺.땫) 땧1);
      땺.딤.딟(땣);
      List<땨> 땨List = new List<땨>();
      foreach (땺.딽 딽 in (IEnumerable<땺.딽>) 땧1.땄())
      {
        땨 땨 = new 땨();
        foreach (땺.땮 땮 in 딽.딟)
          땨.Add(new 떁((float) 땮.딟, (float) 땮.땄));
        땨List.Add(땨);
      }
      return 땨List;
    }

    public static List<땨> 딟([In] List<땇> obj0)
    {
      List<땨> 땨List = new List<땨>();
      foreach (땇 땇 in obj0)
        땨List.AddRange((IEnumerable<땨>) 딶.딟(땇));
      return 땨List;
    }
  }
}
