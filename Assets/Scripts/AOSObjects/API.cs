using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule;
using AosSdk.Core.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;


public enum DialogRole
{
    User,
    Dude
}

[AosSdk.Core.Utils.AosObject(name: "АПИ")]
public class API : AosObjectBase
{
    public UnityAction ShowPlaceEvent;
    public UnityAction StartUpdatePlaceEvent;
    public UnityAction ShowMenuButtonEvent;
    public UnityAction<string> DialogEvent;
    public UnityAction<string> DialogHeaderEvent;
    public UnityAction<string> SetTeleportLocationEvent;
    public UnityAction<string> SetNewLocationTextEvent;
    public UnityAction<string> SetLocationEvent;   
    public UnityAction<string> EnableDietButtonsEvent;
    public UnityAction<string> SetTimerTextEvent;
    public UnityAction<string> ReactionEvent;
    public UnityAction<string, DialogRole> AddTextObjectUiEvent;
    public UnityAction<string, string, string> ResultNameTextButtonEvent;
    public UnityAction<string, string> ResultNameTextButtonSingleEvent;
    public UnityAction<string, string> AddTextObjectUiButtonEvent;
    public UnityAction<string, string> PointEvent;
    public UnityAction<string, string> EnableMovingButtonEvent;
    public UnityAction<string, string, string> ActivateByNameEvent;
    public UnityAction<string, string> ActivatePointByNameEvent;
    public UnityAction<string, string, string, string> SetMessageTextEvent;
    public UnityAction<string, string, string> SetResultTextEvent;
    public UnityAction<string, string> ShowExitTextEvent;
    public UnityAction<string, string, string> ShowMenuTextEvent;
    public Action<string, string, string, string> SetStartTextEvent;

    [AosEvent(name: "Перемещение игрока")]
    public event AosEventHandlerWithAttribute EndTween;
    [AosEvent(name: "Клик по кнопке далее")]
    public event AosEventHandlerWithAttribute navAction;
    [AosEvent(name: "Результат измерения")]
    public event AosEventHandlerWithAttribute OnReason;
    [AosEvent(name: "Открыть меню")]
    public event AosEventHandler OnMenu;
    [AosEvent(name: "Кнопка нажата")]
    public event AosEventHandlerWithAttribute OnDialogPoint;
    public bool MenuTeleport { get; set; } = true;
    public void Teleport([AosParameter("Задать локацию для перемещения")] string location)
    {
        SetTeleportLocationEvent?.Invoke(location);
        EndTween?.Invoke(location);
    }
    [AosAction(name: "Задать текст приветствия")]
    public void showWelcome(JObject welcome, JObject faultInfo, JObject nav)
    {
        string headerText = welcome.SelectToken("name").ToString();
        string commentText = welcome.SelectToken("text").ToString();
        string headerFaultText = faultInfo.SelectToken("name").ToString();
        string commentFaultText = faultInfo.SelectToken("text").ToString();
        SetStartTextEvent?.Invoke(headerText, commentText, headerFaultText, commentFaultText);
        //OnSetTeleportLocation?.Invoke("start");
    }



