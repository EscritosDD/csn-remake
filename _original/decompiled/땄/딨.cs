// Decompiled with JetBrains decompiler
// Type: 땄.딨
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace 땄
{
  internal class 딨 : 딯
  {
    public 딨([In] 딟.땇 obj0, [In] 땕 obj1, [In] string obj2, [In] Dictionary<string, string> obj3)
      : base(obj0, obj1)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(obj0.땋());
      stringBuilder.Append("/sessions/turnbased");
      stringBuilder.AppendFormat("?query.type={0}", (object) obj2);
      foreach (KeyValuePair<string, string> keyValuePair in obj3)
        stringBuilder.AppendFormat("&query.params.{0}={1}", (object) keyValuePair.Key, (object) keyValuePair.Value);
      this.딟("GET", stringBuilder.ToString(), 땷.딸.딟);
    }
  }
}
