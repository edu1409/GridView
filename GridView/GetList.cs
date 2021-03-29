using System;
using System.Collections.Generic;

namespace GridView
{
    public static class DataService
    {
        public static IEnumerable<Product> GetProducts()
        {
            List<Product> products = new()
            {
                new Product{ Name = "Relógio de Pulso", Classification = "Relógios", Price = 178.47 },
                new Product{ Name = "Relógio Digital Esporte", Classification = "Relógios", Price = 109.99 },
                new Product{ Name = "Kit Relógio Feminino", Classification = "Relógios", Price = 229.00 },
                new Product{ Name = "Relógio de Parede", Classification = "Relógios", Price = 35.70 },
                new Product{ Name = "Despertador Digital", Classification = "Relógios", Price = 59.90 },
                new Product{ Name = "Pulseira de Metal", Classification = "Relógios", Price = 72.45 },
                new Product{ Name = "Kit 5 Relógios Masculino", Classification = "Relógios", Price = 390.00 },
                new Product{ Name = "Violino 4/4", Classification = "Instrumentos Musicais", Price = 302.99 },
                new Product{ Name = "Contrabaixo Woodstock", Classification = "Instrumentos Musicais", Price = 1305.00 },
                new Product{ Name = "Violão Acústico", Classification = "Instrumentos Musicais", Price = 189 },
                new Product{ Name = "Guitarra Stratocaster", Classification = "Instrumentos Musicais", Price = 726.56 },
                new Product{ Name = "Calça Xadrez Flanelada", Classification = "Roupas", Price = 34.99 },
                new Product{ Name = "Blusa Feminina Bata", Classification = "Roupas", Price = 37.99 },
                new Product{ Name = "Vestido Jeans Plus Size", Classification = "Roupas", Price = 121.59 },
                new Product{ Name = "Jaqueta Bomber Feminina", Classification = "Roupas", Price = 99.99 },
                new Product{ Name = "Kit 5 Camisetas Manga Longa", Classification = "Roupas", Price = 138.90 },
                new Product{ Name = "Jaqueta Masculina de Couro", Classification = "Roupas", Price = 169.99 },
                new Product{ Name = "Calça Jeans Masculina", Classification = "Roupas", Price = 139.50 },
                new Product{ Name = "Calça Moletom Masculina", Classification = "Roupas", Price = 34.20 },
                new Product{ Name = "Bermuda Masculina", Classification = "Roupas", Price = 54.90 },
                new Product{ Name = "Camiseta Esportiva Masculina", Classification = "Roupas", Price = 59.90 },
                new Product{ Name = "Calça para Ciclismo", Classification = "Roupas", Price = 189.00 },
                new Product{ Name = "Camiseta Feminina", Classification = "Roupas", Price = 26.78 },
                new Product{ Name = "Blusa Gola Alta", Classification = "Roupas", Price = 43.70 },
                new Product{ Name = "Top Esportivo Feminino", Classification = "Roupas", Price = 99.90 }
            };

            return products;
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Exclusive { get; set; }
    }
}
