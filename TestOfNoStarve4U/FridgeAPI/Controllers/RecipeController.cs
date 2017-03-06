 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices;

namespace FridgeAPI.Controllers
{
    public class RecipeController : ApiController
    {
        IRecipeServices recipeServices = new RecipeServices();

        /// <summary>
        /// Method for adding recipe (json: [Name, recDescription, cookingTime]) 
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Add(RecipeEntity recipe)
        {
            recipeServices.Add(recipe);

            return Request.CreateResponse(HttpStatusCode.OK, recipe);
        }

        /// <summary>
        /// Method for updating an existing recipe (json: [ID, Name, recDescription, cookingTime])
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Update(RecipeEntity recipe)
        {
            try
            {
                recipeServices.Update(recipe);

                return Request.CreateResponse(HttpStatusCode.OK, recipe);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Method for deleting an existing recipe (recipe/delete?recipeID=' ')
        /// </summary>
        /// <param name="recipe"></param>
        /// 
        [HttpDelete]
        public void Delete(int recipeID)
        {
            try
            {
                recipeServices.Delete(recipeID);
            }
            catch(Exception e)
            {
                Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Method for getting a recipe (recipe/get?recipeID=' ')
        /// </summary>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(int recipeID)
        {
            try
            {
                RecipeEntity recipe = recipeServices.Get(recipeID);

                return Request.CreateResponse(HttpStatusCode.OK, recipe);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Method for getting a list of recipes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<RecipeEntity> GetList()
        {            
                var recipeList = recipeServices.GetList();

                return recipeList;           
        }
    }
}
