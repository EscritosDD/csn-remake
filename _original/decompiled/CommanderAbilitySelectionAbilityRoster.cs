// Decompiled with JetBrains decompiler
// Type: CommanderAbilitySelectionAbilityRoster
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using 딶;

[AddComponentMenu("Gui3D/Components/Commander Ability Roster")]
public class CommanderAbilitySelectionAbilityRoster : MonoBehaviour
{
  private List<PlayerAbilityEntry> 딟;
  private bool 딟;
  private bool 땄;
  private int 딟;
  public GuiScroller3D AbilitySelectionList;
  public Transform AbilityCardPrefab;
  public Transform RosterBase;
  public Shader ButtonNAShader;
  private float 딟 = 0.4f;
  private Vector3 딟;
  private List<Transform> 딟;
  private int 땄;

  public void Start() => this.딟 = ((Component) this.RosterBase).transform.localPosition;

  public void Init(int BaseSP, bool Restart)
  {
    int num = GlobalAppData.땽().때();
    PlayerAbilityEntry[] playerAbilities = GlobalAppData.딢().GenericData.PlayerAbilities;
    this.딟 = new List<PlayerAbilityEntry>();
    foreach (PlayerAbilityEntry playerAbilityEntry in playerAbilities)
    {
      if (num > playerAbilityEntry.RequiredLevel)
        this.딟.Add(playerAbilityEntry);
    }
    this.땄 = Restart;
    if (Restart)
      this.Clear();
    this.딟 = true;
    this.딟 = BaseSP;
  }

  public void Clear()
  {
    if (this.딟 == null)
      return;
    for (int index = 0; index < this.딟.Count; ++index)
      Object.Destroy((Object) ((Component) this.딟[index]).gameObject);
    this.딟.Clear();
  }

  public void AbilityAdded(int RemainingSP, int AvailableSlots) => this.UpdateAbilityAvailableStatus(RemainingSP, AvailableSlots);

  public void AbilityRemoved(
    CommanderAbilitySelectionButton Button,
    int RemainingSP,
    int AvailableSlots)
  {
    for (int index = 0; index < this.딟.Count; ++index)
    {
      CommanderAbilitySelectionButton componentInChildren = ((Component) this.딟[index]).GetComponentInChildren<CommanderAbilitySelectionButton>();
      if (componentInChildren.get_Ability().AbilityInfo.Ability == Button.get_Ability().AbilityInfo.Ability)
      {
        componentInChildren.AbilityRemoved();
        break;
      }
    }
    this.UpdateAbilityAvailableStatus(RemainingSP, AvailableSlots);
  }

  public void RemoveAllAbilities(int RemainingSP, int AvailableSlots)
  {
    for (int index = 0; index < this.딟.Count; ++index)
      ((Component) this.딟[index]).GetComponentInChildren<CommanderAbilitySelectionButton>().AbilityRemoved();
    this.UpdateAbilityAvailableStatus(RemainingSP, AvailableSlots);
  }

  public List<CommanderAbilitySelectionButton> GetAbilitiesToAutoSelect(
    int AvailableSquadPoints)
  {
    if (this.딟 == null || this.딟)
      return (List<CommanderAbilitySelectionButton>) null;
    List<CommanderAbilitySelectionButton> abilitySelectionButtonList = new List<CommanderAbilitySelectionButton>();
    int num = 0;
    for (int index = 0; index < this.딟.Count; ++index)
    {
      CommanderAbilitySelectionButton componentInChildren = ((Component) this.딟[index]).GetComponentInChildren<CommanderAbilitySelectionButton>();
      abilitySelectionButtonList.Add(componentInChildren);
      num += componentInChildren.get_Ability().SquadPoints;
    }
    if (num > AvailableSquadPoints)
      abilitySelectionButtonList.Clear();
    return abilitySelectionButtonList;
  }

  public CommanderAbilitySelectionButton GetRandomAvailableAbility(
    int RemainingSP,
    int AvailableSlots)
  {
    if (AvailableSlots == 0)
      return (CommanderAbilitySelectionButton) null;
    떈 떈 = new 떈();
    CommanderAbilitySelectionButton abilitySelectionButton = (CommanderAbilitySelectionButton) null;
    int index1 = 떈.딟(0, this.딟.Count);
    for (int index2 = 0; index2 < this.딟.Count; ++index2)
    {
      CommanderAbilitySelectionButton componentInChildren = ((Component) this.딟[index1]).GetComponentInChildren<CommanderAbilitySelectionButton>();
      if (!componentInChildren.get_AbilitySelected() && componentInChildren.get_Ability().SquadPoints <= RemainingSP)
      {
        abilitySelectionButton = componentInChildren;
        break;
      }
      ++index1;
      if (index1 >= this.딟.Count)
        index1 = 0;
    }
    return abilitySelectionButton;
  }

