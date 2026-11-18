// Decompiled with JetBrains decompiler
// Type: ChallengePackSelectionScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using 딢;

public class ChallengePackSelectionScreenHandler : BaseMenuHandler
{
  private Camera 딟;
  private 땃[] 딟;
  private PackSelectionScreenHandler[] 딟;
  private new Vector3 딟;
  private int 딟;
  private PackSelectionScreenHandler 딟;
  public Transform PackSpawnPoint;
  public GuiScroller3D PackSelectionScroller;
  public float ButtonSpacing;
  public PackSelectionScreenHandler PackSelectionButtonPrefab;
  public GameObject LeftScrollerButton;
  public GameObject RightScrollerButton;
  public GuiText3D NaClTaxMessage;
  private bool 딟;

  private void Awake()
  {
    base.딟 = ((Component) this).transform.position;
    this.딟 = ((Component) this.PackSpawnPoint).transform.localPosition;
  }

  public void ActivateMenu(땃[] ChallengePackManifests, Camera WorldCamera)
  {
    this.딟 = WorldCamera;
    this.딟 = ChallengePackManifests;
    this.ActivateMenu();
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    ((Component) this.딟).gameObject.SetActive(true);
    this.PackSelectionScroller.set_ActiveElement(0);
    this.PackSelectionScroller.set_ScrollStartCallback(new Action(this.ScrollingStarted));
    this.PackSelectionScroller.set_ScrollEndCallback(new Action(this.ScrollingStopped));
    this.딟 = -1;
    FrontendHub.딟.MoneyDisplay.UpdateDisplay(true, MoneyDisplayHandler.딤.땓);
    ((Component) this.NaClTaxMessage).gameObject.SetActive(true);
    this.Init();
  }

  public override void DeactivateMenu()
  {
    ((Component) this.딟).gameObject.SetActive(false);
    this.ClearScrollerButtons();
    base.DeactivateMenu();
  }

  private void Init()
  {
    this.딟 = new PackSelectionScreenHandler[this.딟.Length];
    for (int Index = 0; Index < this.딟.Length; ++Index)
    {
      this.딟 = Object.Instantiate((Object) this.PackSelectionButtonPrefab) as PackSelectionScreenHandler;
      this.딟.Init(Index, this.딟[Index]);
      ((Component) this.딟).gameObject.transform.parent = ((Component) this.PackSpawnPoint).transform;
      ((Component) this.딟).gameObject.transform.position = Vector3.op_Addition(this.PackSpawnPoint.position, new Vector3((float) Index * this.ButtonSpacing, 0.0f, 0.0f));
      this.딟[Index] = this.딟;
    }
    this.PackSelectionScroller.MinOffset = 0.0f;
    this.PackSelectionScroller.MaxOffset = (float) (this.딟.Length - 1) * this.ButtonSpacing;
    this.PackSelectionScroller.SpringBounds = this.ButtonSpacing * 0.5f;
    this.PackSelectionScroller.NumElements = this.딟.Length;
    this.PackSelectionScroller.UpdateControl();
  }

  private void Update()
  {
    Vector3 딟 = this.딟;
    ref Vector3 local = ref 딟;
    local.x = (__Null) (local.x - (double) this.PackSelectionScroller.get_Offset());
    ((Component) this.PackSpawnPoint).transform.localPosition = 딟;
    if (this.딟 != this.PackSelectionScroller.get_ActiveElement())
    {
      for (int index = 0; index < this.딟.Length; ++index)
        this.딟[index].SetScale(index == this.PackSelectionScroller.get_ActiveElement());
      this.딟 = this.PackSelectionScroller.get_ActiveElement();
    }
    this.UpdateScrollerButtons();
  }

  private void UpdateScrollerButtons()
  {
    if (this.PackSelectionScroller.get_ActiveElement() == 0)
      this.SetGameObjectActive(this.LeftScrollerButton, false);
    else if (!this.딟)
      this.SetGameObjectActive(this.LeftScrollerButton, true);
    if (this.딟 == null)
      return;
    if (this.PackSelectionScroller.get_ActiveElement() == this.딟.Length - 1)
    {
      this.SetGameObjectActive(this.RightScrollerButton, false);
    }
    else
    {
      if (this.딟)
        return;
      this.SetGameObjectActive(this.RightScrollerButton, true);
    }
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (ChallengePackSelectionScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      ChallengePackSelectionScreenHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Back",
          0
        },
        {
          "ScrollLeft",
          1
        },
        {
          "ScrollRight",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!ChallengePackSelectionScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.DeactivateMenu();
        FrontendHub.딟.ChallengeLocationSelectionScreen.ActivateMenu();
        break;
      case 1:
        if (this.PackSelectionScroller.get_ActiveElement() == 0)
          break;
        this.PackSelectionScroller.DecrementScroller();
        break;
      case 2:
        if (this.PackSelectionScroller.get_ActiveElement() == this.딟.Length - 1)
          break;
        this.PackSelectionScroller.IncrementScroller();
        break;
    }
  }

  private void ClearScrollerButtons()
  {
    if (this.딟 == null)
      return;
    foreach (PackSelectionScreenHandler selectionScreenHandler in this.딟)
    {
      if (Object.op_Inequality((Object) selectionScreenHandler, (Object) null))
        Object.Destroy((Object) ((Component) selectionScreenHandler).gameObject);
    }
    this.딟 = (PackSelectionScreenHandler[]) null;
  }

  public void ScrollingStopped()
  {
    this.딟 = false;
    if (this.PackSelectionScroller.get_ActiveElement() != 0)
      this.LeftScrollerButton.SetActive(true);
    if (this.PackSelectionScroller.get_ActiveElement() == this.딟.Length - 1)
      return;
    this.RightScrollerButton.SetActive(true);
  }

  public void ScrollingStarted()
  {
    this.딟 = true;
    this.LeftScrollerButton.SetActive(false);
    this.RightScrollerButton.SetActive(false);
  }
}
