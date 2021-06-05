using UnityEngine;
using System.Collections;
using System.Xml;
public class TmxReader : MonoBehaviour
{
    [SerializeField] string levelname = "level.tmx";
    //[SerializeField] GameObject[] tiles;
    public ColorTOPrefab[] tiles;

    private int _height = 0;
    private int _width = 0;

    int layersNr = -1;

    void Start()
    {
        StartCoroutine(LoadLevel(levelname));
    }

    private IEnumerator LoadLevel(string filename)
    {
        var asset = Resources.Load(levelname);
        yield return asset;
        XmlReader xmlReader = XmlReader.Create(Application.dataPath + "/"+ levelname+".xml");

        while (xmlReader.Read())
        {
            if (xmlReader.IsStartElement("map"))
            {
                _width = int.Parse(xmlReader.GetAttribute("width"));
                _height = int.Parse(xmlReader.GetAttribute("height"));

            }
            if (xmlReader.IsStartElement("object"))
            {
                int x = int.Parse(xmlReader.GetAttribute("x"));
                int y = int.Parse(xmlReader.GetAttribute("y"));
                int gid = int.Parse(xmlReader.GetAttribute("gid"));
                string name = xmlReader.GetAttribute("name");
                CreateTile(x, y, gid, name);
                print("x is: " + x + "y is: " + y + "gid is: " + gid + "name is: " + name);
            }
            if (xmlReader.IsStartElement("data"))
            {
                layersNr++;
                string data = xmlReader.ReadInnerXml();
                string[] lines = data.Split('\n');
                int height = lines.Length - 2; //removes additional empty line
                for (int j = 1; j < height + 1; j++)
                {
                    string line = lines[j];
                    string[] cols = line.Split(',');
                    int width = cols.Length - 1;
                    for (int i = 0; i < width + 1; i++)
                    {
                        int tile = 0;
                        if (int.TryParse(cols[i], out tile))
                        {
                            CreateTile(i, _height - j, tile, "");
                        }
                    }
                }
            }
        }
    }

    private void CreateTile(int x, int y, int tile, string name)
    {
        if (tile == 0)
            return;
        GameObject newTile = (GameObject)Instantiate(tiles[layersNr].prefab);
        newTile.transform.position = new Vector3(x, 0, y)+ tiles[layersNr].offset;
        newTile.transform.parent = gameObject.transform;
    }


}