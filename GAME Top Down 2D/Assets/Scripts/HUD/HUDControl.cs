using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControl : MonoBehaviour
{
    [Header("Itens")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;

    [Header("Tools")]
    //[SerializeField] private Image axeUI;
    //[SerializeField] private Image shoveUI;
    //[SerializeField] private Image bucketUI;
    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectcolor;
    [SerializeField] private Color alphacolor;

    private PlayerItens playerItens;
    private Player player;

    private void Awake()
    {

        playerItens = FindAnyObjectByType<PlayerItens>();
        player = FindAnyObjectByType<Player>();

    }

    void Start()
    {

        waterUIBar.fillAmount = 0;
        woodUIBar.fillAmount = 0;
        carrotUIBar.fillAmount = 0;

    }


    void Update()
    {

        SelectTools();
        QtdItens();

    }

    #region BarTools_and_Itens

    void SelectTools()
    {

        //toolsUI[player.HandlingObj].color = selectcolor;

        for (int i = 0; i < toolsUI.Count; i++)
        {

            if (i == player.HandlingObj)
            {

                toolsUI[i].color = selectcolor;

            }
            else
            {

                toolsUI[i].color = alphacolor;

            }

        }

    }

    void QtdItens()
    {

        waterUIBar.fillAmount = playerItens.CurrentWater / playerItens.WaterLimit1;
        woodUIBar.fillAmount = playerItens.TotalWood / playerItens.WoodLimit;
        carrotUIBar.fillAmount = playerItens.Carrots / playerItens.CarrotLimit;

    }
    #endregion
}
