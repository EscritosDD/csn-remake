// Decompiled with JetBrains decompiler
// Type: BarracksWeaponInfoPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class BarracksWeaponInfoPanelHandler : MonoBehaviour
{
  public GuiText3D WeaponNameText;
  private bool 딟;
  public MenuAnimatorHandler MenuAnim;
  public GameObject LockedBackground;
  public GameObject UnlockedBackground;
  public GameObject SquadPointsDisplay;
  public GuiText3D WeaponName;
  public GuiText3D WeaponCountInfo;
  public GuiText3D Range;
  public GuiText3D OptimumRange;
  public GuiText3D Knockback;
  public GuiText3D Damage;
  public GuiText3D APCost;
  public GuiText3D SPCost;
  public GuiText3D RangeTitle;
  public GuiText3D OptimumRangeTitle;
  public GuiText3D KnockbackTitle;
  public GuiText3D DamageTitle;
  public GuiText3D APCostTitle;
  public GameObject RangeIcon;
  public GameObject OptimumRangeIcon;
  public GameObject KnockbackIcon;
  public GameObject DamageIcon;
  public GameObject APCostIcon;
  public Material RangeBlueIcon;
  public Material OptimumRangeBlueIcon;
  public Material KnockbackBlueIcon;
  public Material DamageBlueIcon;
  public Material APCostBlueIcon;

  private void Start()
  {
  }

  public void Init(Transform StartPoint, Transform EndPoint)
  {
    this.MenuAnim = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.MenuAnim.StartPoint = StartPoint;
    this.MenuAnim.EndPoint = EndPoint;
  }

  public void UpdateWeaponInfo(string SelectedWeaponId, int NumberOfWeaponInUse)
  {
    딢.땻 땻 = GlobalAppData.땼().땔(SelectedWeaponId);
    this.WeaponName.LocText = 땻.땥().Name;
    this.WeaponName.UpdateMesh();
    int num1 = GlobalAppData.땽().땃(땻.땄());
    this.딟 = num1 >= NumberOfWeaponInUse;
    this.WeaponCountInfo.Text = Mathf.Min(NumberOfWeaponInUse, num1).ToString() + " / " + num1.ToString();
    this.WeaponCountInfo.UpdateMesh();
    WeaponGameplayData WeaponData = 땻.땥().딟((딶.땖) null);
    int Distance;
    int EndDistance;
    this.WorkOutOptimumDamageAndRange(WeaponData, out Distance, out EndDistance);
    string str = Distance != EndDistance ? Distance.ToString() + " - " + EndDistance.ToString() : Distance.ToString();
    float num2 = (WeaponData.땄() + WeaponData.DamageSpread * 0.5f) * (float) WeaponData.ShotsPerAttack;
    this.Range.Text = WeaponData.MaxRange.ToString();
    this.OptimumRange.Text = str;
    this.Knockback.Text = WeaponData.KnockbackDistance.ToString();
    this.Damage.Text = Mathf.RoundToInt(num2).ToString();
    this.APCost.Text = WeaponData.RequiredActionPoints.ToString();
    this.SPCost.Text = WeaponData.SquadPoints.ToString();
    this.SPCost.UpdateMesh();
    this.Range.UpdateMesh();
    this.OptimumRange.UpdateMesh();
    this.Knockback.UpdateMesh();
    this.Damage.UpdateMesh();
    this.APCost.UpdateMesh();
    this.UpdateDisplay();
  }

  private void WorkOutOptimumDamageAndRange(
    WeaponGameplayData WeaponData,
    out int Distance,
    out int EndDistance)
  {
    AnimationCurve damageFallOffCurve = WeaponData.WeaponDamageFallOffCurve.WeaponDamageFallOffCurve;
    float num1 = 0.0f;
    Distance = 0;
    EndDistance = 0;
    float num2 = 1f / (float) WeaponData.MaxRange;
    for (float num3 = num2; (double) num3 <= 1.0; num3 += num2)
    {
      float num4 = damageFallOffCurve.Evaluate(num3);
      if ((double) num4 > (double) num1)
      {
        num1 = num4;
        ++Distance;
        ++EndDistance;
      }
      else if ((double) num1 == (double) num4)
        ++EndDistance;
    }
  }

  private void UpdateDisplay()
  {
    if (this.딟)
    {
      this.LockedBackground.SetActive(false);
      this.UnlockedBackground.SetActive(true);
      this.RangeIcon.renderer.material = this.RangeBlueIcon;
      this.OptimumRangeIcon.renderer.material = this.OptimumRangeBlueIcon;
      this.KnockbackIcon.renderer.material = this.KnockbackBlueIcon;
      this.DamageIcon.renderer.material = this.DamageBlueIcon;
      this.APCostIcon.renderer.material = this.APCostBlueIcon;
      this.WeaponName.TextColor = Color.black;
      this.RangeTitle.TextColor = Color.black;
      this.OptimumRangeTitle.TextColor = Color.black;
      this.KnockbackTitle.TextColor = Color.black;
      this.DamageTitle.TextColor = Color.black;
      this.APCostTitle.TextColor = Color.black;
    }
    else
    {
      this.LockedBackground.SetActive(true);
      this.UnlockedBackground.SetActive(false);
      this.WeaponName.TextColor = Color.white;
      this.RangeTitle.TextColor = Color.white;
      this.OptimumRangeTitle.TextColor = Color.white;
      this.KnockbackTitle.TextColor = Color.white;
      this.DamageTitle.TextColor = Color.white;
      this.APCostTitle.TextColor = Color.white;
    }
    this.WeaponName.UpdateMesh();
    this.RangeTitle.UpdateMesh();
    this.OptimumRangeTitle.UpdateMesh();
    this.KnockbackTitle.UpdateMesh();
    this.DamageTitle.UpdateMesh();
    this.APCostTitle.UpdateMesh();
  }

  public void Close() => this.MenuAnim.Close();
}
