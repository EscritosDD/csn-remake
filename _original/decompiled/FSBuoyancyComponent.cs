// Decompiled with JetBrains decompiler
// Type: FSBuoyancyComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using UnityEngine;
using 땥;

public class FSBuoyancyComponent : MonoBehaviour
{
  public Vector2 StartPoint;
  public Vector2 EndPoint;
  protected AABB 딟;
  public float Density = 2f;
  public float LinearDragCoef = 0.987f;
  public float RotationalDragCoef = 0.987f;
  protected 땵 딟;

  private void Start()
  {
    Vector3 position = ((Component) this).transform.position;
    this.딟 = new AABB(new 땥.떁((float) (position.x + this.StartPoint.x), (float) (position.y + this.StartPoint.y)), new 땥.떁((float) (position.x + this.EndPoint.x), (float) (position.y + this.EndPoint.y)));
    this.딟 = new 땵(this.딟, this.Density, this.LinearDragCoef, this.RotationalDragCoef, FSWorldComponent.딟().딟);
    FSWorldComponent.딟().딟((딹) this.딟);
  }

  private void Update()
  {
  }

  private void OnDrawGizmos()
  {
    Vector3 position = ((Component) this).transform.position;
    Vector3 vector3_1 = position;
    Vector3 vector3_2 = position;
    Vector3 vector3_3 = position;
    Vector3 vector3_4 = position;
    Gizmos.color = Color.red;
    ref Vector3 local1 = ref vector3_1;
    local1.x = local1.x + this.StartPoint.x;
    ref Vector3 local2 = ref vector3_1;
    local2.y = local2.y + this.StartPoint.y;
    ref Vector3 local3 = ref vector3_2;
    local3.x = local3.x + this.StartPoint.x;
    ref Vector3 local4 = ref vector3_2;
    local4.y = local4.y + this.EndPoint.y;
    ref Vector3 local5 = ref vector3_3;
    local5.x = local5.x + this.EndPoint.x;
    ref Vector3 local6 = ref vector3_3;
    local6.y = local6.y + this.EndPoint.y;
    ref Vector3 local7 = ref vector3_4;
    local7.x = local7.x + this.EndPoint.x;
    ref Vector3 local8 = ref vector3_4;
    local8.y = local8.y + this.StartPoint.y;
    Gizmos.DrawLine(vector3_1, vector3_2);
    Gizmos.DrawLine(vector3_2, vector3_3);
    Gizmos.DrawLine(vector3_3, vector3_4);
    Gizmos.DrawLine(vector3_4, vector3_1);
  }
}
