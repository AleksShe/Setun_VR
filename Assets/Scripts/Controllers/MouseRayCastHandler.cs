using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using System;
using UnityEditor;
using UnityEngine;
public class MouseRayCastHandler : MonoBehaviour
{
    private InteractHand _interactHand;
    private Camera _currentCamera;
    private IHoverAble _currentHoverable;
    public Action<VectorHolder> MousePosHoverEvent;
    public Action<VectorHolder> MousePosClickEvent;
    private VectorHolder _mousePosHolder;
    public bool CanInteract { get; set; } = true;
    public bool CanHover { get; set; } = true;
    public void SetActionCamera(Camera camera) => _currentCamera = camera;
    private void Start()
    {
        _mousePosHolder = new VectorHolder();
    }
    private void Update()
    {
      
        if (_currentCamera == null || !CanInteract)
            return;
        var collisionObject = CheckRaycastCollider();
        if (Input.GetMouseButtonDown(0))
        {
            if (collisionObject.collider != null)
                CheckCollisionClick(collisionObject);
        }
        if (collisionObject.collider != null)
            CheckCollisionHover(collisionObject);
    }
    private RaycastHit CheckRaycastCollider()
    {
        Vector3 mousePos = Input.mousePosition;                      
        mousePos.z = 100f;
        mousePos = _currentCamera.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(_currentCamera.transform.position, mousePos - _currentCamera.transform.position, Color.blue);
        Ray ray = _currentCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            return hit;
        }
        return hit;
    }
    private void CheckCollisionClick(RaycastHit hit)
    {
        if (!CanHover)
            return;
        if (hit.collider.gameObject.TryGetComponent(out SceneObject sceneObject) ) //по клику если это сценобъект , то вызывается у сценобжекта онклик(из библиотеки)
        {
            sceneObject.OnClicked(_interactHand);
            if (sceneObject.NonAOS || sceneObject is BaseButton)
                return;
            _mousePosHolder.Position = new Vector2(Input.mousePosition.x, Input.mousePosition.y); // отправляем позицию мышки для создания кнопок
            MousePosClickEvent?.Invoke(_mousePosHolder);
        }
        else 
        {
            MousePosClickEvent?.Invoke(null); // если кликнули в пустоту , то кидаем null что бы закрыть все окна 
            CanHover = true;
        }
    }
    private void CheckCollisionHover(RaycastHit hit)
    {
        if (hit.collider.gameObject.TryGetComponent(out IHoverAble obj) && CanHover)
        {
            ResetHoverableObject();
            _currentHoverable = obj;
            _currentHoverable.OnHoverIn(_interactHand);
            _mousePosHolder.Position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            MousePosHoverEvent?.Invoke(_mousePosHolder);
        }
        else
        {
            ResetHoverableObject();
            MousePosHoverEvent?.Invoke(null);
            return;
        }
    }
    private void ResetHoverableObject()
    {
        if (_currentHoverable != null)
        {
            _currentHoverable.OnHoverOut(_interactHand);
            _currentHoverable = null;
        }
    }
    
}
