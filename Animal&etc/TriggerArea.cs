using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerArea : XRBaseInteractor
{
    private XRBaseInteractable curuentInteractable = null;


    private bool TryGetInteractable(Collider colider, out XRBaseInteractable interacterble)
    {
        interacterble = interactionManager.GetInteractableForCollider(colider);
        return interacterble != null;
    }


    public override void GetValidTargets(List<XRBaseInteractable> targets)
    {
        targets.Clear();
        targets.Add(curuentInteractable);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");
        SetInteractable(other);
    }

    private void SetInteractable(Collider other)
    {
        if(TryGetInteractable(other,out XRBaseInteractable interactable))
        {
            if (curuentInteractable == null)
            {
                Debug.Log("3");
                curuentInteractable = interactable;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("2");
        ClearInteractable(other);
    }

    private void ClearInteractable(Collider other)
    {
        if(TryGetInteractable(other, out XRBaseInteractable interactable))
        {
            if (curuentInteractable == interactable)
                curuentInteractable = null;
        }
    }


    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && curuentInteractable == interactable && !interactable.isSelected;
       // return base.CanHover(interactable) && curuentInteractable == interactable;
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return false;
    }

}
