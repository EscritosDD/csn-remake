// Decompiled with JetBrains decompiler
// Type: CloudCoverSet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class CloudCoverSet : MonoBehaviour
{
  public Animation[] Clouds;

  public float Close()
  {
    float num = 0.0f;
    foreach (Animation cloud in this.Clouds)
    {
      float length = cloud.clip.length;
      string name = ((Object) cloud.clip).name;
      cloud[name].speed = 1f;
      cloud[name].time = 0.0f;
      num = Mathf.Max(new float[1]{ length });
      cloud.wrapMode = (WrapMode) 1;
      cloud.Play((PlayMode) 4);
    }
    return num;
  }

  public float Open()
  {
    float num = 0.0f;
    foreach (Animation cloud in this.Clouds)
    {
      float length = cloud.clip.length;
      string name = ((Object) cloud.clip).name;
      cloud[name].speed = -1f;
      cloud[name].time = length;
      num = Mathf.Max(new float[1]{ length });
      cloud.wrapMode = (WrapMode) 1;
      cloud.Play((PlayMode) 4);
    }
    return num;
  }

  private void OnDestroy() => this.Clouds = (Animation[]) null;
}
