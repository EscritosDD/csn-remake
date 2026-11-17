// Decompiled with JetBrains decompiler
// Type: CameraSettingsOverride
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Scripts/Camera/Camera Settings")]
public class CameraSettingsOverride : MonoBehaviour
{
  public Color CameraClearColor;
  public Color AmbientLight;
  public bool Fog;
  public Color FogColor;
  public float FogDensity;
  public float FogEndDistance;
  public float FogStartDistance;
  public FogMode FogMode;

  public void Init(Camera GameCamera, Camera CutsceneCamera)
  {
    if (Object.op_Inequality((Object) GameCamera, (Object) null))
      GameCamera.backgroundColor = this.CameraClearColor;
    if (Object.op_Inequality((Object) CutsceneCamera, (Object) null))
    {
      CutsceneCamera.backgroundColor = this.CameraClearColor;
      ((Behaviour) CutsceneCamera).enabled = false;
    }
    RenderSettings.ambientLight = this.AmbientLight;
    RenderSettings.fog = this.Fog;
    RenderSettings.fogColor = this.FogColor;
    RenderSettings.fogDensity = this.FogDensity;
    RenderSettings.fogEndDistance = this.FogEndDistance;
    RenderSettings.fogStartDistance = this.FogStartDistance;
    RenderSettings.fogMode = this.FogMode;
  }
}
