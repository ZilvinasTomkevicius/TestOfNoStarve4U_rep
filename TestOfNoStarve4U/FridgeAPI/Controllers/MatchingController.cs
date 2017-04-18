using BusinessEntities;
using BusinessServices;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FridgeAPI.Controllers
{
    public class MatchingController : ApiController
    {
        IMatchingServices matchingServices = new MatchingServices();

        private static log4net.ILog Log { get; set; }

        ILog log = log4net.LogManager.GetLogger(typeof(MatchingController));

        /// <summary>
        /// Matching.GetMatchedRecipes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetMatchedRecipes()
        {
            try
            {
                var recipeList = matchingServices.GetMatchedRecipes();

                return Request.CreateResponse(HttpStatusCode.OK, recipeList);
            }
            catch (Exception e)
            {
                log.Error(e);

                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        /// <summary>
        /// Recipe.Add 
        /// </summary>
        /// <param name="checkedProducts"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SendCheckedProducts(List<ProductEntity> checkedProducts)
        {
            try
            {
                matchingServices.SendCheckedProducts(checkedProducts);
                return Request.CreateResponse(HttpStatusCode.OK, checkedProducts);
            }
            catch (Exception e)
            {
                log.Error(e);

                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
