// Decompiled with JetBrains decompiler
// Type: RageCamera
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[ExecuteInEditMode]
[Serializable]
public class RageCamera : MonoBehaviour
{
  [SerializeField]
  private Camera _cameraMain;
  private bool 딟;
  public float DefaultOrthoSize = 100f;
  public float DefaultResolutionHeight;
  public float LastResolutionHeight;
  public float LastOrthoSize;
  public Quaternion LastCameraRotation = Quaternion.identity;
  public bool EditorRealtimeUpdate;
  [SerializeField]
  private float _updateThreshold = 0.2f;
  private static RageCamera.땥 딟;
  private static RageCamera.딝 딟;
  private static RageCamera.떎 딟;

  [SpecialName]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public static void 딟([In] RageCamera.땥 obj0) => RageCamera.딟 += obj0;

  [SpecialName]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public static void 땄([In] RageCamera.땥 obj0) => RageCamera.딟 -= obj0;

  [SpecialName]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public static void 딟([In] RageCamera.딝 obj0) => RageCamera.딟 += obj0;

  [SpecialName]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public static void 땄([In] RageCamera.딝 obj0) => RageCamera.딟 -= obj0;

  [SpecialName]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public static void 딟([In] RageCamera.떎 obj0) => RageCamera.딟 += obj0;

  [SpecialName]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public static void 땄([In] RageCamera.떎 obj0) => RageCamera.딟 -= obj0;

  public void OnEnable()
  {
    if (this.딟)
      return;
    this._cameraMain = Camera.main;
    this._cameraMain.transparencySortMode = (TransparencySortMode) 2;
    this.딟 = true;
  }

  [SpecialName]
  public float get_UpdateThreshold()
  {
    if ((double) this._updateThreshold <= 0.0)
      this._updateThreshold = 0.01f;
    return this._updateThreshold;
  }

  [SpecialName]
  public void set_UpdateThreshold(float value) => this._updateThreshold = (double) value > 0.0 ? value : 0.01f;

  public void Update()
  {
    if (!Application.isPlaying)
      return;
    this.UpdateStep();
  }

  private void UpdateStep() => this.CheckCameraChanges();

  public void Initialize()
  {
    this._cameraMain = Camera.main;
    this.LastResolutionHeight = this.DefaultResolutionHeight = (float) RageCamera.딟().y;
    this.LastOrthoSize = this.DefaultOrthoSize = this._cameraMain.orthographicSize;
    this.LastCameraRotation = ((Component) this._cameraMain).transform.rotation;
  }

  public void CheckCameraChanges()
  {
    if (Object.op_Equality((Object) this._cameraMain, (Object) null))
      return;
    float y = (float) RageCamera.딟().y;
    if ((double) RageCamera.딟(y, this.LastResolutionHeight) > (double) this.get_UpdateThreshold())
    {
      this.LastResolutionHeight = y;
      if (RageCamera.딟 != null)
        RageCamera.딟();
    }
    if (this._cameraMain.isOrthoGraphic)
    {
      float orthographicSize = this._cameraMain.orthographicSize;
      if ((double) RageCamera.딟(orthographicSize, this.LastOrthoSize) > (double) this.get_UpdateThreshold())
      {
        this.LastOrthoSize = orthographicSize;
        if (RageCamera.딟 != null)
          RageCamera.딟();
      }
    }
    if ((double) (Quaternion.Angle(((Component) this._cameraMain).transform.rotation, this.LastCameraRotation) / 100f) <= (double) this.get_UpdateThreshold())
      return;
    this.LastCameraRotation = ((Component) this._cameraMain).transform.rotation;
    if (RageCamera.딟 == null)
      return;
    RageCamera.딟();
  }

  private static float 딟([In] float obj0, [In] float obj1) => Mathf.Abs(obj0 - obj1) / obj0;

  public static Vector2 딟()
  {
    if (!Application.isEditor)
      return new Vector2((float) Screen.width, (float) Screen.height);
    Type type = Type.GetType("UnityEditor.GameView,UnityEditor");
    return (object) type == null ? Vector2.zero : (Vector2) type.GetMethod("GetSizeOfMainGameView", BindingFlags.Static | BindingFlags.NonPublic).Invoke((object) null, (object[]) null);
  }

  public delegate void 땥();

  public delegate void 딝();

  public delegate void 떎();
}
