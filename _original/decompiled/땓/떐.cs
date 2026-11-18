// Decompiled with JetBrains decompiler
// Type: 땓.떐
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땓
{
  public class 떐
  {
    public 떐([In] NewsDataJson obj0)
    {
      int length = obj0.Items != null ? obj0.Items.Length : 0;
      // ISSUE: reference to a compiler-generated method
      this.딟(new 땵[length]);
      for (int index = 0; index < length; ++index)
        this.딟()[index] = new 땵(obj0.Items[index]);
    }

    [CompilerGenerated]
    [SpecialName]
    public 땵[] 딟() => this.딟;
  }
}