  private void UpdateAbilityAvailableStatus(int RemainingSP, int AvailableSlots)
  {
    for (int index = 0; index < this.딟.Count; ++index)
    {
      CommanderAbilitySelectionButton componentInChildren = ((Component) this.딟[index]).GetComponentInChildren<CommanderAbilitySelectionButton>();
      if (Object.op_Inequality((Object) componentInChildren, (Object) null) && !componentInChildren.get_AbilitySelected())
      {
        if (AvailableSlots == 0)
          componentInChildren.SetUnitAvailable(false);
        else if (componentInChildren.get_Ability().SquadPoints > RemainingSP)
          componentInChildren.SetUnitAvailable(false);
        else
          componentInChildren.SetUnitAvailable(true);
      }
    }
  }

  private void Update()
  {
    if (!((딟.딗) GlobalAppData.땼()).땽() && this.딟)
    {
      this.딟 = false;
      this.InitButtons();
    }
    this.UpdateAbilityCards();
  }

  private void UpdateAbilityCards()
  {
    if (this.딟 == null)
      return;
    Vector3 딟 = this.딟;
    ref Vector3 local = ref 딟;
    local.x = (__Null) (local.x - (double) this.AbilitySelectionList.get_Offset());
    ((Component) this.RosterBase).transform.localPosition = 딟;
    this.땄 = this.AbilitySelectionList.get_ActiveElement();
  }

  private void InitButtons()
  {
    if (this.딟 == null)
      this.딟 = new List<Transform>();
    if (this.땄)
    {
      this.딟.Clear();
      this.땄 = -1;
      for (int i = 0; i < this.딟.Count; ++i)
        this.AddAbilityCard(i);
    }
    this.AbilitySelectionList.set_ActiveElement(this.땄 == -1 ? this.딟.Count / 2 : this.땄);
    this.AbilitySelectionList.MinOffset = 0.0f;
    this.AbilitySelectionList.MaxOffset = (float) (this.딟.Count - 1) * this.딟;
    this.AbilitySelectionList.SpringBounds = this.딟 * 0.5f;
    this.AbilitySelectionList.NumElements = this.딟.Count;
    this.AbilitySelectionList.UpdateControl();
    this.AbilitySelectionList.ResetToActive();
    this.UpdateAbilityAvailableStatus(this.딟, 6);
  }

  private void AddAbilityCard(int i)
  {
    Transform transform = Object.Instantiate((Object) this.AbilityCardPrefab) as Transform;
    CommanderAbilitySelectionButton componentInChildren = ((Component) transform).GetComponentInChildren<CommanderAbilitySelectionButton>();
    this.InitButton(this.딟[i], componentInChildren);
    ((Component) transform).transform.parent = ((Component) this.RosterBase).transform;
    ((Component) transform).transform.localPosition = new Vector3((float) i * this.딟, 0.0f, 0.0f);
    this.딟.Add(transform);
  }

  private void InitButton(PlayerAbilityEntry Ability, CommanderAbilitySelectionButton Button) => Button.Init(Ability, false, this.ButtonNAShader, this.땄);

  public bool IsAtLastElement(int Padding) => this.딟 != null && this.AbilitySelectionList.get_ActiveElement() >= this.딟.Count - 1 - Padding;

  public bool IsAtFirstElement(int Padding) => this.딟 != null && this.AbilitySelectionList.get_ActiveElement() <= Padding;

  public PlayerAbilityEntry GetActiveAbility()
  {
    Transform transform = this.딟[this.AbilitySelectionList.get_ActiveElement()];
    if (Object.op_Inequality((Object) transform, (Object) null))
    {
      CommanderAbilitySelectionButton componentInChildren = ((Component) transform).GetComponentInChildren<CommanderAbilitySelectionButton>();
      if (Object.op_Inequality((Object) componentInChildren, (Object) null))
        return componentInChildren.get_Ability();
    }
    return (PlayerAbilityEntry) null;
  }
}
