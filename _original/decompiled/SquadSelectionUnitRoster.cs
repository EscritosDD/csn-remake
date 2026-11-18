// Decompiled with JetBrains decompiler
// Type: SquadSelectionUnitRoster
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Gui3D/Components/Squad Selection Roster")]
public class SquadSelectionUnitRoster : MonoBehaviour
{
  private List<땓.떀> 딟;
  private bool 딟;
  private bool 땄;
  private bool 딧;
  private SquadSelectionScreenHandlerNew 딟;
  private string 딟;
  public GuiScroller3D UnitSelectionList;
  public Transform CharacterCardPrefab;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public Transform RosterBase;
  public Shader ButtonNAShader;
  private bool 딢;
  private LoadingScreenOverlayHandler 딟;
  private float 딟 = 0.4f;
  private Vector3 딟;
  private List<Transform> 딟;
  private int 딟;

  public void Start() => this.딟 = ((Component) this.RosterBase).transform.localPosition;

  public void Init(
    List<땓.떀> Characters,
    bool Restart,
    string CommanderId,
    SquadSelectionScreenHandlerNew Handler)
  {
    if (Restart)
      this.Clear();
    this.딟 = Characters;
    this.딧 = Restart;
    this.딟 = Handler;
    if (!string.IsNullOrEmpty(CommanderId))
      this.딟 = CommanderId;
    for (int index = 0; index < this.딟.Count; ++index)
    {
      this.딟[index].땠();
      GlobalAppData.땼().땃(this.딟[index].딸());
    }
    this.딟 = true;
  }

  public void Clear()
  {
    if (this.딟 == null)
      return;
    for (int index = 0; index < this.딟.Count; ++index)
      Object.Destroy((Object) ((Component) this.딟[index]).gameObject);
    this.딟.Clear();
  }

  public 땓.떀 AddCommanderToRoster(string CommanderId)
  {
    for (int index = 0; index < this.딟.Count; ++index)
    {
      SquadSelectionUnitButtonNew componentInChildren = ((Component) this.딟[index]).GetComponentInChildren<SquadSelectionUnitButtonNew>();
      if (componentInChildren.Character.딳() == CommanderId)
      {
        componentInChildren.UnitAdded();
        componentInChildren.Lock();
        return componentInChildren.Character;
      }
    }
    return (땓.떀) null;
  }

  public void UnitAdded(int RemainingSP, int AvailableSlots) => this.UpdateUnitAvailableStatus(RemainingSP, AvailableSlots);

  public void UnitRemoved(SquadSelectionUnitButtonNew Button, int RemainingSP, int AvailableSlots)
  {
    for (int index = 0; index < this.딟.Count; ++index)
    {
      SquadSelectionUnitButtonNew componentInChildren = ((Component) this.딟[index]).GetComponentInChildren<SquadSelectionUnitButtonNew>();
      if (componentInChildren.Character.딳() == Button.Character.딳())
      {
        componentInChildren.UnitRemoved();
        break;
      }
    }
    this.UpdateUnitAvailableStatus(RemainingSP, AvailableSlots);
  }

  public void RemoveAllUnits(int RemainingSP, int AvailableSlots)
  {
    for (int index = 0; index < this.딟.Count; ++index)
    {
      SquadSelectionUnitButtonNew componentInChildren = ((Component) this.딟[index]).GetComponentInChildren<SquadSelectionUnitButtonNew>();
      if (componentInChildren.Character.딳() != this.딟)
        componentInChildren.UnitRemoved();
    }
    this.UpdateUnitAvailableStatus(RemainingSP, AvailableSlots);
  }

  public bool CanAddMoreUnits(int RemainingSP, int AvailableSlots)
  {
    if (AvailableSlots == 0)
      return false;
    bool flag = false;
    for (int index = 0; index < this.딟.Count; ++index)
    {
      SquadSelectionUnitButtonNew componentInChildren = ((Component) this.딟[index]).GetComponentInChildren<SquadSelectionUnitButtonNew>();
      if (Object.op_Inequality((Object) componentInChildren, (Object) null) && !componentInChildren.get_UnitSelected() && componentInChildren.Character.딟(GlobalAppData.딢()) <= RemainingSP)
      {
        flag = true;
        break;
      }
    }
    return flag;
  }

