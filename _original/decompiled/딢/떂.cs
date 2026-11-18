// Decompiled with JetBrains decompiler
// Type: 딢.떂
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 딢
{
  public class 떂 : 땂<땢, 땽, BuildManifestLevelData>
  {
    public string 딟([In] int obj0)
    {
      foreach (땢 땢 in this.딧())
      {
        if (땢.땭() == obj0)
          return 땢.딧();
      }
      return (string) null;
    }
  }
}
