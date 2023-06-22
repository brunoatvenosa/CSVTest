using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using TMPro;
using UnityEngine;

public class CSVManager : MonoBehaviour
{
    private TMP_Text txtOut;
    // Start is called before the first frame update
    void Start()
    {
        txtOut = GetComponent<TMP_Text>();
        
        Demo();
    }

    IEnumerable<CSVEntry> ReadFile(string path = null)
    {
        if (path == null)
        {
            path = Application.streamingAssetsPath + "/conteudo_.csv";
        }
        
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            BadDataFound = BadDataFound,
        };

        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(reader, config))
        {

            csv.Context.RegisterClassMap<CSVFileMap>();
            var records = csv.GetRecords<CSVEntry>();
            return records.ToList();
        }
    }
    void Demo()
    {
        var records = ReadFile(Application.streamingAssetsPath + "/conteudo_.csv");
        StringBuilder sb = new StringBuilder();
        
        try
        {
            foreach (var record in records)
            {
                sb.Append($"categoria: {record.Categoria}\n texto: {record.Texto}\n ===========\n");
                Debug.Log($"categoria: {record.Categoria}\n texto: {record.Texto}\n ===========\n");
            }
                    
        }
        catch (CsvHelper.BadDataException ex)
        {
            sb.Append(ex.Message);
        }

        

        txtOut.text = sb.ToString();

    }

    private static void BadDataFound(BadDataFoundArgs args)
    {
        Console.WriteLine($"BAD DATA!: \n FIELD :{args.Field} \n RAW :{args.RawRecord}");
    }
}