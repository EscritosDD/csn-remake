// Decompiled with JetBrains decompiler
// Type: 딧.땓
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.JavaScript;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace 딧
{
  public static class 땓
  {
    private static Dictionary<string, 땓.땺> 딟 = new Dictionary<string, 땓.땺>();

    public static void 딟([In] string obj0, [In] string obj1, [In] Action<object> obj2) => 땓.딟(obj0, obj1, obj2, false);

    public static void 딟([In] string obj0, [In] string obj1, [In] Action<object> obj2, [In] bool obj3)
    {
      JavaScriptCallPayload scriptCallPayload = new JavaScriptCallPayload();
      scriptCallPayload.Method = obj0;
      scriptCallPayload.Parameter = obj1;
      if (obj2 != null)
      {
        scriptCallPayload.Id = Guid.NewGuid().ToString();
        Dictionary<string, 땓.땺> 딟 = 땓.딟;
        string id = scriptCallPayload.Id;
        땓.땺 땺1 = new 땓.땺();
        땺1.딟(obj2);
        땺1.딟(obj3);
        땓.땺 땺2 = 땺1;
        딟.Add(id, 땺2);
      }
      Application.ExternalEval(string.Format("CMDSTART{0}CMDEND", (object) 땾.땄((object) scriptCallPayload)));
    }

    public static void 딟([In] string obj0)
    {
      ExternalCallResponse externalCallResponse = 땾.딟<ExternalCallResponse>(Encoding.UTF8.GetString(Convert.FromBase64String(obj0)));
      땓.땺 땺;
      if (!땓.딟.TryGetValue(externalCallResponse.Id, out 땺))
        return;
      if (!땺.땄())
        땓.딟.Remove(externalCallResponse.Id);
      땺.딟()(externalCallResponse.Value);
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    private struct 땺
    {
      [CompilerGenerated]
      [SpecialName]
      public Action<object> 딟() => this.딟;

      [CompilerGenerated]
      [SpecialName]
      public void 딟([In] Action<object> obj0) => this.딟 = obj0;

      [CompilerGenerated]
      [SpecialName]
      public bool 땄() => this.딟;

      [CompilerGenerated]
      [SpecialName]
      public void 딟([In] bool obj0) => this.딟 = obj0;
    }
  }
}
