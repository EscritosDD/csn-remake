// Decompiled with JetBrains decompiler
// Type: 딧.딤
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Notifications;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딧
{
  public static class 딤
  {
    public static 땰 딟() => (땰) new 딤.딭();

    public class 딭 : 땰
    {
      public void 딟([In] MonoBehaviour obj0, [In] Action<string> obj1) => 땓.딟("unity_request_push_channel", string.Empty, (Action<object>) (r => this.딟(r, obj1)));

      private void 딟([In] object obj0, [In] Action<string> obj1)
      {
        NaClPushChannelData clPushChannelData = 땾.딟<NaClPushChannelData>(obj0);
        obj1(clPushChannelData.ChannelId);
      }
    }

    public class 땣 : 땰
    {
      public void 딟([In] MonoBehaviour obj0, [In] Action<string> obj1) => obj1((string) null);
    }
  }
}
