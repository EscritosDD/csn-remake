// Decompiled with JetBrains decompiler
// Type: HUDCloudHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class HUDCloudHandler : MonoBehaviour
{
  public CloudCoverLoadingScreen cloudCoverPrefab;
  private CloudCoverLoadingScreen 딟;
  private bool 딟;

  public void StartReset()
  {
    this.딟 = true;
    this.StartCoroutine(this.OpenCloudCover());
  }

  [DebuggerHidden]
  private IEnumerator OpenCloudCover() => (IEnumerator) new HUDCloudHandler.\u003COpenCloudCover\u003Ec__Iterator18()
  {
    딟 = this
  };

  private void OnCloudsClosed()
  {
    Object.Destroy((Object) this.딟);
    this.딟 = (CloudCoverLoadingScreen) null;
  }

  public bool CloudsAreOpen() => Object.op_Inequality((Object) this.딟, (Object) null);

  public bool ResetStarted() => this.딟;
}
