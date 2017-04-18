using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IMatchingServices
    {
        List<RecipeEntity> GetMatchedRecipes();
        void SendCheckedProducts(List<ProductEntity> checkedProducts);
    }
}
