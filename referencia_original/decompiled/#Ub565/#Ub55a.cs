// Decompiled with JetBrains decompiler
// Type: 땥.땚
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.IO;
using System.Runtime.InteropServices;

namespace 땥
{
  public static class 땚
  {
    public static void 딟([In] 땱 obj0, [In] string obj1)
    {
      using (FileStream fileStream = new FileStream(obj1, FileMode.Create))
        new 딮().딟(obj0, (Stream) fileStream);
    }

    public static void 땄([In] 땱 obj0, [In] string obj1)
    {
      using (FileStream fileStream = new FileStream(obj1, FileMode.Open))
        new 딯().딟(obj0, (Stream) fileStream);
    }

    public static 땱 딟([In] string obj0)
    {
      using (FileStream fileStream = new FileStream(obj0, FileMode.Open))
        return new 딯().딟((Stream) fileStream);
    }
  }
}
