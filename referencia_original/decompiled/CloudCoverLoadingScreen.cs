// Decompiled with JetBrains decompiler
// Type: CloudCoverLoadingScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;
using 딢;

public class CloudCoverLoadingScreen : MonoBehaviour
{
  private bool 딟;
  private CloudCoverSet 딟;
  private Action 딟;
  private 땿 딟 = new 땿();
  public CloudCoverSet CloudPrefab;
  public bool SetCloudCoverTransform;

  private void Awake()
  {
    if (this.SetCloudCoverTransform)
      this.딟 = Object.Instantiate((Object) this.CloudPrefab, ((Component) this).transform.position, Quaternion.identity) as CloudCoverSet;
    else
      this.딟 = Object.Instantiate((Object) this.CloudPrefab) as CloudCoverSet;
  }

  public float Open() => this.딟.Open();

  public void Close(Action OnClosedCallback)
  {
    this.딟.딟(this.딟.Close());
    this.딟 = true;
    this.딟 = OnClosedCallback;
  }

  private void Update()
  {
    if (!this.딟)
      return;
    this.딟.딟();
    if (!this.딟.땄())
      return;
    if (this.딟 != null)
      this.딟();
    Object.Destroy((Object) ((Component) this.딟).gameObject);
    this.딟 = (CloudCoverSet) null;
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void OnDestroy() => this.CloudPrefab = (CloudCoverSet) null;
}
