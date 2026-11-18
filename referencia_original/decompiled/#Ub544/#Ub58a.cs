// Decompiled with JetBrains decompiler
// Type: 땄.떊
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 땄
{
  public class 떊 : 땷
  {
    private 딬 딟;

    public 떊([In] 딟.땇 obj0, [In] 딬 obj1, [In] string obj2)
      : base(obj0)
    {
      this.딟 = obj1;
      byte[] bytes = Encoding.UTF8.GetBytes(string.Format("username={0}&password={1}&password_generated=true", (object) Uri.EscapeDataString(obj1.딟()), (object) Uri.EscapeDataString(obj1.땄())));
      this.딟("POST", obj0.땋() + "/users/register", bytes, (땷.딸) 0);
      this.땄("Authorization", "Bearer " + obj2);
      ((딧.땋) this).딧();
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.Created)
        this.딟.딧(true);
      else if (this.딝().땄() == HttpStatusCode.Conflict)
      {
        switch (((땘) this.딟).딟)
        {
          case 딟.땑.딢:
            this.딟.딧 = true;
            break;
          case 딟.땑.땃:
            this.딟.딟 = true;
            break;
          case 딟.땑.딶:
            this.딟.땄 = true;
            break;
        }
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
