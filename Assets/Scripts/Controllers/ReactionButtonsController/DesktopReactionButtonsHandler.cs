using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DesktopReactionButtonsHandler : BaseReactionButtonsHandler
{
    [SerializeField] private GameObject _prefub;
    [SerializeField] private Transform _parent;
    private SceneAosObject _currentAosObject;
    public static DesktopReactionButtonsHandler Instance;
    private List<ReactionUIButton> _reactionButtons;
    private List<GameObject> _prefabs;
    protected override void Start()
    {
        base.Start();
        if(Instance == null)
        {
            Instance = this;
        }
        _reactionButtons = new List<ReactionUIButton>();
        _prefabs = new List<GameObject>();
    }
    public override void ShowReactionButtonByName(string buttonActionName, string buttonText)
    {
        if (string.IsNullOrWhiteSpace(buttonActionName) || ButtonsSpawnPos == null)
            return;
      
        _parent.position = ButtonsSpawnPos;
        if(_parent.position.x < 200)
        {
            _parent.position = new Vector3(220,_parent.position.y,_parent.position.y);
        }
        if(_parent.position.y < 33)
        {
            _parent.position = new Vector3(_parent.position.x, 50, _parent.position.y);
        }
        
        ButtonActionName reactionName;
        Enum.TryParse<ButtonActionName>(buttonActionName, out reactionName);
       // if (ContainsObject(reactionName))                
         //   HideAllReactions();               
        _currentAosObject = SceneObjectsHolder.Instance.SceneAosObject;
        var prefub = Instantiate(_prefub, _parent);
        var reactionButton = prefub.GetComponentInChildren<ReactionUIButton>();
        reactionButton.Init(reactionName, buttonText, _currentAosObject);
        _prefabs.Add(prefub);
        _reactionButtons.Add(reactionButton);
       
    }
    public override void HideAllReactions()
    {
       
        foreach (var reactionButton in _reactionButtons)
        {
            if (reactionButton != null)
                Destroy(reactionButton.gameObject);
        }
        foreach (var prefab in _prefabs)
        {
            if (prefab != null)
                Destroy(prefab);
        }
        _reactionButtons = new List<ReactionUIButton>();
        _prefabs = new List<GameObject>();
        _currentAosObject = null;
    }
    private bool ContainsObject(ButtonActionName buttonActionName)
    {              
        var containsObject = _reactionButtons.SingleOrDefault(b => b.ButtonActionName == buttonActionName);
        if (containsObject != null)
            return true;
        return false;
    }
}


