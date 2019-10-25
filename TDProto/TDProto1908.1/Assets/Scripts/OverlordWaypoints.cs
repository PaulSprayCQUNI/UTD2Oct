using UnityEngine;

public class OverlordWaypoints : MonoBehaviour
{
   //an array of game objects for Waypoints
   public static Transform[] olPoints;

   //load the points into the Transform [] array
   void Awake ()
   {
	   olPoints = new Transform[transform.childCount];
	for (int i = 0; i < olPoints.Length; i++) 
	{
		olPoints[i] = transform.GetChild(i);
	}

   }
   

}
