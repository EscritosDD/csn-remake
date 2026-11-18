// Decompiled with JetBrains decompiler
// Type: DelayedLevelLoad
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Scripts/Application/Delayed Level Load")]
public class DelayedLevelLoad : MonoBehaviour
{
  private float 딟;
  private bool 딟;
  public float TimeDelay = 5f;
  public string LevelToLoad;

  private void Start() => this.딟 = Time.time;

  private void Update()
  {
    if (this.딟 || (double) this.딟 + (double) this.TimeDelay >= (double) Time.time)
      return;
    Application.LoadLevelAsync(this.LevelToLoad);
    this.딟 = true;
  }
}
