// Decompiled with JetBrains decompiler
// Type: 딧.땽
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  public class 땽
  {
    protected string 딟;
    protected 땥 딟;
    protected 땃 딟;

    public 땽([In] 땃 obj0, [In] 땥 obj1)
    {
      this.딟 = obj1;
      this.딟 = obj0;
    }

    [SpecialName]
    public HttpStatusCode 땄() => this.딟.딟();

    [SpecialName]
    public virtual byte[] 딟() => this.딟.딧();

    [SpecialName]
    public string 딧()
    {
      if (this.딟 == null)
        this.딟 = this.딟() != null ? Encoding.UTF8.GetString(this.딟()) : string.Empty;
      return this.딟;
    }

    [SpecialName]
    public string 딢() => this.딟.땄();

    public string 딟([In] string obj0) => this.딟.딟(obj0);
  }
}
