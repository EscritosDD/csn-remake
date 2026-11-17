// Decompiled with JetBrains decompiler
// Type: TallyCoinLines
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;
using 딢;

public class TallyCoinLines : MonoBehaviour
{
  public bool CoinsGrowLeft;
  public int MaxNumCoinLines;
  public int MaxNumCoinsPerLine;
  public float CoinXOffet;
  public float CoinYOffet;
  public float CoinZOffet;
  public float CoinLineAnimTime;
  public GameObject CoinPrefab;
  private float 딟;
  private float 땄;
  private GameObject[] 딟;
  private int 딟;
  private int 땄;
  private 땿 딟 = new 땿();

  public void InitailiseCoinLineData(float CoinAnimTime, float PercentToCreate)
  {
    this.딟 = CoinAnimTime / (float) (this.MaxNumCoinLines * this.MaxNumCoinsPerLine);
    this.땄 = 0.0f;
    this.땄 = Mathf.CeilToInt((float) (this.MaxNumCoinLines * this.MaxNumCoinsPerLine) * PercentToCreate);
    this.딟 = new GameObject[this.땄];
  }

  public void ActivateCoinLines()
  {
    // ISSUE: reference to a compiler-generated method
    this.set_bCoinLinesActive(true);
    this.딟 = 0;
    this.딟.딟(0.2f);
  }

  public void ShowAllCoinLinesNow()
  {
    if (this.딟 >= this.땄)
      return;
    while (this.딟 < this.땄)
      this.AddCoinToLine();
  }

  public void DeactivateCoinLines()
  {
    // ISSUE: reference to a compiler-generated method
    this.set_bCoinLinesActive(false);
    if (this.딟 != null)
    {
      for (int index = 0; index < this.딟.Length; ++index)
      {
        Object.DestroyImmediate((Object) this.딟[index]);
        this.딟[index] = (GameObject) null;
      }
    }
    this.딟 = (GameObject[]) null;
  }

  private void Update()
  {
    this.딟.딟();
    if (!this.get_bCoinLinesActive() || !this.딟.땄())
      return;
    this.땄 += Time.deltaTime;
    if ((double) this.땄 < (double) this.딟)
      return;
    this.땄 = 0.0f;
    this.AddCoinToLine();
  }

  private void AddCoinToLine()
  {
    if (this.딟 >= this.땄)
    {
      // ISSUE: reference to a compiler-generated method
      this.set_bCoinLinesActive(false);
    }
    else
    {
      this.딟[this.딟] = Object.Instantiate((Object) this.CoinPrefab) as GameObject;
      this.딟[this.딟].transform.localPosition = this.GetNextCoinPosition();
      ++this.딟;
    }
  }

  private Vector3 GetNextCoinPosition()
  {
    int num1 = Mathf.FloorToInt((float) (this.딟 / this.MaxNumCoinsPerLine));
    int num2 = this.딟 - num1 * this.MaxNumCoinsPerLine;
    if (this.CoinsGrowLeft)
      num2 = -num2;
    return new Vector3((float) (((Component) this).transform.position.x + (double) this.CoinXOffet * (double) num2), (float) (((Component) this).transform.position.y + (double) this.CoinYOffet * (double) this.딟), (float) (((Component) this).transform.position.z + (double) this.CoinZOffet * (double) num1));
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_bCoinLinesActive() => this.딟;
}
