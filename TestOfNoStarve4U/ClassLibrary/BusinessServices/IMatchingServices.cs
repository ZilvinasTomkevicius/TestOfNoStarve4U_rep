﻿using BusinessEntities;
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IMatchingServices
    {
        List<RecipeEntity> GetMatchedRecipes(List<ProductEntity> checkedProducts);
       // DataTable AddToTable(List<ProductEntity> checkedProducts);
       // List<ProductEntity> GetCheckedProducts();
    }
}
