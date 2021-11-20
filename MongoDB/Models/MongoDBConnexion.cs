using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace MongoDB.Models
{
    public class MongoDBConnexion
    {
        // MongoClient est utilisé pour se connecter au serveur. 
        public MongoClient client;
        // L'interface IMongoDatabase est utilisée pour les transactions de la base de données.
        public IMongoDatabase db;

        public MongoDBConnexion()
        {
            // Ici on se connecte au serveur
            this.client = new MongoClient("mongodb://localhost:27017");

            //Si la base de données n'existe pas, nous en créons une nouvelle avec le nom BDProduit.
            this.db = this.client.GetDatabase("BDProduit");
        }
    }
}