  public SquadSelectionUnitButtonNew GetRandomAvailableUnit(
    int RemainingSP,
    int AvailableSlots,
    int UsedSlots)
  {
    if (AvailableSlots == 0)
      return (SquadSelectionUnitButtonNew) null;
    int num1 = int.MaxValue;
    if (UsedSlots < 1)
    {
      for (int index = 0; index < this.딟.Count; ++index)
      {
        SquadSelectionUnitButtonNew componentInChildren = ((Component) this.딟[index]).GetComponentInChildren<SquadSelectionUnitButtonNew>();
        if (Object.op_Inequality((Object) componentInChildren, (Object) null) && !componentInChildren.get_UnitSelected())
        {
          int num2 = componentInChildren.Character.딟(GlobalAppData.딢());
          if (num2 < num1)
            num1 = num2;
        }
      }
    }
    딶.떈 떈 = new 딶.떈();
    SquadSelectionUnitButtonNew selectionUnitButtonNew = (SquadSelectionUnitButtonNew) null;
    int index1 = 떈.딟(0, this.딟.Count);
    for (int index2 = 0; index2 < this.딟.Count; ++index2)
    {
      SquadSelectionUnitButtonNew componentInChildren = ((Component) this.딟[index1]).GetComponentInChildren<SquadSelectionUnitButtonNew>();
      int num3 = RemainingSP;
      if (num1 != int.MaxValue)
        num3 -= num1;
      if (!componentInChildren.get_UnitSelected() && componentInChildren.Character.딟(GlobalAppData.딢()) <= num3)
      {
        selectionUnitButtonNew = componentInChildren;
        break;
      }
      ++index1;
      if (index1 >= this.딟.Count)
        index1 = 0;
    }
    return selectionUnitButtonNew;
  }

  public void UpdateUnitAvailableStatus(int RemainingSP, int AvailableSlots)
  {
    for (int index = 0; index < this.딟.Count; ++index)
    {
      SquadSelectionUnitButtonNew componentInChildren = ((Component) this.딟[index]).GetComponentInChildren<SquadSelectionUnitButtonNew>();
      if (Object.op_Inequality((Object) componentInChildren, (Object) null) && !componentInChildren.get_UnitSelected())
      {
        if (AvailableSlots == 0)
          componentInChildren.SetUnitAvailable(false);
        else if (componentInChildren.Character.딟(GlobalAppData.딢()) > RemainingSP)
          componentInChildren.SetUnitAvailable(false);
        else
          componentInChildren.SetUnitAvailable(true);
      }
    }
  }

