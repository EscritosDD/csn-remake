// Decompiled with JetBrains decompiler
// Type: 딶.때
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 딶
{
  internal abstract class 때
  {
    public static bool 딟([In] 딱 obj0)
    {
      switch (obj0)
      {
        case 딱.땄:
        case 딱.딧:
        case 딱.딢:
        case 딱.딶:
        case 딱.땺:
        case 딱.땥:
          return true;
        default:
          return false;
      }
    }

    public static bool 땄([In] 딱 obj0) => !때.딟(obj0) && obj0 != 딱.땃 && obj0 != 딱.땓;
  }
}
