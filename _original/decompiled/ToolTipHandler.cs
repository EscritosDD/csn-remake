// Decompiled with JetBrains decompiler
// Type: ToolTipHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipHandler : MonoBehaviour
{
  private DateTime 딟;
  private static List<ToolTipHandler> 딟 = new List<ToolTipHandler>();
  protected GameObject 딟;
  private Vector3 딟;
  public GameObject OverlayPrefab;
  public 딢.딮 Type;
  public float DelayTime = 1f;
  public bool AutoDiscard;
  public bool IsInGame;
  public bool OverlayInheritsTooltipPos;
  public bool AllowInTryout = true;

  private void Awake()
  {
    this.딟 = DateTime.Now;
    if (!this.IsInGame)
    {
      this.딟 = Object.Instantiate((Object) this.OverlayPrefab, new Vector3(0.0f, (float) (((Component) this).transform.position.y - 0.100000001490116), 0.0f), Quaternion.identity) as GameObject;
    }
    else
    {
      this.딟 = Object.Instantiate((Object) this.OverlayPrefab) as GameObject;
      GameObject gameObject = GameObject.Find("UICamera");
      this.딟.transform.parent = gameObject.transform;
      this.딟.transform.localPosition = new Vector3(0.0f, 0.0f, 1f);
      ((Component) this).gameObject.transform.parent = gameObject.transform;
      ((Component) this).gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.9f);
    }
  }

  protected virtual void Initialize()
  {
    if (!this.OverlayInheritsTooltipPos)
      return;
    this.딟.transform.position = new Vector3((float) ((Component) this).transform.position.x, (float) (((Component) this).transform.position.y - 0.100000001490116), (float) ((Component) this).transform.position.z);
  }

  private void Update()
  {
    if (!Input.GetKeyDown((KeyCode) 13))
      return;
    ((Component) this).SendMessageUpwards("OnButtonPressed", (object) "Close");
  }

  protected virtual void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (ToolTipHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      ToolTipHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Close",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!ToolTipHandler.딟.TryGetValue(key, out num) || num != 0 || (DateTime.Now - this.딟).TotalSeconds < (double) this.DelayTime)
      return;
    if (this.AutoDiscard)
      this.Discard();
    if (ToolTipHandler.딟.Count > 0)
    {
      ToolTipHandler toolTipHandler = ToolTipHandler.딟[0];
      ToolTipHandler.딟.RemoveAt(0);
      toolTipHandler.Display(true, (Transform) null);
    }
    this.OnClose();
  }

  public void Discard() => GlobalAppData.땽().딟(this.Type);

  protected virtual void OnClose()
  {
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  public void Display() => this.Display(false, (Transform) null);

  public void Display(bool Force, Transform parent)
  {
    if (!Force)
    {
      if (GlobalAppData.땽().땄(this.Type) || 딶.딡.땴() != null && !this.AllowInTryout && 딶.딡.땴().땼().떔() is 딶.딴)
        return;
      if (Object.FindObjectsOfType(typeof (ToolTipHandler)).Length > 0)
      {
        if (ToolTipHandler.딟.Contains(this))
          return;
        ToolTipHandler.딟.Add(this);
        return;
      }
    }
    ToolTipHandler toolTipHandler = Object.Instantiate((Object) this) as ToolTipHandler;
    if (Object.op_Inequality((Object) parent, (Object) null))
    {
      ((Component) toolTipHandler).transform.parent = parent;
      ((Component) toolTipHandler).transform.localPosition = new Vector3((float) ((Component) this).transform.localPosition.x, (float) ((Component) this).transform.localPosition.y, (float) ((Component) this).transform.localPosition.z);
    }
    toolTipHandler.CopyState(this);
    toolTipHandler.Initialize();
  }

  protected virtual void CopyState(ToolTipHandler Original)
  {
  }
}
