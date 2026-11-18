// Decompiled with JetBrains decompiler
// Type: 딟.딨
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 딟
{
  public class 딨
  {
    private string 딟;

    public 딨([In] 딧.땥 obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.딧());
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.딟());
    }

    [SpecialName]
    public bool 딟() => this.딢() >= HttpStatusCode.OK && this.딢() < HttpStatusCode.MultipleChoices;

    [SpecialName]
    public string 땄()
    {
      if (this.딟 == null)
        this.딟 = Encoding.UTF8.GetString(this.딧());
      return this.딟;
    }

    [CompilerGenerated]
    [SpecialName]
    public byte[] 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public HttpStatusCode 딢() => this.딟;
  }
}