    public void showDialog(JObject data, JObject nav)
    {

        var temp = data.SelectToken("dialog");
        if (temp != null)
        {
            var dude = temp.SelectToken("name");
            var header = dude.ToString();

            DialogHeaderEvent?.Invoke(header);
        }
        var points = data.SelectToken("points");
        if (points != null)
        {
            foreach (var item in points)
            {
                var action = item.SelectToken("action").ToString();
                if (action != null)
                {
                    DialogEvent?.Invoke(action);
                }
                var id = item.SelectToken("apiId").ToString();
                var name = item.SelectToken("name").ToString();
                if (id != null && name != null)
                    AddTextObjectUiButtonEvent?.Invoke(id, name);

            }
        }
        var temp2 = data.SelectToken("dialog");
        if (temp2 != null)
        {
            var outMsg = temp2.SelectToken("out_msg");
            if (outMsg != null)
            {
                foreach (var item in outMsg)
                {
                    if (item.SelectToken("msg") != null)
                    {
                        var msg = item.SelectToken("msg").ToString();
                        AddTextObjectUiEvent?.Invoke(msg, DialogRole.Dude);
                    }
                }
            }
        }



    }
    public void addDialogMessage(JArray message)
    {
        string msgText = "";
        foreach (var item in message)
        {
            var msg = item.SelectToken("msg");
            var roles = item.SelectTokens("character");
            if (msg != null)
                msgText = msg.ToString();
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    if (role.SelectToken("opt_type") != null)
                    {
                        var roleText = role.SelectToken("opt_type").ToString();
                        if (roleText == "dude")
                            AddTextObjectUiEvent?.Invoke(msgText, DialogRole.Dude);
                        else if (roleText == "user")
                            AddTextObjectUiEvent?.Invoke(msgText, DialogRole.User);
                    }
                }
            }
        }
    }

    public void OnInvokeNavAction(string value)
    {
        navAction.Invoke(value);
    }
    [AosAction(name: "Показать место")]
    public void showPlace(JArray places, JObject nav)
    {
        ShowPlaceEvent?.Invoke();

        foreach (JObject item in places)
        {

            var pl = item.SelectToken("place");
            if (pl != null)
            {
                string location = pl.SelectToken("apiId").ToString();
                if (location != null)
                {
                    SetLocationEvent?.Invoke(location);
                }
                var loc = pl.SelectToken("name");
                if (loc != null)
                    SetNewLocationTextEvent?.Invoke(loc.ToString());
            }
            var points = item.SelectToken("points");
            if (points != null)
            {

                foreach (JObject point in points)
                {
                    if (point != null)
                    {
                        var temp = point.SelectToken("apiId");
                        var id = "";
                        var name = "";
                        var time = "";
                        if (temp != null)
                        {
                            id = temp.ToString();
                            name = point.SelectToken("name").ToString();
                        }
                        //var timeText = point.SelectToken("result");
                        //if (timeText != null)
                        //{
                        //    var timeToShow = timeText.SelectToken("tm");
                        //    if (timeToShow != null)
                        //    {
                        //        time = timeText.SelectToken("tm").ToString();
                        //    }
                        //}
                        ActivateByNameEvent?.Invoke(id, name, time);
                        if (point.SelectToken("view") != null)
                        {

                            var aosObjectWithImage = point.SelectToken("view");
                            if (aosObjectWithImage != null)
                            {
                                if (aosObjectWithImage.SelectToken("apiId") != null)
                                {
                                    name = aosObjectWithImage.SelectToken("apiId").ToString();
                                    ActivateByNameEvent?.Invoke(name, "", "");
                                    Debug.Log("NAME" + name);
                                }

                            }


                        }

                    }

                    updatePlace(places);
                }

            }

        }
        



    }

    [AosAction(name: "Обновить место")]

    public void updatePlace(JArray data)
    {
      
        StartUpdatePlaceEvent?.Invoke();

        foreach (JObject item in data)
        {
            string pointId = "";
            string pointActionName = "";
            if (item != null)
            {
                var apiIdParent2 = item.SelectToken("points");
                if (apiIdParent2 != null)
                {  
                    foreach (JObject point1 in apiIdParent2)
                    {
                        var apiIdParent = point1.SelectToken("apiId");

                        if (apiIdParent != null)
                        {
                            var apiIdParentText = apiIdParent.ToString();
                            ActivatePointByNameEvent?.Invoke(apiIdParentText, "OnClick");
                        }
                        Debug.Log(" View point" + point1.ToString());
                        var jsonView = point1.SelectTokens("view");
                        if (jsonView != null)
                        {
                           
                            foreach (var tempView in jsonView)
                            {
                              
                                if (tempView.SelectToken("apiId") != null)
                                {
                                    var pointTempView = tempView.SelectToken("apiId").ToString();
                                   
                                    ActivatePointByNameEvent?.Invoke(pointTempView, pointActionName);
                                }
                            }
                        }
                        var childs = point1.SelectTokens("childs");
                        if (childs != null)
                        {
                            foreach (var apiId in childs)
                            {
                                if (apiId != null)
                                {
                                    JArray tempArr = (JArray)apiId;
                                    foreach (var temp in tempArr)
                                    {
                                        var pointOpbject = temp.SelectToken("apiId");
                                        if (pointOpbject != null)
                                            pointId = pointOpbject.ToString();
                                        var tempViews = temp.SelectTokens("view");
                                        if (tempViews != null)
                                        {
                                            foreach (var tempView in tempViews)
                                            {
                                                if (tempView.SelectToken("apiId") != null)
                                                {
                                                    var pointTempView = tempView.SelectToken("apiId").ToString();
                                                    ActivatePointByNameEvent?.Invoke(pointTempView, pointActionName);
                                                    
                                                }
                                            }
                                        }
                                        if (temp.SelectTokens("hands") != null)
                                        {
                                            var points = temp.SelectTokens("hands");
                                            foreach (var point in points)
                                            {
                                                var pointName = (JArray)point;
                                                if (pointName != null)
                                                    foreach (var pnt in pointName)
                                                    {
                                                        var ptnObject = pnt.SelectToken("action");
                                                        if (ptnObject != null)
                                                        {
                                                            pointActionName = ptnObject.ToString();
                                                            ActivatePointByNameEvent?.Invoke(pointId, pointActionName);
                                                           
                                                        }
                                                    }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    //я реально старался, но приходящий Json это каша сраная необрабатываемая
    private JArray GetIds(JArray array, string searchingValue, List<string> result)
    {
        if (!isArray(array))
        {
            string value = array.SelectToken(searchingValue).ToString();
            if (value == null)
                return null;
            else
            {
                result.Add(value);
            }
        }
        else
        {
            foreach (var item in array)
            {
                var value = array.SelectToken(searchingValue);
                result.Add(value.ToString());
                GetIds((JArray)item, searchingValue, result);
            }
        }
        return null;
    }
    private bool isArray(JToken jObject)
    {
        var tempList = jObject.ToList();
        bool result = tempList.Count > 1;
        return result;
    }

    [AosAction(name: "Показать реакцию")]
    public void showReaction(JObject info, JObject nav)
    {
        if (info.SelectToken("text") != null)
        {
            var reactionText = info.SelectToken("text").ToString();
            ReactionEvent?.Invoke(reactionText);
            Debug.Log(reactionText + "Reaction");
        }
    }
    [AosAction(name: "Показать точки")]
    public void showPoints(string info, JArray data)
    {
        // EnableMovingButtonEvent?.Invoke(null, null);  зачем??
        foreach (JObject item in data)
        {
            if (item == null)
                return;
            if (item.SelectToken("tool") != null && item.SelectToken("name") != null)
            {
                string id = item.SelectToken("tool").ToString();
                string text = item.SelectToken("name").ToString();
                EnableMovingButtonEvent?.Invoke(id, text);
            }

            if (item.SelectToken("apiId") != null)
            {
                var point = item.SelectToken("apiId").ToString();
                var name = item.SelectToken("name").ToString();
                PointEvent?.Invoke(point, name);
            }
        }
    }

    [AosAction(name: "Показать реакцию")]
    public void showTime(string time)
    {
        SetTimerTextEvent?.Invoke(time);
    }

    [AosAction(name: "Показать меню")]
    public void showMenu(JObject data)
    {      
        if (data.SelectToken("algs") != null && data.SelectToken("algs").ToString() != String.Empty) { ShowMenuButtonEvent?.Invoke(); }
        string exitSureText = data.SelectToken("exitInfo").SelectToken("quest").ToString();

        var fltInfo = data.SelectToken("fltInfo");
        if (fltInfo != null)
        {
            string headtext = fltInfo.SelectToken("name").ToString();
            string commentText = fltInfo.SelectToken("text").ToString();
            ShowMenuTextEvent?.Invoke(headtext, commentText, exitSureText);
        }
        var exitInfo = data.SelectToken("exitInfo");
        if (exitInfo.SelectToken("text") != null && exitInfo.SelectToken("warn") != null)
        {
            string exitText = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("text").ToString());
            string warntext = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("warn").ToString());
            ShowExitTextEvent?.Invoke(exitText, warntext);
        }
    }
    [AosAction(name: "Показать сообщение")]
    public void showMessage(JObject info, JObject nav)
    {

        string footerText = "";
        var header = info.SelectToken("header");
        var footer = info.SelectToken("footer");
        var comment = info.SelectToken("text");
        var alarm = info.SelectToken("alarm");
        if (header != null && footer != null && comment != null && alarm != null)
        {
            Debug.Log("1");
            footerText = HtmlToText.Instance.HTMLToTextReplace(footer.ToString());
            string commentText = HtmlToText.Instance.HTMLToTextReplace(comment.ToString());
            string headText = header.ToString();
            string alarmImg = alarm.ToString();
            SetMessageTextEvent?.Invoke(headText, footerText, commentText, alarmImg);
        }
        else if (header != null && comment != null && alarm != null)
        {
            Debug.Log("2");
            string commentText = HtmlToText.Instance.HTMLToTextReplace(comment.ToString());
            string headText = header.ToString();
            string alarmImg = alarm.ToString();
            SetMessageTextEvent?.Invoke(headText, footerText, commentText, alarmImg);
        }
        else if (comment != null)
        {
            string headText = "";
            Debug.Log("3");
            string commentText = HtmlToText.Instance.HTMLToTextReplace(comment.ToString());
            footerText = "";
            var heade = info.SelectToken("header");
            if (heade != null)
            {
                headText = heade.ToString();
            }

            string alarmImg = "none";
            SetMessageTextEvent?.Invoke(headText, footerText, commentText, alarmImg);
        }
    }
    [AosAction(name: "Показать сообщение")]
    public void showResult(JObject info, JObject nav)
    {
        string resultText = "";
        Debug.Log("RESULT " + info.ToString());
        string headText = info.SelectToken("name").ToString();
        string commentText = HtmlToText.Instance.HTMLToTextReplace(HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString()));
        string evalText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("eval").ToString());
        SetResultTextEvent?.Invoke(headText, commentText, evalText);
        var result = info.SelectToken("result");


        if (result != null)
        {
            foreach (JObject item in result)
            {
                resultText = "";
                var name = item.SelectToken("name").ToString();
                var penalty = item.SelectToken("penalty").ToString();
                var msg = item.SelectToken("msg");
                if (msg == null)
                {
                    ResultNameTextButtonSingleEvent?.Invoke(name, penalty);
                }
                else
                {

                    foreach (var item2 in msg)
                    {
                        var message2 = item2.SelectToken("msg");
                        var name2 = item2.SelectToken("name");
                        if (message2 != null && name2 != null)
                        {
                            resultText += name2.ToString() + message2.ToString();
                        }
                        else
                        {
                            resultText += HtmlToText.Instance.HTMLToTextReplace(item2.ToString()) + "\n";
                        }
                    }
                    ResultNameTextButtonEvent?.Invoke(name, penalty, resultText);
                }
            }
        }
    }
    public void OnReasonInvoke(string name)
    {
        OnReason?.Invoke(name);
    }
    public void OnMenuInvoke()
    {
        OnMenu?.Invoke();
    }
    public void OnDialogInvoke(string name)
    {
        OnDialogPoint?.Invoke(name);
    }
    public void InvokeEndTween(string location)
    {
        EndTween?.Invoke(location);
    }
}
