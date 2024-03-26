using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule;
using AosSdk.Core.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public enum NextButtonState
{
    Start,
    Fault
}
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
    public UnityAction<string> DialogEvent;
    public UnityAction<string> DialogHeaderEvent;
    public UnityAction<string> SetTeleportLocationEvent;
    public UnityAction<string> SetNewLocationTextEvent;
    public UnityAction<string> SetLocationEvent;
    public UnityAction<string> ActivateBackButtonEvent;
    public UnityAction<string> EnableDietButtonsEvent;
    public UnityAction<string> SetTimerTextEvent;
    public UnityAction<string> ReactionEvent;  
    public UnityAction<string, DialogRole> AddTextObjectUiEvent;
    public UnityAction<string,string,string> ResultNameTextButtonEvent;
    public UnityAction<string,string> ResultNameTextButtonSingleEvent;
    public UnityAction<string, string> AddTextObjectUiButtonEvent;
    public UnityAction<string, string> PointEvent;
    public UnityAction<string, string> EnableMovingButtonEvent;
    public UnityAction<string, string,string> ActivateByNameEvent;
    public UnityAction<string, string> ActivatePointByNameEvent;
    public UnityAction<string, string,string,string> SetMessageTextEvent;
    public UnityAction<string, string, string> SetResultTextEvent;
    public UnityAction<string, string> ShowExitTextEvent;
    public UnityAction<string, string, string> ShowMenuTextEvent;
    public UnityAction<string, string, string, NextButtonState> SetStartTextEvent;

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
    public void showWelcome(JObject info, JObject nav)
    {
        JsonConverter<AosTextModel> aosWelcomeText = new JsonConverter<AosTextModel>(info);
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        var welcomeObj = aosWelcomeText.JsonObject;
        SetStartTextEvent?.Invoke(welcomeObj.Header, welcomeObj.Text, buttonText, NextButtonState.Start);
        SetTeleportLocationEvent?.Invoke("start");
        
    }
    [AosAction(name: "Показать информацию отказа")]
    public void showFaultInfo(JObject info, JObject nav)
    {
        JsonConverter<AosTextModel> aosWelcomeText = new JsonConverter<AosTextModel>(info);
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        var welcomeObj = aosWelcomeText.JsonObject;
        SetStartTextEvent?.Invoke(welcomeObj.Header, welcomeObj.Text, buttonText, NextButtonState.Fault);
        
    }

    public void showDialog(JObject info, JArray points, JObject nav)
    {
      //  Debug.Log("INFOOO   " + info.ToString());
      //  Debug.Log("POINTS  "+ points.ToString());
        var dude = info.SelectToken("name");
        if (dude != null)
        {
            var header = dude.ToString();
            DialogHeaderEvent?.Invoke(header);           
        }
        foreach (var item in points)
        {
            var action = item.SelectToken("action").ToString();          
            if (action != null)
                DialogEvent?.Invoke(action);
            var id = item.SelectToken("apiId").ToString();
            var name = item.SelectToken("name").ToString();
            if (id != null && name != null)
                AddTextObjectUiButtonEvent?.Invoke(id, name);
            Debug.Log("APIII " + name);
            
        }
        var outMsg = info.SelectToken("out_msg");
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
    public void addDialogMessage(JArray message)
    {
        Debug.Log("MESS  "+ message.ToString());
        
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
    public void showPlace(JObject place, JArray data, JObject nav)
    {
        string location = place.SelectToken("apiId").ToString();
        SetLocationEvent?.Invoke(location);
        if (place.SelectToken("name") != null)
        {
            SetNewLocationTextEvent?.Invoke(place.SelectToken("name").ToString());
        }
        ShowPlaceEvent?.Invoke();
        JsonConverter<AosObjectModel> converter = new JsonConverter<AosObjectModel>(data);
        foreach (var jItem in converter.JsonArray)
            ActivateByNameEvent?.Invoke(jItem.Id, jItem.Name,"");
        foreach (JObject item in data)
        {
            if (item.SelectToken("view") != null)
            {
                var aosObjectWithImage = item.SelectToken("view");
                if (aosObjectWithImage != null)
                {

                    if (aosObjectWithImage.SelectToken("apiId") != null)
                    {
                        string name = aosObjectWithImage.SelectToken("apiId").ToString();
                        ActivateByNameEvent?.Invoke(name, "","");
                    }
                }
            }
            updatePlace(data, "");
        }
        if (nav.SelectToken("back") != null && nav.SelectToken("back").SelectToken("action") != null && nav.SelectToken("back").SelectToken("action").ToString() != String.Empty)
            ActivateBackButtonEvent?.Invoke(nav.SelectToken("back").SelectToken("action").ToString());
    }
    [AosAction(name: "Обновить место")]
    public void updatePlace(JArray data, string snd)
    {
        StartUpdatePlaceEvent?.Invoke();
        foreach (JObject item in data)
        {
            string pointId = "";
            string pointActionName = "";
            if (item != null)
            {
                var apiIdParent = item.SelectToken("apiId");
                if (apiIdParent != null)
                {
                    var apiIdParentText = apiIdParent.ToString();
                    ActivatePointByNameEvent?.Invoke(apiIdParentText, "OnClick");
                }

                var jsonView = item.SelectTokens("view");
                if (jsonView != null)
                {
                    foreach (var tempView in jsonView)
                    {
                        if (tempView.SelectToken("apiId") != null)
                        {
                            var pointTempView = tempView.SelectToken("apiId").ToString();
                            Debug.Log(pointTempView + " View point");
                            ActivatePointByNameEvent?.Invoke(pointTempView, pointActionName);
                        }
                    }
                }
                var childs = item.SelectTokens("childs");
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
        EnableMovingButtonEvent?.Invoke(null, null);
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
    public void showMenu(JObject faultInfo, JObject exitInfo, JObject resons)
    {
        string headtext = faultInfo.SelectToken("name").ToString();
        string commentText = faultInfo.SelectToken("text").ToString();
        string exitSureText = exitInfo.SelectToken("quest").ToString();
        ShowMenuTextEvent?.Invoke(headtext, commentText, exitSureText);
        if (exitInfo.SelectToken("text") != null && exitInfo.SelectToken("warn") != null)
        {
            string exitText = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("text").ToString());
            string warntext = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("warn").ToString());
            ShowExitTextEvent?.Invoke(exitText, warntext);
        }
    }
    [AosAction(name: "Показать сообщение")]
    public void showMessage(JObject info, JObject nav)
    {Debug.Log("MESSAGE" + info.ToString());
        string footerText = ""; 
        var header = info.SelectToken("header");
        var footer = info.SelectToken("footer");       
        var comment = info.SelectToken("text");
        var alarm = info.SelectToken("alarm");
        if (header != null && footer != null && comment != null && alarm != null)
        {
            footerText = HtmlToText.Instance.HTMLToTextReplace(footer.ToString());
            string commentText = HtmlToText.Instance.HTMLToTextReplace(comment.ToString());
            string headText = header.ToString();
            string alarmImg = alarm.ToString();
            SetMessageTextEvent?.Invoke(headText, footerText, commentText, alarmImg);
        }
        else if (header != null && comment != null && alarm != null)
        {
            
            string commentText = HtmlToText.Instance.HTMLToTextReplace(comment.ToString());
            string headText = header.ToString();
            string alarmImg = alarm.ToString();
            SetMessageTextEvent?.Invoke(headText, footerText, commentText, alarmImg);
        }
        else if(comment != null)
        {
            string commentText = HtmlToText.Instance.HTMLToTextReplace(comment.ToString());
             footerText = "";
            string headText = "";
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
                else {                                                                
                    
                    foreach(var item2 in msg)
                    {
                        var message2 = item2.SelectToken("msg");
                        var name2 = item2.SelectToken("name");
                        if(message2 != null && name2 != null)
                        {
                            resultText += name2.ToString()+ message2.ToString() ;
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
