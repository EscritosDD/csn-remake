// Decompiled with JetBrains decompiler
// Type: CommanderAbilitySelectionAbilityGrid
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("Gui3D/Components/Commander Ability Grid")]
public class CommanderAbilitySelectionAbilityGrid : MonoBehaviour
{
  public Transform SelectedAbilityPrefab;
  public Transform EmptyUnitSlotPrefab;
  public GameObject SquadPointIcon;
  private List<땃.딶> 딟;
  private int 딟;
  public GuiText3D RemainingSquadPointsText;
  public GuiText3D TotalSquadPointsText;
  private float 딟 = 0.37f;
  private float 땄 = 0.12f;
  private int 땄 = 4;
  private int 딧 = 2;
  private int 딢;
  private GameObjectPulse 딟;
  private float 딧 = 1.2f;
  private float 딢;
  private 딶.딞 딟;
  private Vector3 딟 = new Vector3(0.25f, 0.0f, 0.06f);

  public void Init(int SquadPointsTier, bool Restart, 딶.딞 Calculator)
  {
    this.딟 = Calculator;
    if (!Restart)
      return;
    this.Clear();
    SquadPointsTierEntry squadPointsTierEntry = GlobalAppData.딢().GenericData.땃(SquadPointsTier);
    this.딢 = this.땄 / this.딧;
    // ISSUE: reference to a compiler-generated method
    this.set_UsedAP(0);
    this.딟 = squadPointsTierEntry.MaxAbilitySquadPoints;
    int num1 = 0;
    this.딟 = new List<땃.딶>(this.땄);
    for (int index = 0; index < this.땄; ++index)
    {
      int num2 = index;
      if (index >= this.딢)
      {
        num1 = index / this.딢;
        num2 = index - num1 * this.딢;
      }
      땃.딶 딶 = new 땃.딶();
      딶.딟 = Vector3.op_Addition(this.딟, new Vector3((float) num2 * this.딟, 0.1f, (float) -num1 * this.땄));
      Transform transform = Object.Instantiate((Object) this.EmptyUnitSlotPrefab) as Transform;
      ((Component) transform).transform.parent = ((Component) this).transform;
      ((Component) transform).transform.localPosition = 딶.딟;
      GuiText3D componentInChildren = ((Component) transform).GetComponentInChildren<GuiText3D>();
      if (Object.op_Inequality((Object) componentInChildren, (Object) null))
      {
        componentInChildren.Text = (index + 1).ToString();
        componentInChildren.UpdateMesh();
      }
      딶.땄 = transform;
      this.딟.Add(딶);
    }
    if (Object.op_Inequality((Object) this.TotalSquadPointsText, (Object) null))
    {
      this.TotalSquadPointsText.Text = "/ " + this.딟.ToString();
      this.TotalSquadPointsText.UpdateMesh();
    }
    this.UpdateSquadPointText();
  }

  public void Clear()
  {
    this.딟.땃();
    if (this.딟 == null)
      return;
    for (int index = 0; index < this.딟.Count; ++index)
    {
      if (Object.op_Inequality((Object) this.딟[index].딟, (Object) null))
        Object.DestroyImmediate((Object) ((Component) this.딟[index].딟).gameObject);
      if (Object.op_Inequality((Object) this.딟[index].땄, (Object) null))
        Object.DestroyImmediate((Object) ((Component) this.딟[index].땄).gameObject);
    }
    this.딟.Clear();
  }

