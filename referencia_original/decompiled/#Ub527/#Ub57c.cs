// Decompiled with JetBrains decompiler
// Type: 딧.땼
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 딧
{
  public struct 땼
  {
    private string 딟;

    private 땼([In] string obj0) => this.딟 = obj0;

    public static 땼 딟([In] string obj0) => new 땼(obj0);

    public string 땄([In] string obj0) => string.Format("{0}{1}", (object) this.딟, (object) obj0);

    public string 딟([In] string obj0, [In] 땢 obj1) => string.Format("{0}{1}?{2}", (object) this.딟, (object) obj0, (object) obj1.땄());
  }
}
