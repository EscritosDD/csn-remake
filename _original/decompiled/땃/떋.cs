// Decompiled with JetBrains decompiler
// Type: 땃.떋
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땃
{
  public class 떋
  {
    public GameTileComponent[] 딟;
    public int[] 딟;

    public 떋([In] int obj0, [In] bool obj1)
    {
      int num = 0;
      int length;
      if (obj1)
      {
        for (int index = 0; index <= obj0; ++index)
          num += index;
        length = num * 4 + 1;
      }
      else
        length = obj0;
      this.딟 = new int[length];
    }
  }
}
