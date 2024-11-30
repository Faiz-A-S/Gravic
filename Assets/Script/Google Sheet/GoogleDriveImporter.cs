using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;
using System;
using System.Threading.Tasks;

public class GoogleDriveImporter : MonoBehaviour
{
    private string csvImageURLPath = "";
    private List<string> listImageURL;
    private List<string> listImageId;

    public List<Sprite> SpriteSoal;

    private static GoogleDriveImporter _instance;
    private GoogleSheetsImporter googleSheetsImporter;

    void Awake()
    {
        if (SpriteSoal != null)
        {
            return;
        }

        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        csvImageURLPath = Application.persistentDataPath + "/GambarSoalGravic.csv";
    }
    private async Task Start()
    {
        googleSheetsImporter = GoogleSheetsImporter.FindObjectOfType<GoogleSheetsImporter>();
        await Import();
    }

    public async Task Import()
    {        
        ImportURL();
        await DownloadAndSaveAsImage();
    }

    void ImportURL()
    {
        IList<IList<object>> cellContentsURL = googleSheetsImporter.GetSheetRange("Soal!F6:F9");
        if (cellContentsURL != null)
        {
            List<string> csvLinesURL = new List<string>();
            foreach (List<object> rowData in cellContentsURL)
            {
                string csvLine = string.Join("", rowData);
                csvLinesURL.Add(csvLine);
            }

            string csvFileURLPath = Path.Combine(Application.persistentDataPath, "GambarSoalGravic.csv"); 
            File.WriteAllLines(csvFileURLPath, csvLinesURL);

            Debug.Log("Image URL saved to CSV : " + csvFileURLPath);
        }

        // Mengambil id dari URL image
        listImageURL = new List<string>();
        listImageId = new List<string>();
        string[] linesURL = File.ReadAllLines(csvImageURLPath);

        foreach (string lineURL in linesURL)
        {
            string trimmedURL = lineURL.Trim();
            if (!string.IsNullOrEmpty(trimmedURL))
            {
                listImageURL.Add(trimmedURL);
                string imageID = ExtractIDFromURL(trimmedURL);
                listImageId.Add(imageID);
            }
        }
    }    

    private async Task DownloadAndSaveAsImage()
{
    // Load the service account key JSON file from the Resources folder
    TextAsset keyFile = Resources.Load<TextAsset>("Creds/keyImage");

    GoogleCredential credential;
    using (MemoryStream stream = new MemoryStream(keyFile.bytes))
    {
        credential = GoogleCredential.FromStream(stream)
            .CreateScoped(DriveService.Scope.Drive); // Specify the appropriate scope
    }

    // Create the Drive service
    var driveService = new DriveService(new BaseClientService.Initializer()
    {
        HttpClientInitializer = credential
    });    

    foreach (string fileId in listImageId)
    {
        var request = driveService.Files.Get(fileId);
        var stream = new MemoryStream();

        try
        {
            // Download the image content from gdrive
            await request.DownloadAsync(stream);

            // Load image from stream and save it as png
            Texture2D texture = new Texture2D(1024, 1024);
            texture.LoadImage(stream.ToArray());
            byte[] pngBytes = texture.EncodeToPNG();

            // Clean up the stream
            stream.Close();
            stream.Dispose();

            // Create a sprite from the texture
            Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

            SpriteSoal.Add(newSprite); // Add the sprite to the list

            //DestroyImmediate(texture); // Clean up the temporary texture
            string fileName = request.Execute().Name;

            // Save the PNG byte array to a file (if needed)
            //string savePath = Path.Combine(Application.persistentDataPath, fileName + ".png");
            //File.WriteAllBytes(savePath, pngBytes);

            Debug.Log("Image downloaded: " + fileName);
        }
        catch (Exception e)
        {
            Debug.LogError("Error downloading image: " + e.Message);
        }
    }
}

    // method for extracting ID from google drive URL
    public string ExtractIDFromURL(string url)
    {
        string pattern = @"/d/([a-zA-Z0-9_-]+)";
        Match match = Regex.Match(url, pattern);

        if (match.Success && match.Groups.Count > 1)
        {
            return match.Groups[1].Value;
        }
        return null;
    }
}
