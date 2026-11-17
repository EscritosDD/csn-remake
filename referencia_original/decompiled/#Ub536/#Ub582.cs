// Decompiled with JetBrains decompiler
// Type: 딶.떂
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 딶
{
  public class 떂 : 딶.땃
  {
    public 딢.딴 딟;
    public string 딟;

    public 떂([In] 딢.딴 obj0) => this.딟 = obj0;

    public 떂([In] TacticsUserActionEditorBase obj0)
    {
      this.딟 = obj0.Ability;
      this.딟 = obj0.StatId;
    }

    public 땃.땧 딟() => (땃.땧) null;

    public void 딟([In] 땛 obj0) => obj0.딟(this.딟);

    public bool 딟([In] 딶.땃 obj0) => obj0 is 떂 떂 && this.딟 == 떂.딟;
  }
}
