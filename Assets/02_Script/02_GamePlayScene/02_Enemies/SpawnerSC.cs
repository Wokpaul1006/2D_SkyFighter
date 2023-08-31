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

    public IEnumerator SpawnEnemies(int enemiesOder)
    {
        yield return new WaitForSeconds(1);
        switch (enemiesOder) 
        {
            case 0:
                Kamikaze();
                break;
            case 1:
                Kamikaze(); 
                break;
            case 2:
                Pershot();
                break;
            case 3:
                Dualshot();
                break;
            case 4:
                Coneshot();
                break;
            case 5:
                DiagonalMover();
                break;
            case 6:
                Randompath();
                break;
            case 7:
                Chronoshift();
                break;
        }
        StartCoroutine(SpawnEnemies(1));
    }
    private void Kamikaze()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(kmkz, new Vector3(randomX, 3, 0), Quaternion.Euler(0, 0, -90f));
        Invoke("SpawnKamikaze", 0.5f);
    }
    private void Pershot()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(per, new Vector3(randomX, 3, 0), Quaternion.Euler(0, 0, 0f));
        Invoke("SpawnPerShot", 1.25f);
    }
    private void Dualshot()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(dual, new Vector3(randomX, 3, 0), Quaternion.Euler(0, 0, -90f));
        Invoke("SpawnDualShot", 1.5f);
    }
    private void Coneshot()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(triple, new Vector3(randomX, 3, 0), Quaternion.Euler(0, 0, -90f));
        Invoke("SpawnConeShot", 1.75f);
    }
    private void DiagonalMover()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(bounce, new Vector3(randomX, 3,0), Quaternion.Euler(0, 0, 0f)) ;
        Invoke("SpawnDiagonal", 1f);
    }
    private void Randompath()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(rand, new Vector3(randomX, 3, 0), Quaternion.Euler(0, 0, 0f));
        Invoke("SpawnRandom", 2.25f);
    }
    private void Chronoshift()
    {
        float randomX;
        randomX = Random.Range(-3, 3);
        Instantiate(chrono, new Vector3(randomX, 3, 0), Quaternion.Euler(0, 0, 0f));
        Invoke("SpawnChrono", 2.5f);
    }
}
