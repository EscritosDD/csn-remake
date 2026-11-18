// Decompiled with JetBrains decompiler
// Type: WorldLabel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;

public class WorldLabel : MonoBehaviour
{
  private bool 딟;
  private int 딟;
  private DateTime 딟;
  public Camera WorldCamera;
  public Transform WorldTransform;
  public Camera UICamera;
  public string CollisionMask;
  public int VisibilityUpdateIntervalMS;
  public string LocationID;
  public bool TutorialLabel;

  private void Start()
  {
    if (!string.IsNullOrEmpty(this.CollisionMask))
      this.딟 = 1 << LayerMask.NameToLayer(this.CollisionMask);
    else
      this.딟 = -1;
  }

  private void Update()
  {
    Vector3 worldPoint = this.UICamera.ScreenToWorldPoint(this.WorldCamera.WorldToScreenPoint(this.WorldTransform.position));
    worldPoint.y = (__Null) 1.0;
    ((Component) this).transform.position = worldPoint;
    if (this.VisibilityUpdateIntervalMS == 0 || !(DateTime.Now > this.딟))
      return;
    this.UpdateVisibility();
    this.딟 = DateTime.Now.AddMilliseconds((double) this.VisibilityUpdateIntervalMS);
  }

  private void OnButtonPressed(string Command)
  {
    if (this.TutorialLabel)
      ((Component) this).SendMessageUpwards("OpenTutorialConfirmation");
    else
      ((Component) this).SendMessageUpwards("OnLocationSelected", (object) this.LocationID);
  }

  private void UpdateVisibility()
  {
    Vector3 position = ((Component) this.WorldCamera).transform.position;
    Vector3 vector3_1 = Vector3.op_Subtraction(this.WorldTransform.position, position);
    float magnitude = ((Vector3) ref vector3_1).magnitude;
    Vector3 vector3_2 = Vector3.op_Multiply(vector3_1, 1f / magnitude);
    bool flag = Physics.Raycast(position, vector3_2, magnitude, this.딟);
    if (flag == this.딟)
      return;
    this.딟 = flag;
    this.SetChildrenVisible(!flag);
  }

  private void SetChildrenVisible(bool State)
  {
    int childCount = ((Component) this).transform.childCount;
    for (int index = 0; index < childCount; ++index)
      ((Component) ((Component) this).transform.GetChild(index)).gameObject.SetActive(State);
  }
}
