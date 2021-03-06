using System;
using System.Web.Mvc;
using StructureMap;

namespace ShowOff.Controllers
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController  GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            try
            {
                return ObjectFactory.GetInstance(controllerType) as Controller;
            }
            catch (StructureMapException)
            {
                System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());
                throw;
            }
        }
    }
}