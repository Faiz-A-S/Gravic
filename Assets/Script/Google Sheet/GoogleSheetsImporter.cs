using System.Collections.Generic;
using UnityEngine;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System.IO;

public class GoogleSheetsImporter : MonoBehaviour
{
    [SerializeField] private string spreadsheetId = "1FA7w7jCX5s4CwxEXqAoZLtxMId2KVKsmI3MJ9A-iNNk";
    [SerializeField] private string serviceAccountId = "testinggravic@testgravic.iam.gserviceaccount.com";

    private SheetsService service;
    private string key = "-----BEGIN PRIVATE KEY-----\nMIIEuwIBADANBgkqhkiG9w0BAQEFAASCBKUwggShAgEAAoIBAQCz4MCEFLoKs9+7\nodx8DWEnXnCJZKxxf7VThM+dN+Kf4zGg+ynD2kFvlE7aNfflpInfnguSlnJ1tOOl\nCN45m6KTNi0xAlRR3RobXoCp3VqNyNf4bI0d8/YC2j5IGFuXcMDSkwth7rvyE+JR\nwrk3l8leUyw4hi1Q5ISGnTEkolDhTlP5nqOkVVqOoqCJMYikCUTYLHFbzt1F3rJm\nAXW1bO6MSXLdHGXcW/f7jknNpLHVFqX/bawWYZEjb91wp1HAqcJhYN2ZGlYp1Y84\n2/+11hLSyfHkSJwyy+31sBcrZnenB8Arf9CJr/dZhIGnKoOzL+979zYDc3dA67cL\n4ogoXvevAgMBAAECgf9oQeGREwG3ovqzeWAPkQ3YOXkz68S/skrILRi4DHPilGDs\n/M+PU8NcK1c22zntVjiTcyDl2ucWPbz7238Gu+GYmqAHhWF4tU0fpGQXqga4wN6B\nTLtz+AJSUwOnnNz+nPAwUAolECC2SF95YFRWWkyzyr7RndTZWs1Ma+5xM7e3ggre\ngSwsf362HkwXx1CotHcEtQLSDqZMH4Xhr27bBflxK2eDXYyYuxBhnPOa8bevzS3j\nI8G2FcwoejJI4MmZCpnHd27VhIdfbXxmf1hlhDgaVWz2X3VPbF099nE44BTuwl2a\n5yfT+ltRAZZEyHhYcplymF4aTGPsOroC2z8fMI0CgYEA9TtLRjUVzjhwHMyhFjfB\ngVBeOOfzLN4CNpt6Q1ugj4NTVypwB7hcsxk/7WLGni5uNQGz3Ko8ezrXg7dOU2Oo\n8VeQpenYXTfeaSWRZMia+w+4LLNebn5C2n+GwwQPlmgMwCWmlbp8D6ijHwy94leS\nSwiEiyThjo+dVQuMnAVYDCMCgYEAu8bNTmSIeozDSW/C2LPzAqLfQBC1TQmsI9yY\nUinx3LJPXTheACSMo53iv8NZHs/k9F/3XLSjiPIphtHkEPgXoKjxSbIadUlo4fsq\neGWEAuvnAK+oaLR/j9iy3LhWdYEpRouut5k/HH6rTvGRsRy/7tHL8VWSIMNIxtOt\n/FK4iQUCgYEA2dskIynTxlETIDKVxLQhnuyz1+APg0NzOenjsuU6fWQQbLZRsjoR\neDYtOYlvo2TiGQr7K0S82EjM3sHAvoohss20vgBBa4bPeh+ay6r/K5yqZGOwt35J\ni+yQ3rzD0D19XlHUbN2viwWobFQYeHSNjUTy4t4P12M0RTIuZwjEUHsCgYBJnlGT\nsHqJgXJ28ig0Caj2maBpX6OVBnvEu5HEdMlsO0Q+SgEgkTPKWfYyNIZWPC+JV66F\nXBTZdget4dBGjt3EkTe4KumQni1Om8g016f/9Tjl3fhqxIlWfiDxxBuxiegCznS7\naouBwm+rTa5O//SHzxzkCyZ1TdrUiN0nlc7feQKBgDeD9Sw5hDMFemr9JOgJ1VcN\nb6++T1tTKLjllfsqzhWJvv766aTeEoexJmESk0//JZXD3pw9BvE8gm7YYlZFbzy/\nnOI4INDmnXeOQZc/4D5jAdECJOyPNbPxA5/wRFxc/hv3cANSdMI6NTOq3SDaXOnV\ntVoKqj3pkzPbqXJfAx5b\n-----END PRIVATE KEY-----\n";
    
    private static GoogleSheetsImporter _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Import();
    }

    private void InitializeImport()
    {
        ServiceAccountCredential.Initializer initializer = new ServiceAccountCredential.Initializer(serviceAccountId);
        ServiceAccountCredential credential = new ServiceAccountCredential(initializer.FromPrivateKey(key));

        service = new SheetsService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential
        });
    }

    public IList<IList<object>> GetSheetRange(string sheetNameAndRange)
    {
        SpreadsheetsResource.ValuesResource.GetRequest request =
            service.Spreadsheets.Values.Get(spreadsheetId, sheetNameAndRange);

        ValueRange response = request.Execute();

        IList<IList<object>> values = response.Values as IList<IList<object>>;
        if (values != null && values.Count > 0)
        {            
            return values;
        }
        else
        {
            Debug.Log("No data found.");
            return null;
        }
    }

    public void Import()
    {
        InitializeImport();
        ImportAndSaveAsCSV();
    }

    public void ImportAndSaveAsCSV()
    {
        IList<IList<object>> cellContents = GetSheetRange("Soal!A1:E9");

        if (cellContents != null)
        {
            List<string> csvLines = new List<string>();
            foreach (List<object> rowData in cellContents)
            {
                string csvLine = string.Join(",", rowData);
                csvLines.Add(csvLine);
            }

            string csvFilePath = Path.Combine(Application.persistentDataPath, "SoalGravic.csv");// ini gua udah dari Application.DataPath
            File.WriteAllLines(csvFilePath, csvLines);

            Debug.Log("Data saved to CSV: " + csvFilePath);
        }
    }
}