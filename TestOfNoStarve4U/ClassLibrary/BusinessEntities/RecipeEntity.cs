using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessEntities
{
    public class RecipeEntity
    {
        /// <summary>
        /// Identificator of Recipe
        /// </summary>
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public List<ProductEntity> Ingredients { get; set; }
    }
}
