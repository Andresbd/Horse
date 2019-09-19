using UnityEngine;

public class CreateBoard : MonoBehaviour
{

    public GameObject white, black;
    // Start is called before the first frame update
    void Start()
    {
        int cont = 0;

        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if (cont % 2 == 0)
                {
                    black = Instantiate(black, new Vector3(x, 0, y), Quaternion.identity);
                    black.transform.parent = transform;
                    cont++;
                }
                else
                {
                    white = Instantiate(white, new Vector3(x, 0, y), Quaternion.identity);
                    white.transform.parent = transform;
                    cont++;
                }

            }
            cont++;
        }
    }
}
