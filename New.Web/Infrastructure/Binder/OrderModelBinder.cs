using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using New.Domain.Entities;
using System.Web.Mvc;

namespace New.Web.Infrastructure.Binder
{
    public class OrderModelBinder: IModelBinder
    {
        private const string sessionKey = "Order";

        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            // Получить объект Cart из сеанса
            data_order order = null;
            if (controllerContext.HttpContext.Session != null)
            {
               order = (data_order)controllerContext.HttpContext.Session[sessionKey];
            }

            // Создать объект Cart если он не обнаружен в сеансе
            if (order == null)
            {
                order = new data_order();
                order.name = " new11";
                order.note = " 222";
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = order;
                }
            }

            // Возвратить объект Cart
            return order;
        }

    }
}