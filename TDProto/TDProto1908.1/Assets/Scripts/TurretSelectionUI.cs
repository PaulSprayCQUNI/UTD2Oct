using UnityEngine.UI;
using UnityEngine;

public class TurretSelectionUI : MonoBehaviour
{
    public GameObject selectUI;

	public Text upgradeCost;
	public Button upgradeButton;
	
    private NodeBehavior target;

    public void SelectionTarget(NodeBehavior _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

		if(!target.isUpgraded)
		{
			upgradeCost.text = "$ " + target.turretSchema.upgradeCost;
			upgradeButton.interactable = true;
			
		} else
		{
			upgradeCost.text = "Maxed";
			upgradeButton.interactable = false;
		}
		
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