  public void Update()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null) || ((Component) this.딟).gameObject.transform.localScale.x < (double) this.딢)
      return;
    this.딟.OnButtonReleased();
  }

  public bool AbilityAdded(PlayerAbilityEntry Ability, bool LockButton)
  {
    땃.딶 availableGridSlot = this.GetAvailableGridSlot();
    if (availableGridSlot == null || !this.딟.땄(Ability.AbilityInfo.Ability))
      return false;
    Transform transform = Object.Instantiate((Object) this.SelectedAbilityPrefab) as Transform;
    ((Component) transform).transform.parent = ((Component) this).transform;
    ((Component) transform).transform.localPosition = new Vector3((float) availableGridSlot.딟.x, 0.2f, (float) availableGridSlot.딟.z);
    CommanderAbilitySelectionButton componentInChildren = ((Component) transform).GetComponentInChildren<CommanderAbilitySelectionButton>();
    if (LockButton)
      componentInChildren.Lock();
    this.InitButton(Ability, componentInChildren);
    availableGridSlot.딟 = transform;
    // ISSUE: reference to a compiler-generated method
    this.set_UsedAP(this.딟.딟());
    this.UpdateSquadPointText();
    this.AnimateSquadPointIcon();
    componentInChildren.UpdateButtonVisuals(true);
    return true;
  }

  private 땃.딶 GetAvailableGridSlot()
  {
    for (int index = 0; index < this.딟.Count; ++index)
    {
      if (Object.op_Equality((Object) this.딟[index].딟, (Object) null))
        return this.딟[index];
    }
    return (땃.딶) null;
  }

  private void InitButton(PlayerAbilityEntry Ability, CommanderAbilitySelectionButton Button) => Button.Init(Ability, true, (Shader) null, true);

  public void AbilityRemoved(CommanderAbilitySelectionButton Button)
  {
    for (int index = 0; index < this.딟.Count; ++index)
    {
      Transform 딟 = this.딟[index].딟;
      if (!Object.op_Equality((Object) 딟, (Object) null))
      {
        CommanderAbilitySelectionButton componentInChildren = ((Component) 딟).GetComponentInChildren<CommanderAbilitySelectionButton>();
        if (componentInChildren.get_Ability().AbilityInfo.Ability == Button.get_Ability().AbilityInfo.Ability)
        {
          this.딟.딧(componentInChildren.get_Ability().AbilityInfo.Ability);
          // ISSUE: reference to a compiler-generated method
          this.set_UsedAP(this.딟.딟());
          Object.Destroy((Object) ((Component) this.딟[index].딟).gameObject);
          this.딟[index].딟 = (Transform) null;
          break;
        }
      }
    }
    Button.UpdateButtonVisuals(false);
    this.UpdateSquadPointText();
    this.AnimateSquadPointIcon();
    this.PackGridElements();
  }

  public void RemoveAllAbilities()
  {
    int num = this.get_UsedAP();
    this.딟.땃();
    // ISSUE: reference to a compiler-generated method
    this.set_UsedAP(this.딟.딟());
    for (int index = 0; index < this.딟.Count; ++index)
    {
      if (Object.op_Inequality((Object) this.딟[index].딟, (Object) null))
      {
        Object.Destroy((Object) ((Component) this.딟[index].딟).gameObject);
        this.딟[index].딟 = (Transform) null;
      }
    }
    this.UpdateSquadPointText();
    if (this.get_UsedAP() == num)
      return;
    this.AnimateSquadPointIcon();
  }

  private void PackGridElements()
  {
    int index1 = -1;
    for (int index2 = 0; index2 < this.딟.Count; ++index2)
    {
      if (Object.op_Equality((Object) this.딟[index2].딟, (Object) null))
        index1 = index2;
      if (index1 != -1 && Object.op_Inequality((Object) this.딟[index2].딟, (Object) null))
      {
        this.딟[index1].딟 = this.딟[index2].딟;
        ((Component) this.딟[index1].딟).transform.localPosition = new Vector3((float) this.딟[index1].딟.x, 0.2f, (float) this.딟[index1].딟.z);
        this.딟[index2].딟 = (Transform) null;
        index1 = index2;
      }
    }
  }

  private void UpdateSquadPointText()
  {
    if (!Object.op_Inequality((Object) this.RemainingSquadPointsText, (Object) null))
      return;
    this.RemainingSquadPointsText.Text = this.get_UsedAP().ToString();
    this.RemainingSquadPointsText.UpdateMesh();
  }

  public int GetNumUsedSlots()
  {
    int num = 0;
    for (int index = 0; index < this.딟.Count; ++index)
    {
      if (Object.op_Inequality((Object) this.딟[index].딟, (Object) null))
        ++num;
    }
    return num;
  }

  public bool IsValid() => this.딟 != null;

  public int GetNumAvailableSlots() => this.땄 - this.GetNumUsedSlots();

  public void FillAbilityList()
  {
  }

  private void AnimateSquadPointIcon()
  {
    if (!Object.op_Inequality((Object) this.SquadPointIcon, (Object) null) || !Object.op_Equality((Object) this.딟, (Object) null) && ((Component) this.딟).gameObject.transform.localScale.x != 1.0)
      return;
    this.딟 = this.SquadPointIcon.gameObject.AddComponent<GameObjectPulse>();
    this.딟.EndScale = this.딧;
    this.딢 = (float) this.SquadPointIcon.gameObject.transform.localScale.x * this.딧;
  }

  [SpecialName]
  public int get_RemainingAP() => this.딟 - this.get_UsedAP();

  [CompilerGenerated]
  [SpecialName]
  public int get_UsedAP() => this.땃;
}
