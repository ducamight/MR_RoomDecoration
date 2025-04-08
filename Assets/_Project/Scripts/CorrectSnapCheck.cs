using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectSnapCheck : MonoBehaviour
{
    public SnapInteractable correctInteractable;
    private SnapInteractor snapInteractor;
    [SerializeField] private Transform FXPoint;
    public GameObject FXPrefab;

    private void Awake()
    {
        snapInteractor = GetComponentInChildren<SnapInteractor>();
    }
    private void Start()
    {
        snapInteractor.WhenInteractableSelected.Action += InteractableSelected;
        snapInteractor.WhenInteractableUnselected.Action += InteractableUnselected;
    }
    private void InteractableSelected(SnapInteractable interactable)
    {
        Debug.Log("Interactable Select");

        if (interactable == correctInteractable)
        {
            Debug.Log("Interactable Selct when correct interactable is selected");

            GameManager.Instance.SnapCorrect();
            GameManager.Instance.WinGame();
            AudioManager.Instance.Play("SoftButton");
            FXManager.Instance.PlayFX(FXPrefab, FXPoint.position, 2f);
        }
    }

    private void InteractableUnselected(SnapInteractable interactable)
    {
        Debug.Log("Interactable Unselect");

        if (interactable == correctInteractable)
        {
            Debug.Log("Interactable Unselect when correct interactable is selected");
            GameManager.Instance.SnapUnCorrect();
        }
    }
}
