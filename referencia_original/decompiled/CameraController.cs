// Decompiled with JetBrains decompiler
// Type: CameraController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("Game/Camera/Controller")]
public class CameraController : MonoBehaviour
{
  public const string 딟 = "UserZoom";
  public const float 딟 = 0.5f;
  public const float 땄 = 0.15f;
  public const float 딧 = 0.15f;
  public const float 딢 = 0.85f;
  public float cameraKeyboardMoveSpeed = 20f;
  public float cinematicMoveSpeed = 20f;
  public float cinematicMoveAcceleration = 50f;
  public float cinematicMoveDeceleration = 100f;
  private bool 딟;
  private Vector3 딟 = Vector3.zero;
  public AnimationCurve followTargetDecelerationCurve;
  public float dragFriction = 30f;
  private float 땃;
  private float 딶;
  private float 땓;
  private Vector3 땄;
  private Vector3 딧;
  private Vector3 딢;
  private Vector3 땃;
  private Ray 딟;
  private Ray 땄;
  private Ray 딧;
  private Ray 딢;
  private Transform 딟;
  private 딢.떔 딟;
  private Plane 딟 = new Plane(Vector3.up, Vector3.zero);
  public Vector2 playableViewportSize = new Vector2(0.7f, 0.7f);
  private 딶.떓 딟;
  private static readonly Vector3 딶 = new Vector3(-100f, -100f, -100f);
  private Vector3 땓 = CameraController.딶;
  private Vector3 땺 = Vector3.zero;
  public AnimationCurve dragDecelerationCurve;
  private float 땺;
  private float 땥 = 1f;
  private float 딝;
  private float 떎;
  public float zoomAcceleration = 40f;
  public float zoomDeceleration = 10f;
  private float 떂 = 1f;
  private float 땭;
  public AnimationCurve zoomCurve;
  private float 딦;
  private float 땤;
  public float zoomSpringTime;
  public AnimationCurve zoomSpringCurve;
  private float 땽 = 1f;
  private float 땋;
  public AnimationCurve springCurve;
  public float borderSpringSpeed = 60f;
  private float 땲 = -1f;
  private float 떏;
  private Vector3 땥;
  private Vector3 딝;
  public AnimationCurve cinematicMoveCurve;
  private bool 땄;
  private bool 딧;
  private bool 딢;
  private Touch 딟;
  private Touch 땄;
  private Vector2 딟;
  private Vector2 땄;
  public float startRotatingThresholdAngle = 10f;
  public float startZoomingThreshold;
  public float stopZoomingStartRotatingThresholdAngle = 30f;
  public float stopRotatingStartZoomingThreshold = 1f;
  private bool 땃;
  private 딢.딸 딟;
  private float 땼;
  private Vector3 떎 = Vector3.zero;
  private Vector3 떂 = Vector3.zero;
  private float 땢;
  private float 딷;
  private float 떁;
  private int 딟;
  private Transform 땄;
  private float 땟;
  private float 땂 = 0.5f;
  public float minPitch = 40f;
  public float maxPitch = 60f;
  public float minDistance = 6f;
  public float maxDistance = 11f;
  public float minFov = 30f;
  public float maxFov = 45f;
  public float turnRate = 5f;
  public float mouseXMax = 5f;
  public float keyboardTurnRateScale = 0.5f;
  public 딶.딡 Game;
  public CameraAnimationWrapper CameraAnimation;

  public void Init()
  {
    this.땼 = 335f;
    Quaternion quaternion = Quaternion.Euler(0.0f, this.땼, 0.0f);
    Vector3 vector3 = Quaternion.op_Multiply(quaternion, new Vector3(0.0f, 0.0f, -this.maxDistance));
    this.딟 = ((Component) this).transform;
    this.딟.position = vector3;
    this.딟.rotation = quaternion;
    this.땃 = this.Game.땓().CameraBorderSpringLength;
    this.딶 = (float) this.Game.땓().SizeX * 0.5f;
    this.땓 = (float) this.Game.땓().SizeY * 0.5f;
    this.땄 = new Vector3(-this.딶 + (float) this.Game.땓().CameraXMinPadding - this.땃, 0.0f, -this.땓 + (float) this.Game.땓().CameraYMinPadding - this.땃);
    this.딧 = new Vector3(this.딶 - (float) this.Game.땓().CameraXMaxPadding + this.땃, 0.0f, this.땓 - (float) this.Game.땓().CameraYMaxPadding + this.땃);
    this.딢 = Vector3.op_Addition(this.땄, new Vector3(this.땃, 0.0f, this.땃));
    this.땃 = Vector3.op_Subtraction(this.딧, new Vector3(this.땃, 0.0f, this.땃));
    this.딟 = new 딢.떔(((Component) this).camera);
    this.UpdateActionViewports();
    this.LoadSettings();
    this.SetZoom(this.땢);
    this.딷 = this.떁;
    if (this.Game.땼().떔() is 딶.딖)
      this.SetMode(딢.딸.딧);
    this.딟 = new 딶.떓("Mouse X", 8);
  }

  private void UpdateActionViewports()
  {
    float num1 = (float) ((1.0 - this.playableViewportSize.x) * 0.5);
    float num2 = (float) ((1.0 - this.playableViewportSize.y) * 0.5);
    Rect rect;
    // ISSUE: explicit constructor call
    ((Rect) ref rect).\u002Ector(num1, num2, (float) this.playableViewportSize.x, (float) this.playableViewportSize.y);
    this.딟.딟(rect);
  }

