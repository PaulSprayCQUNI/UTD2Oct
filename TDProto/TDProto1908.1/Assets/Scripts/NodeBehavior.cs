using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeBehavior : MonoBehaviour
{

	public Color hoverColor;
    public Color notEnoughCredColor;
	public Vector3 positionOffset;

    // GameObject made public for option of turrets in place before Start(), per BuildManagement function

    [HideInInspector]
    public GameObject turret;

    [HideInInspector]
    public TurretSchema turretSchema;

    [HideInInspector]
    public Boolean isUpgraded = false;


    /* avoid having all nodes storing their own reference to BuildManagement, 
	instead make it available via a Singleton pattern to make access of an instance of the BuildManagement easier
	*/

    private Renderer rend;
	private Color initColor;

    private BuildManagement buildManagement;

    // Start is called before the first frame update
    void Start()
    {

	rend = GetComponent<Renderer>();
	initColor = rend.material.color;

    buildManagement = BuildManagement.instance;
        
    }

    // helper function called in BuildManagement
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

	void OnMouseDown ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(turret != null)
		{
			buildManagement.SelectNode(this);
			return;
		}

    // changed call to condition check in BuildManagement class to call a property in same class
    // same applied to MouseEnter

        if (!buildManagement.CanBuild)
            return;
    /* 1st October replaced instantiation based on condition of turret == null with function
     called within BuildManagement, replaced again with a call to new function BuildTurret()
     with a parameter of GetTurretToBuild() from BuildManagement
    */

        BuildTurret(buildManagement.GetTurretToBuild());
    }

    void BuildTurret(TurretSchema schema)
    {
        if (PlayerStats.Creds < schema.schemaCost)
        {
            Debug.Log("Not enough creds to build that!");
            return;
        }

        PlayerStats.Creds -= schema.schemaCost;

    /* making distinctions between local field variables and instantiations of the class's
     public gameobject variable was something I learned I needed practice to recognise*/

        GameObject _turret = (GameObject)Instantiate(schema.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretSchema = schema;

        GameObject effect = (GameObject)Instantiate(buildManagement.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        
        Debug.Log("Turret Built!");
    }


    public void UpgradeTurret()
    {
        if (PlayerStats.Creds < turretSchema.upgradeCost)
        {
            Debug.Log("Not enough creds to upgrade!");
            return;
        }

        PlayerStats.Creds -= turretSchema.upgradeCost;

        //remove old turret before instantiating new one
        Destroy(turret);

        /* making distinctions between local field variables and instantiations of the class's
         public gameobject variable was something I learned I needed practice to recognise*/

        // instantiate upgraded Turret
        GameObject _turret = (GameObject)Instantiate(turretSchema.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManagement.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        isUpgraded = true;
        Debug.Log("Turret Upgraded!");
    }

    public void SellTurret()
    {
	    PlayerStats.Creds += turretSchema.GetSellAmount();

		// sell effect - todo
	    Destroy(turret);
	    turretSchema = null;
    }

	void OnMouseEnter ()
	{

        if (EventSystem.current.IsPointerOverGameObject())
            return;
      
        if (!buildManagement.CanBuild)
            return;

        if (buildManagement.HasCreds)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = notEnoughCredColor;
        }

	}
   
   void OnMouseExit ()
   {
   	   rend.material.color = initColor;	 
   }
}
