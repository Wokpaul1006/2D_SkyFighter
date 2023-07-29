using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSC : MonoBehaviour
{
    [SerializeField] Kamikaze kmkz;
    [SerializeField] LinearPerShot per;
    [SerializeField] DualShot dual;
    [SerializeField] TripleShot triple;
    [SerializeField] ChronoShip chrono;
    [SerializeField] BouncingShip bounce;
    [SerializeField] RandomPathShip rand;

    public void SpawnKamikaze()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(kmkz, new Vector3(randomX, 5, 0), Quaternion.Euler(0, 0, -90f));
        Invoke("SpawnKamikaze", 0.5f);
    }

    public void SpawnPerShot()
    {
        //Correct
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(per, new Vector3(randomX, 5, 0), Quaternion.Euler(0, 0, 0f));
        Invoke("SpawnPerShot", 1.25f);
    }

    public void SpawnDualShot()
    {
        //Correct
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(dual, new Vector3(randomX, 5, 0), Quaternion.Euler(0, 0, -90f));
        Invoke("SpawnDualShot", 1.5f);
    }

    public void SpawnConeShot()
    {
        //Correct
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(triple, new Vector3(randomX, 5, 0), Quaternion.Euler(0, 0, -90f));
        Invoke("SpawnConeShot", 1.75f);
    }

    public void SpawnDiagonal()
    {
        //Correct
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(bounce, new Vector3(randomX, 5, 0), Quaternion.Euler(0, 0, 0f));
        Invoke("SpawnDiagonal", 1f);
    }
    public void SpawnRandom()
    {
        //Incorrect
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(rand, new Vector3(randomX, 5, 0), Quaternion.Euler(0, 0, 0f));
        Invoke("SpawnRandom", 2.25f);
    }

    public void SpawnChrono()
    {
        //Correct
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(chrono, new Vector3(randomX, 5, 0), Quaternion.Euler(0, 0, 0f));
        Invoke("SpawnChrono", 2.5f);
    }
}