  private void Update()
  {
    if (this.딟)
    {
      if (!this.딢)
      {
        this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab, new Vector3(0.0f, 1.6f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
        this.딢 = true;
      }
      if (!((딟.딗) GlobalAppData.땼()).땽() && this.딟)
      {
        this.딟 = false;
        this.땄 = true;
        this.InitButtons();
      }
    }
    else if (this.땄)
    {
      if (this.AllButtonsLoaded())
      {
        this.땄 = false;
        this.딟.LoadingFinished();
      }
    }
    else if (this.딢)
    {
      this.딟.Close();
      this.딢 = false;
    }
    this.UpdateCharacterCards();
  }

  private void UpdateCharacterCards()
  {
    if (this.딟 == null)
      return;
    Vector3 딟 = this.딟;
    ref Vector3 local = ref 딟;
    local.x = (__Null) (local.x - (double) this.UnitSelectionList.get_Offset());
    ((Component) this.RosterBase).transform.localPosition = 딟;
    this.딟 = this.UnitSelectionList.get_ActiveElement();
  }

  private void InitButtons()
  {
    if (this.딟 == null)
      this.딟 = new List<Transform>();
    if (this.딧)
    {
      this.딟.Clear();
      this.딟 = -1;
      for (int CharacterIndex = 0; CharacterIndex < this.딟.Count; ++CharacterIndex)
        this.AddCharacterCard(CharacterIndex);
    }
    else
    {
      for (int CharacterIndex = 0; CharacterIndex < this.딟.Count; ++CharacterIndex)
        this.UpdateCharacterCard(CharacterIndex);
      if (this.딟.Count > this.딟.Count)
      {
        for (int index1 = 0; index1 < this.딟.Count; ++index1)
        {
          bool flag = false;
          for (int index2 = 0; index2 < this.딟.Count; ++index2)
          {
            SquadSelectionUnitButtonNew componentInChildren = ((Component) this.딟[index2]).GetComponentInChildren<SquadSelectionUnitButtonNew>();
            if (this.딟[index1].딳() == componentInChildren.Character.딳())
            {
              flag = true;
              break;
            }
          }
          if (!flag)
            this.AddCharacterCard(index1);
        }
      }
    }
    this.SortCharacterCards();
    for (int index = 0; index < this.딟.Count; ++index)
    {
      ((Component) this.딟[index]).transform.parent = ((Component) this.RosterBase).transform;
      ((Component) this.딟[index]).transform.localPosition = new Vector3((float) index * this.딟, 0.0f, 0.0f);
    }
    this.UnitSelectionList.set_ActiveElement(this.딟 == -1 ? 0 : this.딟);
    this.UnitSelectionList.MinOffset = 0.0f;
    this.UnitSelectionList.MaxOffset = (float) (this.딟.Count - 1) * this.딟;
    this.UnitSelectionList.SpringBounds = this.딟 * 0.5f;
    this.UnitSelectionList.NumElements = this.딟.Count;
    this.UnitSelectionList.UpdateControl();
    this.UnitSelectionList.ResetToActive();
  }

  private void UpdateCharacterCard(int CharacterIndex)
  {
    SquadSelectionUnitButtonNew componentInChildren = ((Component) this.딟[CharacterIndex]).GetComponentInChildren<SquadSelectionUnitButtonNew>();
    땓.떀 떀 = GlobalAppData.땽().딟(componentInChildren.Character);
    if (떀 == null)
      return;
    땓.떀 Character = 떀.땳();
    Character.땠();
    this.InitButton(Character, componentInChildren, false);
  }

  private void AddCharacterCard(int CharacterIndex)
  {
    땓.떀 Character = this.딟[CharacterIndex].땳();
    Character.땠();
    if (Character.땁().ClassType == 땓.땅.땃 && !(Character.딳() == this.딟))
      return;
    Transform transform = Object.Instantiate((Object) this.CharacterCardPrefab) as Transform;
    SquadSelectionUnitButtonNew componentInChildren = ((Component) transform).GetComponentInChildren<SquadSelectionUnitButtonNew>();
    this.InitButton(Character, componentInChildren, true);
    this.딟.Add(transform);
  }

  private void SortCharacterCards() => this.딟.Sort((IComparer<Transform>) new 땃.땓());

  private void InitButton(땓.떀 Character, SquadSelectionUnitButtonNew Button, bool ReInit) => Button.Init(Character, false, this.ButtonNAShader, ReInit);

  public bool IsAtLastElement(int Padding) => this.딟 != null && this.UnitSelectionList.get_ActiveElement() >= this.딟.Count - 1 - Padding;

  public bool IsAtFirstElement(int Padding) => this.딟 != null && this.UnitSelectionList.get_ActiveElement() <= Padding;

  public 땓.떀 GetActiveCharacter()
  {
    SquadSelectionUnitButtonNew componentInChildren = ((Component) this.딟[this.UnitSelectionList.get_ActiveElement()]).GetComponentInChildren<SquadSelectionUnitButtonNew>();
    return Object.op_Inequality((Object) componentInChildren, (Object) null) ? componentInChildren.Character : (땓.떀) null;
  }

  private bool AllButtonsLoaded()
  {
    if (this.딟 == null)
      return false;
    for (int index = 0; index < this.딟.Count; ++index)
    {
      SquadSelectionUnitButtonNew componentInChildren = ((Component) this.딟[index]).GetComponentInChildren<SquadSelectionUnitButtonNew>();
      if (!componentInChildren.CharacterIconLoaded || !componentInChildren.WeaponIconLoaded)
        return false;
    }
    return true;
  }
}
