﻿using System.Text.Encodings.Web;
using System.Text.Json;

namespace eShop.models;

public class Storage
{
    private static readonly JsonSerializerOptions s_writeOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    /* Currently useless but will be useful when we start deserializing */
    private static readonly JsonSerializerOptions s_readOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static void WriteToFile(string path, List<SalesOrder> orders)
    {
        var json = JsonSerializer.Serialize(orders, s_writeOptions);

        File.WriteAllText(path, json);
    }

    public static List<SalesOrder> ReadFromFile(string path)
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<SalesOrder>>(json, s_readOptions)!;
        
    }
}