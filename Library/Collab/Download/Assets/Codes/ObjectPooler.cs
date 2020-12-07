using System.Collections;
using System.Collections.Generic;
using System.Linq;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public Card card;
        public string category;
        public GameObject gameObject;

        public int size;
    }

    /// <summary>
    /// The default width of every card.
    /// </summary>
    public float cardWidth = 598.4164f;
    /// <summary>
    /// The default height of every card.
    /// </summary>
    public float cardHeight = 985.9826f;
    
    /// <summary>
    /// For every key value pair in the <see cref="GlobalVariables.staticDataAndPools"/> checks and adds the proper image to its cards
    /// </summary>
    public void Start()
    {
        // For each and every key value pair in the dictionary...
        foreach (var dataAndPool in GlobalVariables.staticDataAndPools)
        {
            // If the pair's pool's gameObject is NOT null...
            if (dataAndPool.Value.gameObject != null)
            {
                // Adds a game object to the pool.
                var cardData = dataAndPool.Value.gameObject.AddComponent<CardData>();
                // Adds an image to that game object.
                var cardImage = cardData.gameObject.AddComponent<Image>();
                // For the sprite...
                // If the player has set the theme to dark...
                if (PlayerPrefs.GetInt("theme") == 1)
                    // Sets the image's sprite to the dark image of the card in the pool.
                    cardImage.sprite = dataAndPool.Value.card.spiteDark;
                // If the player has set the theme to light...
                else if (PlayerPrefs.GetInt("theme") == 0)
                    // Sets the image's sprite to the light image of the card in the pool.
                    cardImage.sprite = dataAndPool.Value.card.spriteLight;
                // Else...
                else
                    // By default sets the image's sprite to the light image of the card in the pool.
                    cardImage.sprite = dataAndPool.Value.card.spriteLight;
                // For the image's dimensions
                // Sets a RectTransform for the image.
                var objectRectTransform = cardImage.transform as RectTransform;
                // Creates a new vector with the wanted width and height.
                objectRectTransform.sizeDelta = new Vector2(cardWidth, cardHeight);

            }
        }
    }

    #region DataAndPools
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
    /// Adds the images for dark and light theme's cards to the <see cref="Pool.gameObject"/> accordingly.
    /// </summary>
    /// <returns></returns>
    public Dictionary<Data, Pool> CreateDataAndPoolsDictionary()
    {
        // For each and every pool in pools...
        foreach (Pool pool in pools)
        {
            // For each and every data in dataList...
            foreach (Data data in GlobalVariables.dataList)
            {
                // If the data's category matches the pool's category...
                if (data.Category == pool.category)
                {
                    pool.card.category = pool.category;
                    pool.size = data.Length;
                    // Adds the data and pool to the dictionary as key and value.
                    dataAndPools.Add(data, pool);
                    // Gets out of the loop.
                    break;
                }
            }
        }
        // For each and every KeyValuePair in the dictionary...
        foreach (KeyValuePair<Data, Pool> dataAndPool in dataAndPools)
        {
            // Sets the card's sprite of the dark theme to the data's dark themed image
            dataAndPool.Value.card.spiteDark = dataAndPool.Key.DarkImage;
            // Sets the card's sprite of the light theme to the data's light themed image
            dataAndPool.Value.card.spriteLight = dataAndPool.Key.LightImage;
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
        Pool familyPool = new Pool() { category = "family", card = ScriptableObject.CreateInstance<Card>() };
        // for Sexy
        Pool sexyPool = new Pool() { category = "sexy", card = ScriptableObject.CreateInstance<Card>() };
        // for Macho
        Pool machoPool = new Pool() { category = "macho", card = ScriptableObject.CreateInstance<Card>() };
        // for Girly
        Pool girlyPool = new Pool() { category = "girly", card = ScriptableObject.CreateInstance<Card>() };
        // for Daring
        Pool daringPool = new Pool() { category = "daring", card = ScriptableObject.CreateInstance<Card>() };
        // for School
        Pool schoolPool = new Pool() { category = "school", card = ScriptableObject.CreateInstance<Card>() };

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

        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        // For each and every pool in the pools list...
        foreach (Pool pool in pools)
        {
            // If the pool is NOT empty...
            if (pool.size > 0)
            {

                pool.gameObject = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag(pool.category + "Card"));

                // Creates a new Queue.
                Queue<GameObject> objectPool = new Queue<GameObject>();
                // For as many times as the pool's size...
                for (int i = 0; i <= pool.size - 1; i++)
                {
                    GameObject completeCard = Instantiate(pool.gameObject);

                    completeCard.SetActive(false);
                    // Puts the game object back to the queue
                    objectPool.Enqueue(completeCard);
                }
                poolDictionary.Add(pool.category, objectPool);
            }
        }
    }
    #endregion

    
}
