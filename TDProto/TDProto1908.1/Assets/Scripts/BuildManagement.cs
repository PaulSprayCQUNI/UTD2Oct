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
    private NodeBehavior selectedNode;

    public TurretSelectionUI turretSelectUI;

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

    /*
     * Code previously using an instance of NodeBehaviour as a parameter and referencing
     * turretToBuild in this class are moved to NodeBehavior
     * old function header was public void BuildTurretOn(NodeBehavior node)  {...}
     */

    /* the following two functions are written so that when one is enabled,
     the other is disabled so only a node, with a built turret on it, or a turret 
     selected to be built on a node is selected at one time*/

    public void SelectNode(NodeBehavior node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        turretSelectUI.SelectionTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        turretSelectUI.Hide();

    }

    public void SelectTurretToBuild(TurretSchema turret)
    {
        turretToBuild = turret;
        DeselectNode();
        
    }

    public TurretSchema GetTurretToBuild()
    {
        return turretToBuild;
    }

  

}
