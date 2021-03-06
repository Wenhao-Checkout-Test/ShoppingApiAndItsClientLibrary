﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using ShoppingAPI.Core;
using ShoppingAPI.Core.Dtos;
using ShoppingAPI.Core.Models;

namespace ShoppingAPI.Controllers
{
    [Authorize]
    public class ProductsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IHttpActionResult Get()
        {
            return Ok(Mapper.Map<List<Product>, List<ProductDto>>(_unitOfWork.Products.GetAll().ToList()));
        }

        /*TODO later: add more actions for get products by conditions (name, id, type, maybe also paging the results) 
         *So that client don't have to get the whole product list always*/
    }
}
