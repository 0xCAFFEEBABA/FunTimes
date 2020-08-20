using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string category;
        public Card prefab = ScriptableObject.CreateInstance<Card>();
        public int size;
    }
    
    /// <summary>
    /// A list that contains all Pool objects
    /// </summary>
    public List<Pool> pools = new List<Pool>();
    /// <summary>
    /// A dictionary for pools with key = string and value = queue
    /// </summary>
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    /// <summary>
    /// A dictionary of key = Data and value = Pool 
    /// It matches {category}Pool <see cref="Pool"/> to {category}Time <see cref="Data"/> 
    /// </summary>
    public Dictionary<Data, Pool> dataAndPools = new Dictionary<Data, Pool>();

    /// <summary>
    /// Creates a dictionary of <see cref="Data"/> and <see cref="Pool"/> that are matched by their category variable.
    /// Adds the images for dark and light theme's cards to the <see cref="Pool.prefab"/> accordingly.
    /// </summary>
    /// <returns></returns>
    public Dictionary<Data, Pool> CreateDataAndPoolsDictionary()
    {
        // For each and every pool in pools...
        foreach(Pool pool in pools)
        {
            // For each and every data in dataList...
            foreach(Data data in GlobalVariables.dataList)
            {
                // If the data's category matches the pool's category...
                if (data.Category == pool.category)
                {
                    // Adds the data and pool to the dictionary as key and value.
                    dataAndPools.Add(data, pool);
                    // Gets out of the loop.
                    break;
                }
            }
        }
        // For each and every KeyValuePair in the dictionary...
        foreach(KeyValuePair<Data, Pool> dataAndPool in dataAndPools)
        {
            // Sets the card's sprite of the dark theme to the data's dark themed image
            dataAndPool.Value.prefab.spiteDark = dataAndPool.Key.DarkImage;
            // Sets the card's sprite of the light theme to the data's light themed image
            dataAndPool.Value.prefab.spriteLight = dataAndPool.Key.LightImage;
        }
        // Returns the updated dictionary
        return dataAndPools;
    }

    /// <summary>
    /// It's called before the scene is loaded.
    /// Creates the Pool Objects and adds them to a list
    /// Gets the images from the Global Variables class
    /// Sets the <see cref="GlobalVariables.staticDataAndPools"/> to the returned dictionary of the <see cref="CreateDataAndPoolsDictionary"/> method
    /// </summary>
    public void Awake()
    {
        // Creates the Pool Object...
        // for Family
        Pool familyPool = new Pool() { category = "family", prefab = ScriptableObject.CreateInstance<Card>() };
        // for Sexy
        Pool sexyPool = new Pool() { category = "sexy", prefab = ScriptableObject.CreateInstance<Card>() };
        // for Macho
        Pool machoPool = new Pool() { category = "macho", prefab = ScriptableObject.CreateInstance<Card>() };
        // for Girly
        Pool girlyPool = new Pool() { category = "girly", prefab = ScriptableObject.CreateInstance<Card>() };
        // for Daring
        Pool daringPool = new Pool() { category = "daring", prefab = ScriptableObject.CreateInstance<Card>() };
        // for School
        Pool schoolPool = new Pool() { category = "school", prefab = ScriptableObject.CreateInstance<Card>() };

        // Adds all Pool objects to a List.
        pools.Add(familyPool);
        pools.Add(sexyPool);
        pools.Add(machoPool);
        pools.Add(girlyPool);
        pools.Add(daringPool);
        pools.Add(schoolPool);
        
        // Gets the images from the dataList.
        GlobalVariables.GetImages(GlobalVariables.dataList);
        // Sets the static dictionary to the returned dictionary of the method.
        GlobalVariables.staticDataAndPools = CreateDataAndPoolsDictionary();
    }
    public void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
    }
}
