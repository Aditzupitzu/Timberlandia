using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject[] treePrefabs;
    private int numberOfTrees = 1500;

    public void Start()
    {
        SpawnTrees(numberOfTrees);
    }

    public void SpawnTrees(int numberOfTrees)
    {
        for (int i = 0; i < numberOfTrees; i++)
        {
            Vector3 spawnPosition;
            bool positionOccupied;

            do
            {
                spawnPosition = new Vector3(Random.Range(-500f, 500f), 100f, Random.Range(-500f, 500f)); // Genereaza o locatie de spawn aleatorie
                RaycastHit hit;
                Ray ray = new Ray(spawnPosition + Vector3.up * 10f, Vector3.down * 20f); // Cast a ray downwards from above the spawn position
                positionOccupied = Physics.Raycast(ray, out hit, 20f) && hit.collider.CompareTag("Tree");

            } while (positionOccupied); // Repeta pana nu mai este ocupata pozitia.
            Quaternion spawnRotation = Quaternion.Euler(Random.Range(1f, 15f), Random.Range(0f, 360f), Random.Range(1f, 15f));

            GameObject treePrefabToSpawn = treePrefabs[Random.Range(0, treePrefabs.Length)];
            GameObject tree = Instantiate(treePrefabToSpawn, spawnPosition, spawnRotation);
            TreeHealth treeStats = tree.GetComponentInChildren<TreeHealth>(); // Preia scriptul de la copilul "Trunk"
            tree.transform.localScale = Vector3.one * Random.Range(0.5f, 1.5f);
            float treeHealth = tree.transform.localScale.x * 100;
            treeStats.maxHealth = (int)treeHealth;
            RaycastHit groundHit;
            Ray groundRay = new Ray(tree.transform.position, Vector3.down);
            if (Physics.Raycast(groundRay, out groundHit))
            {
                Vector3 newPosition = new Vector3(tree.transform.position.x, groundHit.point.y, tree.transform.position.z); // Creaza un vector cu pozitia punctului de intersectie a razei cu pamantul
                tree.transform.position = newPosition; // Muta copacul in punctul de intersectie cu pamantul
            }
        }
    }
}