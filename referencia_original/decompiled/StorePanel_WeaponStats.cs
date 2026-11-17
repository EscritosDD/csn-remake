// Decompiled with JetBrains decompiler
// Type: StorePanel_WeaponStats
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

public class StorePanel_WeaponStats : MonoBehaviour
{
  private 땃.딷 딟;
  public GuiText3D RangeValueText;
  public GuiText3D KnockbackValueText;
  public GuiText3D DamageValueText;
  public GuiText3D APCostvalueText;
  public GuiText3D TypeValueText;
  public GuiText3D SPCostValueText;
  public GameObject RangeIcon;
  public GameObject KnockbackIcon;
  public GameObject DamageIcon;
  public GameObject APCostIcon;
  public GameObject TypeIcon;
  public GameObject SPCostIcon;
  public Shader ClippedShader;
  private 땃.땭[] 딟;
  public GuiText3D ClassTextPrefab;
  public Transform ClassTextAttach;
  public Transform ClassIconAttach;
  public int ClassNameSpacing;

  public void Init(땃.딷 Item)
  {
    this.딟 = Item;
    땓.딞 딞 = Item.땃().땃() as 땓.딞;
    this.TypeValueText.Text = (Item.땃().딢() as 땓.딠).딶();
    this.RangeValueText.Text = 딞.딟();
    this.KnockbackValueText.Text = 딞.땄();
    this.DamageValueText.Text = 딞.딧();
    this.APCostvalueText.Text = 딞.딢();
    this.SPCostValueText.Text = 딞.떎();
    this.RangeValueText.UpdateMesh();
    this.KnockbackValueText.UpdateMesh();
    this.DamageValueText.UpdateMesh();
    this.APCostvalueText.UpdateMesh();
    this.TypeValueText.UpdateMesh();
    this.SPCostValueText.UpdateMesh();
    this.SetIconShaders();
  }

  private void SetIconShaders()
  {
    this.RangeIcon.renderer.material = GlobalAppData.땲().딟(this.RangeIcon.renderer.material, this.ClippedShader);
    this.KnockbackIcon.renderer.material = GlobalAppData.땲().딟(this.KnockbackIcon.renderer.material, this.ClippedShader);
    this.DamageIcon.renderer.material = GlobalAppData.땲().딟(this.DamageIcon.renderer.material, this.ClippedShader);
    this.APCostIcon.renderer.material = GlobalAppData.땲().딟(this.APCostIcon.renderer.material, this.ClippedShader);
    this.TypeIcon.renderer.material = GlobalAppData.땲().딟(this.TypeIcon.renderer.material, this.ClippedShader);
    this.SPCostIcon.renderer.material = GlobalAppData.땲().딟(this.SPCostIcon.renderer.material, this.ClippedShader);
  }

  public void SetAvailableToIcons()
  {
    string[] strArray = (this.딟.땃().딢() as 땓.딠).땓();
    if (strArray == null)
      return;
    this.딟 = new 땃.땭[strArray.Length];
    for (int index = 0; index < strArray.Length; ++index)
    {
      this.딟[index] = new 땃.땭();
      float num = (float) ((double) this.ClassNameSpacing * 0.5 * (double) index / 320.0);
      ClassInfo classInfo = StorePanel_WeaponStats.딟(strArray[index]);
      this.딟[index].딟(classInfo);
      Vector3 vector3;
      // ISSUE: explicit constructor call
      ((Vector3) ref vector3).\u002Ector((float) this.ClassIconAttach.position.x + num, (float) this.ClassIconAttach.position.y, (float) this.ClassIconAttach.position.z);
      ((Component) this.딟[index].딟).gameObject.SetActive(true);
      ((Component) this.딟[index].딟).transform.position = vector3;
      ((Component) this.딟[index].딟).transform.parent = ((Component) this).transform;
    }
  }

  public static ClassInfo 딟([In] string obj0)
  {
    for (int index = 0; index < FrontendHub.딟.StoreScreen.ClassInfoList.Length; ++index)
    {
      if (string.Compare(FrontendHub.딟.StoreScreen.ClassInfoList[index].ClassName, obj0, true) == 0)
        return FrontendHub.딟.StoreScreen.ClassInfoList[index];
    }
    Debug.LogError((object) ("Failed to find class info for class " + obj0));
    return (ClassInfo) null;
  }
}
