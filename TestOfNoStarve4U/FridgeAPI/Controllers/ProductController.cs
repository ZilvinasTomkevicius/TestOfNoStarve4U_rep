﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices;
using log4net;

namespace FridgeAPI.Controllers
{
    public class ProductController : ApiController
    {
        IProductServices productServices = new ProductServices();

        private static log4net.ILog Log { get; set; }

        ILog log = log4net.LogManager.GetLogger(typeof(ProductController));

        /// <summary>
        /// Product.Add
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]       
        public HttpResponseMessage Add(ProductEntity product)
        {
            try
            {
                productServices.Add(product);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception e)
            {
                log.Error(e);    
                                            
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }            
        }

        /// <summary>
        /// Product.Update
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Update(ProductEntity product)
        {
            try
            {
                productServices.Update(product);

                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            catch(Exception e)
            {
                log.Error(e);

                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        } 
        
        /// <summary>
        /// Product.Delete
        /// </summary>
        /// <param name="productID"></param>
        [HttpDelete]
        public void Delete(int productID)
        {
            try
            {
                log.Info("veikia!");

                productServices.Delete(productID);
            }
            catch(Exception e)
            {
                log.Error(e);

                Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }    

        /// <summary>
        /// Product.Get
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(int productID)
        {            
            try
            {
                ProductEntity product = productServices.Get(productID);

                return (Request.CreateResponse(HttpStatusCode.Forbidden, product));
            }
            catch(Exception e)
            {
                log.Error(e);    
                     
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        /// <summary>
        /// Product.GetList
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetList()
        {
            try
            {
                var productList = productServices.GetList();

                return Request.CreateResponse(HttpStatusCode.OK, productList);
            }
            catch(Exception e)
            {
                log.Error(e);

                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }        
        }
    }
}
