using UnityEngine;

public class Instantiation : MonoBehaviour
{
    [SerializeField] private GameObject objectToInstantiate;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        }
    }
}
