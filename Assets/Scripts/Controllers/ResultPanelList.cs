using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPanelList : MonoBehaviour
{
    public static ResultPanelList Instance;
    public List<InfoPanelModel> InfoPanelModels = new List<InfoPanelModel>();
    public List<ResultTextButton> ResultButtonsList = new List<ResultTextButton>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }
    public void AddModel(InfoPanelModel model)
    {
        InfoPanelModels.Add(model);
    }
    public void AddResultButton(ResultTextButton button)
    {
        ResultButtonsList.Add(button);
    }
}
