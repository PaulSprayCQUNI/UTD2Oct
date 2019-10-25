using UnityEngine.UI;
using UnityEngine;

public class TurretSelectionUI : MonoBehaviour
{
    public GameObject selectUI;

	public Text upgradeCost;
	public Button upgradeButton;

	public Text sellValue;
	public Button SellButton;
	
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
		
		sellValue.text = "$" + target.turretSchema.GetSellAmount();
	    
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

    public void Sell()
    {
	    target.SellTurret();
	    BuildManagement.instance.DeselectNode();

    }

}
