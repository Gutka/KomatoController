using System;
using System.Collections.Generic;
using System.Text;

namespace KomatoController.Models
{
    public static class CosmosClientCon
    {
        public static readonly string EndpointUri = "https://komato.documents.azure.com:443//";
        public static readonly string PrimaryKey = "uNqR2I7O5gd7cpxEDyKFZZ7VuJgF0dgJZZBj37WxPNnhvVcB9YMYICiK5d47BMe8zPrTNBAnetVPrGJwiYaEfg==";
        public static readonly string DatabaseName = "komatodb";
        public static readonly string CollectionName = "komatoGrow";
    }
}
