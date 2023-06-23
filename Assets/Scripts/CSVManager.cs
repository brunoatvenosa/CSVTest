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

public static class CSVManager
{
    
    /// <summary>
    /// Reads a CSV file ond return a list of CSV entrys
    /// </summary>
    /// <param name="path">defaults to Application.streamingAssetsPath + "/conteudo.csv"</param>
    /// <returns>A list of CSVEntry</returns>
    public static List<CSVEntry> ReadFile(string path = null)
    {
        if (path == null)
        {
            path = Application.streamingAssetsPath + "/conteudo.csv";
        }
        
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            BadDataFound = BadDataFound,
        };

        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(reader, config))
        {

            IEnumerable<CSVEntry> records = new List<CSVEntry>();
            csv.Context.RegisterClassMap<CSVEntry.Map>();
            try
            {
                records = csv.GetRecords<CSVEntry>();
            }
            catch (CsvHelper.BadDataException ex)
            {
                Debug.LogError(ex.Message);
            }
            return records.ToList();
        }
    }

    private static void BadDataFound(BadDataFoundArgs args)
    {
        Debug.LogError($"BAD DATA reading {args.Context}!: \n FIELD :{args.Field} \n RAW :{args.RawRecord}");
    }
}