using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class squaremovement : MonoBehaviour
{
    private const float Acceleration = 1;

    private Rigidbody2D _rigidBodyComponent;
    // Start is called before the first frame update
    private void Start()
    {
        _rigidBodyComponent = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var w = Input.GetKey(KeyCode.W) ? 0.1 : 0;
        var s = Input.GetKey(KeyCode.S) ? -0.1 : 0;
        var a = Input.GetKey(KeyCode.A) ? 0.1 : 0;
        var d = Input.GetKey(KeyCode.D) ? -0.1 : 0;
        var space = Input.GetKey(KeyCode.Space) ? -1 : 0;
        var movementVector = new Vector2(-((float)a + (float)d), (float)w + (float)s);
        movementVector.Normalize();
        _rigidBodyComponent.velocity = movementVector * Acceleration;
        if (!(movementVector.magnitude > Mathf.Epsilon)) return;
        var angle = new Vector3(0 ,0, 0);
        transform.rotation = Quaternion.Euler(angle);

    }

    public static void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            GameObject.Find("Isometric Diamond").transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
}