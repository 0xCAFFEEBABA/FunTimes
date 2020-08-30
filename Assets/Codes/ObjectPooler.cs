using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPooler : MonoBehaviour
{
    #region Pool Class
    // Sets the class as Serializable
    [System.Serializable]
    public class Pool
    {
        // Every Pool will contain...
        /// <summary>
        /// A Card for the cards. 
        /// </summary>
        public Card card;
        /// <summary>
        ///  A String for the category.
        /// </summary>
        public string category;
        /// <summary>
        /// A GameObject for the image.
        /// </summary>
        public GameObject gameObject;
        /// <summary>
        /// An integer for the pool's size.
        /// </summary>
        public int size;
    }
    #endregion

    #region Variables
    //---------- For Card's Dimensions ----------
    /// <summary>
    /// The default width of every card.
    /// </summary>
    public float cardWidth = 598.4164f;
    /// <summary>
    /// The default height of every card.
    /// </summary>
    public float cardHeight = 985.9826f;
    //---------- For Countdown ----------
    /// <summary>
    /// Keeps count of the "next card" button's clicks.
    /// </summary>
    public int count;
    /// <summary>
    /// The total number of cards in the selected categories.
    /// </summary>
    public int total;
    /// <summary>
    /// The countdown's UI element in Unity.
    /// </summary>
    public TextMeshProUGUI countdown;
    //---------- For Pools and Dictionaries ----------
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
    /// A list of all the tasks inside a JSON file.
    /// </summary>
    public List<string> TaskList = new List<string>();
    #endregion

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
                // Adds to the specific pool's game object an image.
                var cardImage = dataAndPool.Value.gameObject.AddComponent<Image>();
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
                var cardsPosition = cardImage.transform as RectTransform;
                // Creates a new vector with the wanted width and height.
                cardsPosition.sizeDelta = new Vector2(cardWidth, cardHeight);
            }
        }
        ForTheQueues();
    }

    #region DataAndPools

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
    /// Creates pools for every category and adds them to a list.
    /// </summary>
    public void CreatePoolList()
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
    }

    /// <summary>
    /// It's called before the scene is loaded.
    /// Creates the Pool Objects and adds them to a list
    /// Gets the images from the Global Variables class
    /// Sets the <see cref="GlobalVariables.staticDataAndPools"/> to the returned dictionary of the <see cref="CreateDataAndPoolsDictionary"/> method
    /// </summary>
    public void Awake()
    {
        // Unlocks the appropriate JSON files when the according toggle is on.
        // In this case it unlocks the family JSON file as it is our default category.
        GlobalVariables.OpenJsonFiles();
        // Creates a list of pools
        CreatePoolList();
        // Gets the images from the dataList.
        GlobalVariables.GetImages(GlobalVariables.dataList);
        // Sets the static dictionary to the returned dictionary of the method.
        GlobalVariables.staticDataAndPools = CreateDataAndPoolsDictionary();
        
        // For each and every pool in the pools list...
        foreach (Pool pool in pools)
        {
            foreach(var data in GlobalVariables.dataList)
            // If the pool is NOT empty...
            if (pool.category == data.Category 
                && pool.size > 0 
                && data.ToggleBool == true)
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
                GlobalVariables.staticPoolDictionary.Add(pool.category, objectPool);
            }
        }
    }

    /// <summary>
    /// Creates for every data an array of all the tasks in the according JSON file.
    /// </summary>
    public void CreateTaskArray()
    { 
        // For each and every data in the list of data...
        foreach(var data in GlobalVariables.dataList)
        {
            // If the data's toggle is on...
            if (data.ToggleBool == true)
            {
                // Parses the "cards" array in the according JSON file to a JArray. 
                JArray cards = (JArray)data.JsonData["cards"];
                // For each and every object inside the "cards[]" array...
                foreach (JObject content in cards.Children<JObject>())
                {
                    // For each property of the specified object...
                    foreach (JProperty prop in content.Properties())
                    {
                        // If the property's name is "task"... (ex. "id","task")
                        if (prop.Name == "task")
                        {
                            // Sets a temporary string to the property's value. (ex. "D-R-I-N-K")
                            var tempString = prop.Value.ToString();
                            // Adds the string to the data's TaskList.
                            TaskList.Add(tempString);
                        }
                    }
                }
            }
            // Parses the list of tasks to a string array of tasks.
            data.TaskArray = TaskList.ToArray();
        }
    }

    /// <summary>
    /// For every active category Queue sets the image and task of every card
    /// </summary>
    public void ForTheQueues()
    {
        // Creates an array of tasks for active categories.
        CreateTaskArray();
        // For each and every key value pair in the dictionary of strings and pools...
        foreach (var stringQueuePair in GlobalVariables.staticPoolDictionary)
        {
            // Parses the queue to an array.
            var queueArray = stringQueuePair.Value.ToArray();
            // For each and every key value pair in the dictionary of data and pools...
            foreach (var dataPoolPair in GlobalVariables.staticDataAndPools)
            {
                // If the stringQueuePair's string is equal to the dataPoolPair's Data's Category...
                if (stringQueuePair.Key == dataPoolPair.Key.Category)
                {
                    // For as many times as the number of tasks in the JSON file...
                    for (int i = 0; i <= dataPoolPair.Key.Length - 1; i++)
                    {
                        // Sets task as the task component in the i-th pool of the Queue Array. 
                        var task = queueArray[i].gameObject.transform.Find("Task").GetComponent<TextMeshProUGUI>();
                        // Sets task's text to the i-th task in the array of tasks.
                        task.text = dataPoolPair.Key.TaskArray[i];
                        // Adds to the specific pool's game object an image.
                        var cardImage = queueArray[i].gameObject.AddComponent<Image>();
                        // For the sprite...
                        // If the player has set the theme to dark...
                        if (PlayerPrefs.GetInt("theme") == 1)
                            // Sets the image's sprite to the dark image of the card in the pool.
                            cardImage.sprite = dataPoolPair.Value.card.spiteDark;
                        // If the player has set the theme to light...
                        else if (PlayerPrefs.GetInt("theme") == 0)
                            // Sets the image's sprite to the light image of the card in the pool.
                            cardImage.sprite = dataPoolPair.Value.card.spriteLight;
                        // Else...
                        else
                            // By default sets the image's sprite to the light image of the card in the pool.
                            cardImage.sprite = dataPoolPair.Value.card.spriteLight;
                        // For the image's dimensions
                        // Sets a RectTransform for the image.
                        var cardsPosition = cardImage.transform as RectTransform;
                        // Creates a new vector with the wanted width and height.
                        cardsPosition.sizeDelta = new Vector2(cardWidth, cardHeight);
                    }
                }
            }
        }
    }

    #endregion



    
}
