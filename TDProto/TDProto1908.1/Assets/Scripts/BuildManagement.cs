using UnityEngine;

public class BuildManagement : MonoBehaviour
{
    public int minCreds = 100;

	/* every time the game starts their will be one instance of BuildManagement 
	put into the instance variable and accessed from anywhere - important that we are only
	using one BuildManagement */

	public  static BuildManagement instance;
		
	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManagement instance in scene");
			return;	
		}
		instance = this;
	}

	public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    public GameObject buildEffect;

	
	private TurretSchema turretToBuild;

    // 1st October introducing a property of public bool variable called CanBuild
    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }

    public bool HasCreds
    {
        get { return PlayerStats.Creds >= turretToBuild.schemaCost; }   
    }

    public bool lowCreds
    {
        get { return PlayerStats.Creds <= minCreds; }
    }

    public void BuildTurretOn(NodeBehavior node)
    {

        if (PlayerStats.Creds < turretToBuild.schemaCost)
        {
            Debug.Log("Not enough creds to build that!");
            return;
        }

        PlayerStats.Creds -= turretToBuild.schemaCost;

        // todo - an object that follows the mouse pointer and displays an icon of the selected turret until instantiate occurs

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);
        
        
        Debug.Log("Turret Built, Creds remaining: " + PlayerStats.Creds);
    }

	public void SelectTurretToBuild(TurretSchema turret)
    {
        turretToBuild = turret;
    }

}
