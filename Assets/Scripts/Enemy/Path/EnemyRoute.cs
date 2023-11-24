using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoute : MonoBehaviour
{
    public List<EnemyRoute> AdjoiningRoute;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos(){
        Gizmos.DrawIcon(gameObject.transform.position, "Route.png", false);
    }

    void OnDrawGizmosSelected() {
        
        Gizmos.color = Color.red;
        if(AdjoiningRoute != null){
            if(AdjoiningRoute.Count >= 1){
                foreach(var i in AdjoiningRoute){
                    Gizmos.DrawLine(gameObject.transform.position, i.transform.position);
                }
            }
        }
	}
}
