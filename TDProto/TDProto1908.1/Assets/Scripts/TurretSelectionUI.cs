
using UnityEngine;

public class TurretSelectionUI : MonoBehaviour
{
    public GameObject selectUI;

    private NodeBehavior target;

    public void SelectionTarget(NodeBehavior _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        selectUI.SetActive(true);
    }

    public void Hide()
    {
        selectUI.SetActive(false);}

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManagement.instance.DeselectNode();
    }
}
