using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule;
using AosSdk.Core.Utils;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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
    public UnityAction<string, string> AddTextObjectUiButtonEvent;
    public UnityAction<string, string> PointEvent;
    public UnityAction<string, string> EnableMovingButtonEvent;
    public UnityAction<string, string> ActivateByNameEvent;
    public UnityAction<string, string> SetMessageTextEvent;
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
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        SetStartTextEvent?.Invoke(headerText, commentText, buttonText, NextButtonState.Start);
        SetTeleportLocationEvent?.Invoke("start");
    }
    [AosAction(name: "Показать информацию отказа")]
    public void showFaultInfo(JObject info, JObject nav)
    {
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        SetStartTextEvent?.Invoke(headerText, commentText, buttonText, NextButtonState.Fault);
    }

    public void showDialog(JObject info, JArray points, JObject nav)
    {
        var dude = info.SelectToken("name");
        if (dude != null)
        {
            var header = dude.ToString();
            DialogHeaderEvent?.Invoke(header);
        }
        foreach (var item in points)
        {
            var action = item.SelectToken("action").ToString();
            Debug.Log("Action " + action);
            if (action != null)
                DialogEvent?.Invoke(action);
            var id = item.SelectToken("apiId").ToString();
            var name = item.SelectToken("name").ToString();
            if (id != null && name != null)
                AddTextObjectUiButtonEvent?.Invoke(id, name);
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
    public void ConnectionEstablished(string currentLocation)
    {
        EndTween?.Invoke(currentLocation);
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
        foreach (JObject item in data)
        {
            var temp = item.SelectToken("apiId");
            if (temp != null)
            {
                ActivateByNameEvent?.Invoke(temp.ToString(), item.SelectToken("name").ToString());
                Debug.Log(temp.ToString() + " ТЭГ " + item.SelectToken("name").ToString() + "Имя");
            }
            if (item.SelectToken("view") != null)
            {
                var aosObjectWithImage = item.SelectToken("view");
                if (aosObjectWithImage != null)
                {

                    if (aosObjectWithImage.SelectToken("apiId") != null)
                    {
                        string name = aosObjectWithImage.SelectToken("apiId").ToString();
                        ActivateByNameEvent?.Invoke(name, "");
                    }
                }
            }
        }
        if (nav.SelectToken("back") != null && nav.SelectToken("back").SelectToken("action") != null && nav.SelectToken("back").SelectToken("action").ToString() != String.Empty)
            ActivateBackButtonEvent?.Invoke(nav.SelectToken("back").SelectToken("action").ToString());
    }
    [AosAction(name: "Обновить место")]
    public void updatePlace(JArray data, string snd)
    {
        foreach (JObject item in data)
        {
            if (item != null)
            {
                var childs = item.SelectTokens("childs");
                if(childs!=null)
                {
                    foreach (var apiId in childs)
                    {
                        if(apiId!=null)
                        {
                            JArray tempArr = (JArray)apiId;
                            foreach (var temp in tempArr)
                            {
                                var pointOpbject = temp.SelectToken("apiId");
                                if(pointOpbject!=null)
                                    Debug.Log("point id "+ pointOpbject.ToString());
                                if(temp.SelectTokens("hands")!=null)
                                {
                                    var points = temp.SelectTokens("hands");
                                    foreach (var point in points)
                                    {
                                        Debug.Log("points " + point);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
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
                Debug.Log(item.SelectToken("tool").ToString() + " API Show points");
                if (item.SelectToken("tool").ToString() == "eye")
                {
                    string eye = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(eye, text);
                }
                if (item.SelectToken("tool").ToString() == "eye_1")
                {
                    string eye = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(eye, text);
                }
                if (item.SelectToken("tool").ToString() == "eye_2")
                {
                    string eye = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(eye, text);
                }
                if (item.SelectToken("tool").ToString() == "hand")
                {
                    string hand = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(hand, text);
                }
                if (item.SelectToken("tool").ToString() == "hand_1")
                {
                    string hand = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(hand, text);
                }
                if (item.SelectToken("tool").ToString() == "hand_2")
                {
                    string hand = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(hand, text);
                }
                if (item.SelectToken("tool").ToString() == "hand_3")
                {
                    string hand = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(hand, text);
                }
                if (item.SelectToken("tool").ToString() == "hand_4")
                {
                    string hand = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(hand, text);
                }
                if (item.SelectToken("tool").ToString() == "tool")
                {
                    string tool = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(tool, text);
                }
                if (item.SelectToken("tool").ToString() == "tool_1")
                {
                    string tool = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(tool, text);
                }
                if (item.SelectToken("tool").ToString() == "pen")
                {
                    string pen = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(pen, text);
                }
                if (item.SelectToken("tool").ToString() == "pen_1")
                {
                    string pen = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableMovingButtonEvent?.Invoke(pen, text);
                }
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
        Debug.Log($"Show message text event headText: {headtext} comment text: {commentText} exutSureText: {exitSureText}");
        if (exitInfo.SelectToken("text") != null && exitInfo.SelectToken("warn") != null)
        {
            string exitText = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("text").ToString());
            string warntext = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("warn").ToString());
            ShowExitTextEvent?.Invoke(exitText, warntext);
            Debug.Log($"Show exit text event exit text: {exitText} warn text: {warntext} ");
        }
    }
    [AosAction(name: "Показать сообщение")]
    public void showMessage(JObject info, JObject nav)
    {
        string headText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        SetMessageTextEvent?.Invoke(headText, commentText);
        Debug.Log($"Show message text event head text: {headText} comment text: {commentText} ");
    }
    [AosAction(name: "Показать сообщение")]
    public void showResult(JObject info, JObject nav)
    {
        string headText = info.SelectToken("name").ToString();
        string commentText = HtmlToText.Instance.HTMLToTextReplace(HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString()));
        string evalText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("eval").ToString());
        SetResultTextEvent?.Invoke(headText, commentText, evalText);
        Debug.Log($"Show result text event head text: {headText} comment text: {commentText} eval text: {evalText}");
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
}