  private void OnDrawGizmosSelected()
  {
    this.playableViewportSize.x = (__Null) (double) Mathf.Clamp((float) this.playableViewportSize.x, 0.1f, 1f);
    this.playableViewportSize.y = (__Null) (double) Mathf.Clamp((float) this.playableViewportSize.y, 0.1f, 1f);
    float num1 = (float) ((1.0 - this.playableViewportSize.x) * 0.5);
    float num2 = (float) ((1.0 - this.playableViewportSize.y) * 0.5);
    this.UpdateActionViewports();
    Vector3 vector3_1;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_1).\u002Ector(1f - num1, 1f - num2, 0.0f);
    Vector3 vector3_2;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_2).\u002Ector(num1, num2, 0.0f);
    this.딟 = ((Component) this).camera.ViewportPointToRay(vector3_1);
    this.딧 = ((Component) this).camera.ViewportPointToRay(vector3_2);
    ref Vector3 local1 = ref vector3_1;
    local1.x = local1.x - this.playableViewportSize.x;
    this.땄 = ((Component) this).camera.ViewportPointToRay(vector3_1);
    ref Vector3 local2 = ref vector3_2;
    local2.x = local2.x + this.playableViewportSize.x;
    this.딢 = ((Component) this).camera.ViewportPointToRay(vector3_2);
    Vector3 position = this.딟.position;
    float num3;
    ((Plane) ref this.딟).Raycast(this.딟, ref num3);
    Vector3 vector3_3 = Vector3.op_Addition(position, Vector3.op_Multiply(((Ray) ref this.딟).direction, num3));
    ((Plane) ref this.딟).Raycast(this.땄, ref num3);
    Vector3 vector3_4 = Vector3.op_Addition(position, Vector3.op_Multiply(((Ray) ref this.땄).direction, num3));
    ((Plane) ref this.딟).Raycast(this.딧, ref num3);
    Vector3 vector3_5 = Vector3.op_Addition(position, Vector3.op_Multiply(((Ray) ref this.딧).direction, num3));
    ((Plane) ref this.딟).Raycast(this.딢, ref num3);
    Vector3 vector3_6 = Vector3.op_Addition(position, Vector3.op_Multiply(((Ray) ref this.딢).direction, num3));
    Gizmos.color = Color.red;
    Gizmos.DrawLine(vector3_3, vector3_4);
    Gizmos.DrawLine(vector3_4, vector3_5);
    Gizmos.DrawLine(vector3_5, vector3_6);
    Gizmos.DrawLine(vector3_6, vector3_3);
  }

  public void SaveSettings()
  {
    if (float.IsNaN(this.땢))
      this.땢 = 0.5f;
    PlayerPrefs.SetFloat("UserZoom", this.땢);
    PlayerPrefs.Save();
  }

  private void LoadSettings()
  {
    this.땢 = PlayerPrefs.GetFloat("UserZoom", 0.5f);
    if (!float.IsNaN(this.땢))
      return;
    this.땢 = 0.5f;
  }

  public Vector3 ScreenPosToWorldPos(Vector3 ScreenPos)
  {
    Ray ray = ((Component) this).camera.ScreenPointToRay(ScreenPos);
    float num = 0.0f;
    ((Plane) ref this.딟).Raycast(ray, ref num);
    return ((Ray) ref ray).GetPoint(num);
  }

  public Vector3 ViewportPointToWorldPos(Vector3 viewportPoint)
  {
    Ray ray = ((Component) this).camera.ViewportPointToRay(viewportPoint);
    float num = 0.0f;
    ((Plane) ref this.딟).Raycast(ray, ref num);
    return ((Ray) ref ray).GetPoint(num);
  }

  private void UpdateVisibleUnits()
  {
    if (this.Game == null)
      return;
    int num1 = 1 << LayerMask.NameToLayer("CameraCollision");
    딶.땇 땇 = (딶.땇) this.Game.딷();
    if (땇 == null)
      return;
    for (int index = 0; index < 땇.땄(); ++index)
    {
      int num2 = (index + this.딟) % 땇.땄();
      땓.땦 땦 = 땇.딟(num2);
      if (땦.딱())
      {
        this.딟 = num2 + 1;
        Vector3 vector3_1 = 땦.딗();
        vector3_1.y = 땦.땂().y;
        Vector3 vector3_2 = Vector3.op_Subtraction(vector3_1, this.딟.position);
        Ray ray;
        // ISSUE: explicit constructor call
        ((Ray) ref ray).\u002Ector(this.딟.position, ((Vector3) ref vector3_2).normalized);
        if (Physics.Raycast(ray, ((Vector3) ref vector3_2).magnitude, num1))
        {
          땦.땺(true);
          break;
        }
        땦.땺(false);
        break;
      }
    }
  }

  public void MoveToPos(딶.땩 pos, float timeToTarget) => this.MoveToPos(this.Game.땓().GetTileCentre(pos.딟, pos.땄), timeToTarget);

  public void MoveToPos(딶.땩 pos, float timeToTarget, bool clearCinematicsUponReachingTarget) => this.MoveToPos(this.Game.땓().GetTileCentre(pos.딟, pos.땄), timeToTarget, clearCinematicsUponReachingTarget);

  public void MoveToPos(Vector3 worldPos, float timeToTarget) => this.MoveToPos(worldPos, timeToTarget, 딢.땘.딟, false);

  public void MoveToPos(
    Vector3 worldPos,
    float timeToTarget,
    bool clearCinematicsUponReachingTarget)
  {
    this.MoveToPos(worldPos, timeToTarget, 딢.땘.딟, clearCinematicsUponReachingTarget);
  }

  public void MoveToPos(Vector3 worldPos, float timeToTarget, 딢.땘 cameraZoom) => this.MoveToPos(worldPos, timeToTarget, cameraZoom, false);

  public void MoveToPos(
    Vector3 worldPos,
    float timeToTarget,
    딢.땘 cameraZoom,
    bool clearCinematicsUponReachingTarget)
  {
    this.ClearMovement();
    this.SetZoom(this.CameraZoomToFloat(cameraZoom));
    this.땄 = (Transform) null;
    if ((double) timeToTarget < 0.0)
    {
      this.떎 = worldPos;
      this.떂 = this.떎;
      this.딷 = this.떁;
    }
    else
      this.SmoothMoveToPos(worldPos, timeToTarget, clearCinematicsUponReachingTarget);
  }

  public void MoveTowardsPos(Vector3 worldPos, 딢.땘 cameraZoom)
  {
    this.ClearMovement();
    this.SetZoom(this.CameraZoomToFloat(cameraZoom));
    this.딟 = true;
    this.딟 = Vector3.zero;
    this.떂 = worldPos;
    this.SetMode(딢.딸.땄);
  }

  public void MoveTowardsPos(int unitIndex, 딢.땘 cameraZoom)
  {
    땓.땊 땊 = 딶.딡.땴().땼().떂().땺()[unitIndex];
    if (땊.땺() || !땊.땓() || 땊.딢(딢.떍.딢) != -1 && 땊.땄 != 딶.딡.땴().땼().딝())
      return;
    this.MoveTowardsPos(딶.딡.땴().땓().GetTileCentre(땊.땃, 땊.딶), cameraZoom);
  }

  public void MoveToSpawn(딶.땂 Team)
  {
    List<SpawnPointComponent> gameComponents = 딶.딡.땴().땼().땃().GetGameComponents<SpawnPointComponent>();
    for (int index = 0; index != gameComponents.Count; ++index)
    {
      if (gameComponents[index].Team == Team)
      {
        this.MoveToPos(((Component) gameComponents[index]).transform.position, 0.5f, true);
        break;
      }
    }
  }

  private void ClearMovement()
  {
    this.땄 = (Transform) null;
    this.땓 = CameraController.딶;
    this.땋 = 0.0f;
    this.땺 = Vector3.zero;
    this.땥 = 1f;
    this.딟 = false;
    this.딟 = Vector3.zero;
  }

  public float CameraZoomToFloat(딢.땘 cameraZoom)
  {
    switch (cameraZoom)
    {
      case 딢.땘.딟:
        return this.땢;
      case 딢.땘.땄:
        return 0.0f;
      case 딢.땘.딧:
        return 1f;
      default:
        return this.GetZoom();
    }
  }

  public void FollowUnit(int UnitIndex)
  {
    this.ClearMovement();
    GameObject gameObject = 딶.딡.땴().딷().딟(UnitIndex).딣();
    if (!Object.op_Inequality((Object) gameObject, (Object) null))
      return;
    this.땄 = gameObject.transform;
    this.SetMode(딢.딸.땄);
  }

  public void ShakeCamera(float ShakeTime, float ShakeStrength)
  {
    this.땟 = Mathf.Max(this.땟, ShakeTime);
    this.땂 = ShakeStrength;
  }

  public Quaternion GetFlatRotation(float Offset) => Quaternion.Euler(0.0f, this.땼 + Offset, 0.0f);

  private void UpdateDrag(Vector3 worldPos)
  {
    Vector3 vector3_1 = worldPos;
    if (Vector3.op_Equality(this.땓, CameraController.딶))
      this.땓 = vector3_1;
    Vector3 vector3_2 = Vector3.op_Subtraction(this.땓, vector3_1);
    this.떂 = Vector3.op_Addition(this.떎, vector3_2);
    if (this.떂.x > this.딢.x && this.떂.z > this.딢.z && this.떂.x < this.땃.x && this.떂.z < this.땃.z)
    {
      this.땥 = 1f;
    }
    else
    {
      if (this.떂.x < this.땄.x || this.떂.z < this.땄.z || this.떂.x > this.딧.x || this.떂.z > this.딧.z)
        this.떂 = this.떎;
      this.땥 = Mathf.Lerp(1f, 0.0f, Mathf.Max(Mathf.Min(this.땃, Mathf.Abs((float) this.떂.x - Mathf.Clamp((float) this.떂.x, (float) this.딢.x, (float) this.땃.x))), Mathf.Min(this.땃, Mathf.Abs((float) this.떂.z - Mathf.Clamp((float) this.떂.z, (float) this.딢.z, (float) this.땃.z)))) / this.땃);
    }
    this.떎 = Vector3.op_Addition(this.떎, Vector3.op_Multiply(vector3_2, this.땥));
    this.떎.x = (__Null) (double) Mathf.Clamp((float) this.떎.x, (float) this.땄.x, (float) this.딧.x);
    this.떎.z = (__Null) (double) Mathf.Clamp((float) this.떎.z, (float) this.땄.z, (float) this.딧.z);
    this.떂 = this.떎;
    this.땺 = Vector3.op_Division(Vector3.op_Multiply(vector3_2, this.땥), Time.deltaTime);
    if ((double) ((Vector3) ref this.땺).sqrMagnitude > 10000.0)
      this.땺 = Vector3.op_Multiply(((Vector3) ref this.땺).normalized, 100f);
    this.땺 = ((Vector3) ref this.땺).magnitude / this.dragFriction;
    this.땋 = Time.time + this.땺;
    this.ClearBorderSpring();
  }

  private void UpdateRotate()
  {
    if (this.딟 == 딢.딸.딧 || this.딢)
      return;
    float num = 0.0f;
    bool flag = this.Game.딱() && !this.Game.때() && !this.Game.땩();
    if (flag)
      num = this.딟.땄() * this.turnRate * this.mouseXMax;
    else if (Input.GetKey((KeyCode) 101))
    {
      flag = true;
      num = -this.turnRate * this.keyboardTurnRateScale;
    }
    else if (Input.GetKey((KeyCode) 113))
    {
      flag = true;
      num = this.turnRate * this.keyboardTurnRateScale;
    }
    if (flag)
    {
      this.딝 = num;
      this.땼 += this.딝;
      this.떎 = Time.time + 0.5f * Mathf.Clamp01(Mathf.Abs(this.딝) / this.turnRate);
    }
    else
    {
      if ((double) this.떎 < (double) Time.time)
        return;
      this.땼 += this.딝 * this.dragDecelerationCurve.Evaluate((float) (1.0 - (double) (this.떎 - Time.time) / 0.5));
      this.딝 -= this.turnRate * Time.deltaTime;
    }
  }

  private void UpdateZoom()
  {
    switch (this.딟)
    {
      case 딢.딸.딟:
        if (this.땄 || this.딧)
          break;
        float num1 = 1f;
        float num2 = -GlobalAppData.떂();
        if ((double) num2 == 0.0 && this.Game.땩())
        {
          float axis1 = Input.GetAxis("Mouse Y");
          float axis2 = Input.GetAxis("Mouse X");
          if ((double) Mathf.Abs(axis1) > (double) Mathf.Abs(axis2))
          {
            num2 = -axis1;
            num1 = 0.75f;
          }
        }
        this.딢 = (double) num2 != 0.0;
        if ((double) num2 == 0.0)
        {
          if (Input.touchCount < 2)
          {
            if ((double) this.땭 != 0.0)
            {
              float num3 = (this.땭 - Mathf.Sign(this.땭) * this.zoomDeceleration * Time.deltaTime) * this.떂;
              if ((double) Mathf.Sign(num3) != (double) Mathf.Sign(this.땭))
                num3 = 0.0f;
              this.땭 = num3;
              this.딷 += this.땭 * Time.deltaTime;
              this.떁 = this.딷;
              if ((double) this.땭 == 0.0 && ((double) this.딷 < 0.150000005960464 || (double) this.딷 > 0.850000023841858))
              {
                this.딦 = Time.time + this.zoomSpringTime;
                this.땤 = this.딷;
              }
            }
            else
            {
              float num4 = this.딦 - Time.time;
              if ((double) num4 > 0.0)
              {
                this.땽 = (double) this.딷 > 0.150000005960464 ? -1f : 1f;
                float num5 = this.땽 * Mathf.Max(0.15f - this.땤, this.땤 - 0.85f);
                this.딷 = this.땤 + this.zoomSpringCurve.Evaluate(1f - Mathf.Clamp01(num4 / this.zoomSpringTime)) * num5;
                this.떁 = this.딷;
              }
            }
          }
        }
        else if (this.딢)
        {
          float num6 = Mathf.Sign(num2);
          if ((double) num6 != (double) this.땽)
          {
            this.떂 = 1f;
            this.땭 = 0.0f;
          }
          this.땽 = num6;
          this.딦 = 0.0f;
          this.땭 = (this.땭 + this.땽 * this.zoomAcceleration * Time.deltaTime) * this.떂 * num1;
          this.딷 += this.땭 * Time.deltaTime;
        }
        this.떂 = (double) this.딷 >= 0.150000005960464 || (double) this.땽 >= 0.0 ? ((double) this.딷 <= 0.850000023841858 || (double) this.땽 <= 0.0 ? 1f : 1f - Mathf.Clamp01((float) (((double) this.딷 - 0.850000023841858) / 0.150000005960464))) : 1f - Mathf.Clamp01((float) ((0.150000005960464 - (double) this.딷) / 0.150000005960464));
        this.딷 = Mathf.Clamp01(this.딷);
        this.떁 = this.딷;
        if (!this.딢)
          break;
        this.UpdateUserZoom();
        break;
      case 딢.딸.땄:
      case 딢.딸.딧:
      case 딢.딸.딢:
        if ((double) this.딷 == (double) this.떁)
          break;
        this.땽 = Mathf.Sign(this.떁 - this.딷);
        float num7 = (double) this.땺 <= 0.0 ? this.zoomSpringTime : this.땺;
        if ((double) this.딦 <= 0.0)
        {
          this.땤 = this.딷;
          this.딦 = (double) this.땋 <= (double) Time.time ? Time.time + this.zoomSpringTime : this.땋;
        }
        float num8 = this.딦 - Time.time;
        if ((double) num8 > 0.0)
        {
          this.딷 = Mathf.Lerp(this.땤, this.떁, this.zoomSpringCurve.Evaluate(1f - Mathf.Clamp01(num8 / num7)));
          break;
        }
        this.딷 = this.떁;
        this.딦 = 0.0f;
        break;
    }
  }

  private void ClearBorderSpring()
  {
    this.땲 = -1f;
    this.떏 = -1f;
  }

  private void ClearDragMomentum()
  {
    if ((double) this.땋 <= 0.0)
      return;
    this.땺 = Vector3.zero;
    this.땺 = 0.0f;
    this.땋 = 0.0f;
  }

  private void UpdateDragMomentum()
  {
    this.땥 = (float) (1.0 - (double) Mathf.Max(Mathf.Min(this.땃, Mathf.Abs((float) this.떎.x - Mathf.Clamp((float) this.떎.x, (float) this.딢.x, (float) this.땃.x))), Mathf.Min(this.땃, Mathf.Abs((float) this.떎.z - Mathf.Clamp((float) this.떎.z, (float) this.딢.z, (float) this.땃.z)))) / (double) this.땃);
    if (Mathf.Approximately(this.땥, 0.0f))
      this.ClearDragMomentum();
    if ((double) this.땋 > 0.0)
    {
      float num = this.땋 - Time.time;
      if ((double) num <= 0.0)
      {
        this.ClearDragMomentum();
      }
      else
      {
        CameraController cameraController = this;
        cameraController.떎 = Vector3.op_Addition(cameraController.떎, Vector3.op_Multiply(Vector3.op_Multiply(this.땺, this.dragDecelerationCurve.Evaluate((float) (1.0 - (double) num / (double) this.땺))), Time.deltaTime));
        Vector3 vector3 = Vector3.op_Subtraction(Vector3.op_Multiply(this.땺, this.땥), Vector3.op_Multiply(Vector3.op_Multiply(Vector3.op_Multiply(((Vector3) ref this.땺).normalized, this.dragFriction), this.땥), Time.deltaTime));
        if ((double) Vector3.Dot(this.땺, vector3) < 0.0)
          this.ClearDragMomentum();
        else
          this.땺 = vector3;
      }
    }
    if ((double) this.땋 == 0.0)
    {
      if ((double) this.땲 < 0.0 && (this.떎.x < this.딢.x || this.떎.x > this.땃.x || this.떎.z < this.딢.z || this.떎.z > this.땃.z))
      {
        this.딝 = Vector3.zero;
        this.땥 = this.떎;
        if (this.떎.x < this.딢.x)
          this.딝.x = this.딢.x - this.떎.x;
        else if (this.떎.x > this.땃.x)
          this.딝.x = this.땃.x - this.떎.x;
        if (this.떎.z < this.딢.z)
          this.딝.z = this.딢.z - this.떎.z;
        else if (this.떎.z > this.땃.z)
          this.딝.z = this.땃.z - this.떎.z;
        this.땲 = ((Vector3) ref this.딝).magnitude / this.borderSpringSpeed;
        this.떏 = Time.time + this.땲;
      }
      if ((double) this.떏 >= (double) Time.time)
      {
        this.떎 = Vector3.op_Addition(this.땥, Vector3.op_Multiply(this.springCurve.Evaluate(Mathf.Clamp01((float) (1.0 - ((double) this.떏 - (double) Time.time) / (double) this.땲))), this.딝));
      }
      else
      {
        this.ClearBorderSpring();
        this.떎.x = (__Null) (double) Mathf.Clamp((float) this.떎.x, (float) this.딢.x, (float) this.땃.x);
        this.떎.z = (__Null) (double) Mathf.Clamp((float) this.떎.z, (float) this.딢.z, (float) this.땃.z);
      }
    }
    else
    {
      this.떎.x = (__Null) (double) Mathf.Clamp((float) this.떎.x, (float) this.땄.x, (float) this.딧.x);
      this.떎.z = (__Null) (double) Mathf.Clamp((float) this.떎.z, (float) this.땄.z, (float) this.딧.z);
    }
    this.떂 = this.떎;
  }

  private void SmoothMoveToPos(
    Vector3 worldPos,
    float timeToTarget,
    bool clearCinematicsUponReachingTarget)
  {
    this.SetMode(딢.딸.땄);
    this.떂 = worldPos;
    this.땓 = this.떎;
    this.땺 = Vector3.op_Subtraction(this.떂, this.떎);
    this.땺 = (double) timeToTarget > 0.0 ? timeToTarget : Mathf.Abs(((Vector3) ref this.땺).sqrMagnitude / (this.cinematicMoveSpeed * this.cinematicMoveSpeed));
    this.땋 = Time.time + this.땺;
    this.땃 = clearCinematicsUponReachingTarget;
  }

  private void UpdateSmoothMove()
  {
    float num = this.땋 - Time.time;
    if ((double) num <= 0.0)
      this.ClearSmoothMove();
    else
      this.떎 = Vector3.op_Addition(this.땓, Vector3.op_Multiply(this.땺, this.cinematicMoveCurve.Evaluate((float) (1.0 - (double) num / (double) this.땺))));
  }

  private void ClearSmoothMove()
  {
    this.떎 = this.떂;
    this.땺 = -1f;
    this.땋 = 0.0f;
    if (!this.땃)
      return;
    this.ClearCinematics();
  }

  private void UpdateTouches()
  {
    if (this.딟 == 딢.딸.딧)
    {
      this.땄 = this.딧 = this.딢 = false;
    }
    else
    {
      switch (Input.touchCount)
      {
        case 0:
          this.땄 = false;
          this.딧 = false;
          this.딢 = false;
          break;
        case 1:
          this.딧 = false;
          this.딢 = false;
          if (((Touch) ref Input.touches[0]).fingerId != 0)
            break;
          this.딟 = Input.touches[0];
          if (((Touch) ref this.딟).phase != null)
            break;
          this.딟 = ((Touch) ref this.딟).position;
          break;
        default:
          this.땄 = false;
          this.딟 = Input.touches[0];
          this.땄 = Input.touches[1];
          if (((Touch) ref this.딟).phase == null || ((Touch) ref this.딟).phase == 2)
            this.딟 = ((Touch) ref this.딟).position;
          if (((Touch) ref this.땄).phase == null || ((Touch) ref this.땄).phase == 2)
            this.땄 = ((Touch) ref this.땄).position;
          Vector2 vector2_1 = Vector2.op_Subtraction(this.땄, this.딟);
          Vector2 vector2_2 = Vector2.op_Subtraction(((Touch) ref this.땄).position, ((Touch) ref this.딟).position);
          float num1 = Vector2.Angle(vector2_1, vector2_2);
          float num2 = Mathf.Lerp(this.startZoomingThreshold, this.stopRotatingStartZoomingThreshold, Mathf.Clamp01(num1 / this.stopZoomingStartRotatingThresholdAngle));
          if (this.딧)
          {
            Vector2 vector2_3 = Vector2.op_Subtraction(vector2_2, vector2_1);
            if ((double) ((Vector2) ref vector2_3).magnitude > (double) num2 * (double) Screen.width)
            {
              this.딧 = false;
              this.딢 = true;
            }
            else
              this.딢 = false;
          }
          else
          {
            float num3 = !this.딢 ? this.startRotatingThresholdAngle : this.stopZoomingStartRotatingThresholdAngle;
            if ((double) num1 > (double) num3)
            {
              this.딧 = true;
              this.딢 = false;
            }
            else
            {
              Vector2 vector2_4 = Vector2.op_Subtraction(vector2_2, vector2_1);
              if ((double) ((Vector2) ref vector2_4).magnitude > (double) num2 * (double) Screen.width)
                this.딢 = true;
            }
          }
          if (!this.딧)
            break;
          this.ResetZoom();
          break;
      }
    }
  }

  private void ResetZoom()
  {
    this.SetZoom(this.땢);
    this.딷 = this.떁;
    this.땭 = 0.0f;
    this.딦 = 0.0f;
  }

  private void LateUpdate()
  {
    if (((Component) this).animation.isPlaying || this.Game.딗() || Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟.딟();
    this.UpdateTouches();
    this.UpdateTranslation();
    this.UpdateRotate();
    this.UpdateZoom();
    if (this.get_clearCinematics() && Vector3.op_Equality(this.떂, this.떎) && (double) this.떁 == (double) this.딷)
      this.ForceClearCinematics(false);
    float num1 = Mathf.Lerp(this.minPitch, this.maxPitch, this.딷);
    float num2 = Mathf.Lerp(this.minDistance, this.maxDistance, this.딷);
    float num3 = Mathf.Lerp(this.minFov, this.maxFov, this.딷);
    Quaternion quaternion = Quaternion.Euler(num1, this.땼, 0.0f);
    Vector3 vector3 = Vector3.op_Addition(Quaternion.op_Multiply(quaternion, new Vector3(0.0f, 0.0f, -num2)), this.떎);
    if ((double) this.땟 > 0.0)
    {
      this.땟 -= Time.deltaTime;
      vector3 = Vector3.op_Addition(vector3, Vector3.op_Multiply(Random.insideUnitSphere, this.땂));
    }
    this.딟.position = vector3;
    this.딟.rotation = quaternion;
    ((Component) this).camera.fieldOfView = num3;
    this.UpdateVisibleUnits();
  }

  private bool UpdateKeys()
  {
    if (this.딟 == 딢.딸.딟)
    {
      float axis1 = Input.GetAxis("Horizontal");
      float axis2 = Input.GetAxis("Vertical");
      if ((double) axis1 != 0.0 || (double) axis2 != 0.0)
      {
        Vector3 vector3 = Quaternion.op_Multiply(Quaternion.Euler(0.0f, this.땼, 0.0f), Vector3.op_Multiply(new Vector3(axis1, 0.0f, axis2), this.cameraKeyboardMoveSpeed * Time.deltaTime));
        this.떂 = Vector3.op_Addition(this.떎, vector3);
        this.땥 = this.떂.x <= this.딢.x || this.떂.z <= this.딢.z || this.떂.x >= this.땃.x || this.떂.z >= this.땃.z ? Mathf.Lerp(1f, 0.0f, Mathf.Max(Mathf.Min(this.땃, Mathf.Abs((float) this.떎.x - Mathf.Clamp((float) this.떎.x, (float) this.딢.x, (float) this.땃.x))), Mathf.Min(this.땃, Mathf.Abs((float) this.떎.z - Mathf.Clamp((float) this.떎.z, (float) this.딢.z, (float) this.땃.z)))) / this.땃) : 1f;
        this.떎 = Vector3.op_Addition(this.떎, Vector3.op_Multiply(vector3, this.땥));
        this.떂 = this.떎;
        this.땄 = true;
        return true;
      }
    }
    return false;
  }

  private void UpdateTranslation()
  {
    switch (this.딟)
    {
      case 딢.딸.딟:
        Vector3 zero = Vector3.zero;
        if (this.UpdateKeys())
          break;
        bool flag1 = this.Game.때() && !this.Game.땩();
        bool flag2 = !flag1;
        Vector3 mousePosition = Input.mousePosition;
        if (flag1)
        {
          this.UpdateDrag(this.ScreenPosToWorldPos(mousePosition));
          break;
        }
        if (!flag2)
          break;
        this.땓 = CameraController.딶;
        this.UpdateDragMomentum();
        break;
      case 딢.딸.땄:
      case 딢.딸.딧:
        if (this.get_clearCinematics() && (Input.GetMouseButton(0) || Input.touchCount >= 1))
        {
          this.ForceClearCinematics(false);
          break;
        }
        if (Object.op_Equality((Object) this.땄, (Object) null))
        {
          if (this.딟)
          {
            if (!this.MoveTowards(this.떂))
              break;
            this.ClearCinematics();
            break;
          }
          if (Vector3.op_Inequality(this.떂, this.떎))
          {
            this.UpdateSmoothMove();
            break;
          }
          this.ClearSmoothMove();
          break;
        }
        this.FollowTransform(this.땄);
        break;
    }
  }

  private void FollowTransform(Transform t)
  {
    if (Object.op_Equality((Object) t, (Object) null))
      return;
    Vector3 떎 = this.떎;
    this.떂 = t.position;
    Vector3 vector3_1 = Vector3.op_Subtraction(this.떂, 떎);
    Vector3 vector3_2 = (double) ((Vector3) ref vector3_1).sqrMagnitude >= 25.0 ? Vector3.op_Multiply(((Vector3) ref vector3_1).normalized, this.cinematicMoveSpeed) : Vector3.op_Multiply(((Vector3) ref vector3_1).normalized, (float) (0.5 + (double) this.cinematicMoveSpeed * (double) this.followTargetDecelerationCurve.Evaluate((float) (1.0 - (double) ((Vector3) ref vector3_1).sqrMagnitude / 25.0))));
    CameraController cameraController = this;
    cameraController.떎 = Vector3.op_Addition(cameraController.떎, Vector3.op_Multiply(vector3_2, Time.deltaTime));
    if ((double) Vector3.Dot(Vector3.op_Subtraction(this.떂, this.떎), vector3_1) >= 0.0)
      return;
    this.떎 = this.떂;
  }

  private bool MoveTowards(Vector3 pos)
  {
    Vector3 떎 = this.떎;
    this.떂 = pos;
    Vector3 vector3 = Vector3.op_Subtraction(this.떂, 떎);
    vector3.y = (__Null) 0.0;
    bool flag = (double) ((Vector3) ref this.딟).sqrMagnitude > 1.0 / 1000.0;
    Vector3 딟 = this.딟;
    this.UpdateActionViewports();
    if (this.딟.땄(pos))
    {
      CameraController cameraController = this;
      cameraController.딟 = Vector3.op_Subtraction(cameraController.딟, Vector3.op_Multiply(Vector3.op_Multiply(((Vector3) ref vector3).normalized, this.cinematicMoveDeceleration), Time.deltaTime));
      if (!flag || flag && (double) Vector3.Dot(딟, this.딟) <= 0.0)
        this.딟 = Vector3.zero;
      else if ((double) ((Vector3) ref this.딟).sqrMagnitude < 0.25)
        this.딟 = Vector3.op_Multiply(((Vector3) ref this.딟).normalized, 0.5f);
    }
    else
    {
      CameraController cameraController = this;
      cameraController.딟 = Vector3.op_Addition(cameraController.딟, Vector3.op_Multiply(Vector3.op_Multiply(((Vector3) ref vector3).normalized, this.cinematicMoveAcceleration), Time.deltaTime));
      if ((double) ((Vector3) ref this.딟).sqrMagnitude > (double) this.cinematicMoveSpeed * (double) this.cinematicMoveSpeed)
        this.딟 = Vector3.op_Multiply(((Vector3) ref this.딟).normalized, this.cinematicMoveSpeed);
    }
    CameraController cameraController1 = this;
    cameraController1.떎 = Vector3.op_Addition(cameraController1.떎, Vector3.op_Multiply(this.딟, Time.deltaTime));
    if ((!flag || (double) Vector3.Dot(딟, this.딟) > 0.0) && (double) ((Vector3) ref this.딟).sqrMagnitude >= 1.0 / 1000.0)
      return false;
    this.떂 = this.떎;
    this.딟 = Vector3.zero;
    return true;
  }

  private Vector3 GetCameraPositionFromTarget(Vector3 point) => Vector3.op_Addition(Quaternion.op_Multiply(this.딟.rotation, new Vector3(0.0f, 0.0f, -Mathf.Lerp(this.minDistance, this.maxDistance, this.딷))), point);

  public Vector3 CalculateFocusOnTargets(
    List<int> unitIds,
    bool focusOnFirst,
    out int numTargetsInView,
    out 딢.땘 cameraZoom,
    out bool canFitWithoutMoving)
  {
    List<Transform> targets = new List<Transform>();
    if (딶.딡.땴() != null && 딶.딡.땴().딷() != null)
    {
      for (int index = 0; index != unitIds.Count; ++index)
      {
        GameObject gameObject = 딶.딡.땴().딷().딟(unitIds[index]).딣();
        if (Object.op_Inequality((Object) gameObject, (Object) null))
          targets.Add(gameObject.transform);
      }
    }
    return this.CalculateFocusOnTargets(targets, focusOnFirst, out numTargetsInView, out cameraZoom, out canFitWithoutMoving);
  }

  public Vector3 CalculateFocusOnTargets(
    List<Transform> targets,
    bool focusOnFirst,
    out int numTargetsInView,
    out 딢.땘 cameraZoom,
    out bool canFitWithoutMoving)
  {
    if (Object.op_Equality((Object) this.딟, (Object) null))
    {
      numTargetsInView = 0;
      canFitWithoutMoving = false;
      cameraZoom = 딢.땘.딟;
      return Vector3.zero;
    }
    this.UpdateActionViewports();
    Vector3 point1 = Vector3.zero;
    int num1 = 0;
    딢.떔 딟 = this.딟;
    딟.딟(this.GetCameraPositionFromTarget(point1));
    Vector3 position = this.딟.position;
    canFitWithoutMoving = true;
    for (int index1 = 0; index1 != targets.Count; ++index1)
    {
      if (!Object.op_Equality((Object) targets[index1], (Object) null))
      {
        Vector3 vector3 = targets[index1].position;
        int num2 = 1;
        for (int index2 = 0; index2 != targets.Count; ++index2)
        {
          if (index1 != index2 && !Object.op_Equality((Object) targets[index2], (Object) null))
          {
            Vector3 point2 = Vector3.op_Addition(Vector3.op_Multiply(Vector3.op_Subtraction(targets[index2].position, vector3), 0.5f), vector3);
            딟.딟(this.GetCameraPositionFromTarget(point2));
            if (딟.땄(vector3) && (!focusOnFirst || 딟.땄(targets[0].position)))
            {
              vector3 = point2;
              ++num2;
            }
          }
        }
        if (num2 > num1)
        {
          num1 = num2;
          point1 = vector3;
        }
        this.딟.딟(position);
        if (!this.딟.땄(targets[index1].position))
          canFitWithoutMoving = false;
        if (focusOnFirst)
        {
          for (int index3 = 1; index3 < targets.Count; ++index3)
          {
            if (Object.op_Inequality((Object) targets[index3], (Object) null) && !this.딟.땄(targets[index3].position))
            {
              canFitWithoutMoving = false;
              break;
            }
          }
          break;
        }
      }
    }
    numTargetsInView = num1;
    cameraZoom = 딢.땘.딟;
    return point1;
  }

  public bool IsInActionFrustum(Vector3 position)
  {
    this.UpdateActionViewports();
    return this.딟.땄(position);
  }

  public bool IsInActionFrustum(int unitIndex)
  {
    if (딶.딡.땴() == null || 딶.딡.땴().딷() == null)
      return false;
    땓.땊 땊 = 딶.딡.땴().딷().딟(unitIndex).땴();
    return 땊.땓() && this.IsInActionFrustum(딶.딡.땴().땼().땹().GetTileCentre(땊.땃, 땊.딶));
  }

  public bool OnTurnStart(int TeamIndex, out Vector3 cameraTargetPos)
  {
    List<int> unitIds = new List<int>();
    for (int index = 0; index < this.Game.땼().떎().Count; ++index)
    {
      땓.땊 땊 = this.Game.땼().떎()[index];
      if (땊.땓() && !땊.땺() && 땊.땄 == TeamIndex)
        unitIds.Add(index);
    }
    for (int index = 0; index != unitIds.Count; ++index)
    {
      if (Object.op_Equality((Object) 딶.딡.땴().딷().딟(unitIds[index]).딣(), (Object) null))
      {
        unitIds.RemoveAt(index);
        --index;
      }
    }
    if (unitIds.Count > 0)
    {
      cameraTargetPos = this.CalculateFocusOnTargets(unitIds, false, out int _, out 딢.땘 _, out bool _);
      return true;
    }
    cameraTargetPos = Vector3.zero;
    this.MoveToSpawn(TeamIndex != 0 ? 딶.땂.땄 : 딶.땂.딟);
    return false;
  }

  public void OnTurnEnd(int TeamIndex)
  {
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_clearCinematics() => this.딶;

  public void ClearCinematics()
  {
    // ISSUE: reference to a compiler-generated method
    this.set_clearCinematics(true);
    this.SetZoom(this.땢);
  }

  public void ForceClearCinematics(bool goToNewTarget)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_clearCinematics(false);
    this.땃 = false;
    this.ClearMovement();
    if (this.Game.땼().떔() is 딶.딖)
      goToNewTarget = true;
    if (goToNewTarget)
      this.MoveToPos(this.떂, -1f);
    else
      this.떂 = this.떎;
    this.SetMode(딢.딸.딟);
    this.SetZoom(this.땢);
    this.딷 = this.떁;
    this.딦 = 0.0f;
  }

  public float PlayCameraAnim(딢.땷 CameraAnim)
  {
    if (Object.op_Equality((Object) this.CameraAnimation, (Object) null))
      return 0.0f;
    ((Behaviour) ((Component) this).camera).enabled = false;
    ((Behaviour) ((Component) this.CameraAnimation).camera).enabled = true;
    return this.CameraAnimation.PlayCameraAnim(CameraAnim);
  }

  public void StopCameraAnim()
  {
    ((Behaviour) ((Component) this.CameraAnimation).camera).enabled = false;
    ((Behaviour) ((Component) this).camera).enabled = true;
    Quaternion rotation = ((Component) this.CameraAnimation).transform.rotation;
    this.땼 = (float) ((Quaternion) ref rotation).eulerAngles.y;
    this.ForceClearCinematics(true);
  }

  public void SetupFromAnimation()
  {
    Quaternion rotation = ((Component) this.CameraAnimation).transform.rotation;
    this.땼 = (float) ((Quaternion) ref rotation).eulerAngles.y;
    Ray ray = ((Component) this.CameraAnimation).camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
    float num1;
    ((Plane) ref this.딟).Raycast(ray, ref num1);
    this.떎 = this.떂 = Vector3.op_Addition(((Ray) ref ray).origin, Vector3.op_Multiply(((Ray) ref ray).direction, num1));
    float num2 = Mathf.Lerp(this.minPitch, this.maxPitch, this.딷);
    float num3 = Mathf.Lerp(this.minDistance, this.maxDistance, this.딷);
    float num4 = Mathf.Lerp(this.minFov, this.maxFov, this.딷);
    Quaternion quaternion = Quaternion.Euler(num2, this.땼, 0.0f);
    this.딟.position = Vector3.op_Addition(Quaternion.op_Multiply(quaternion, new Vector3(0.0f, 0.0f, -num3)), this.떎);
    this.딟.rotation = quaternion;
    ((Component) this).camera.fieldOfView = num4;
  }

  public void SetMode(딢.딸 newMode)
  {
    if (this.딟 == 딢.딸.딧)
      return;
    this.딟 = newMode;
    if (this.딟 != 딢.딸.땄)
      return;
    // ISSUE: reference to a compiler-generated method
    this.set_clearCinematics(false);
  }

  [SpecialName]
  public Vector3 get_TargetPos() => this.떎;

  [SpecialName]
  public void set_TargetPos(Vector3 value)
  {
    this.떎 = value;
    this.떂 = value;
  }

  public void SetZoom(float z) => this.떁 = (float) (0.699999988079071 * (double) z + 0.150000005960464);

  public float GetZoom() => Mathf.Clamp01((float) (((double) this.딷 - 0.150000005960464) / 0.699999988079071));

  private void UpdateUserZoom() => this.땢 = this.GetZoom();
}
