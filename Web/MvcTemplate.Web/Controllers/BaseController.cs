﻿namespace InterviewSystem.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure.Mapping;
    using InterviewSystem.Services.Web;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}
