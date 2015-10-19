using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

    public GameObject cube;
    Vector3 cubePosition = new Vector3(32.71f, 6.9f, 19.4f);
    void OnTriggerEnter(Collider other)
    {
        // destroy all game objects that enter this area
        Destroy(other.gameObject);
        //StartCoroutine("RespawnCube");
        //Application.LoadLevel(Application.loadedLevel);
      

    }
    /*IEnumerator RespawnCube()
    {

        cube = (GameObject)Instantiate(cube, cubePosition, Quaternion.identity) as GameObject;
        Destroy(cube.gameObject);
        yield return null;
    }*/


}
