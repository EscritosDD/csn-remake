// Decompiled with JetBrains decompiler
// Type: 딧.땤
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace 딧
{
  public struct 땤
  {
    public static 땤 딟([In] object obj0)
    {
      string s = 땾.땄(obj0);
      Debug.Log((object) ("Json = " + s));
      땤 땤 = new 땤();
      땤.딟(Encoding.UTF8.GetBytes(s));
      return 땤;
    }

    [CompilerGenerated]
    [SpecialName]
    public byte[] 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] byte[] obj0) => this.딟 = obj0;
  }
}
