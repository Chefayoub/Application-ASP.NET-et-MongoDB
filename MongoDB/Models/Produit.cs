using MongoDB.Bson; // Using pour utiliser les documents Bson
using MongoDB.Bson.Serialization.Attributes; // Ajoute la possiblité d'utiliser l'attribut bson en DataAnnotation et aussi convertire en Bson
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MongoDB.Models
{
    public class Produit
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [Required]// Le champs est requis
        [BsonElement("NomProduit")]// Le nom du champs Bson
        public string NomProduit { get; set; }

        [Required]
        [BsonElement("NumerocodeBarre")]
        public string NumerocodeBarre { get; set; }

        [Required]
        [BsonElement("Quantite")]
        public string Quantite { get; set; }

    }
}