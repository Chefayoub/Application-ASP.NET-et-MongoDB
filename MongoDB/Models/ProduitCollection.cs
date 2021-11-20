using MongoDB.Driver; 
using MongoDB.Bson;
using MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDB.Models
{
    // cette classe est notre collection de produit (table de produit)
    public class ProduitCollection 
    {
        internal MongoDBConnexion _co = new MongoDBConnexion(); //Instantiation
        public IMongoCollection<Produit> Collection; //On déclare une collection, contenant une liste de produit (document)

        public ProduitCollection()
        {
            // On construit une collection
            this.Collection = _co.db.GetCollection<Produit>("Produits");
        }

        //insérer un document dans la collection Produits
        public void InsertProduit(Produit produit)
        {
            this.Collection.InsertOneAsync(produit);
        }

        //Permet de récuperer tous les produits présent dans la collection
        public List<Produit> GetAllProduit()
        {
            var requete = this.Collection// On stocke dans la variable requete la collection
                .Find(new BsonDocument())// Trouve les documents qui ce trouve dans la collection
                .ToListAsync();//Retourne les documents dans une liste de produits
            return requete.Result;
        }

        //Permet de récuperer un produit présent dans la collection via leurs ID
        public Produit GetProductById(string id)
        {
            var product = this.Collection
                .Find( new BsonDocument { { "_id", new ObjectId(id) } }) // Trouve le documents qui ce trouve dans la collection via son ID
                .FirstAsync()// Recupere le premier résultat 
                .Result;// Retourne la valeur du résultat
            return product;
        }

        // Modifier un produit dans la collection
        public void UpdateProduit(string id, Produit produit)
        {
            produit.Id = new ObjectId(id);// Convertir la chaine de caractere id en objectId

            var filter = Builders<Produit>
                .Filter
                .Eq(s => s.Id, produit.Id);// Via les expression lambda il compare via eq tous les documents s dont le ID est égale au produit recherche
            this.Collection.ReplaceOneAsync(filter, produit);// On remplace l'ancien ID par le nouveau
        }

        // Supprimer un produit dans la collection
        public void DeleteContact(string productId)
        {
            Produit prod = new Produit();
            prod.Id = new ObjectId(productId);
            var filter = Builders<Produit>.Filter.Eq(s => s.Id, prod.Id);
            this.Collection.DeleteOneAsync(filter);

        }
    }
}