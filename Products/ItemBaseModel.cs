using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Products
{
    public class ItemBaseModel : AbstractItemBaseModel
    {
        public ItemBaseModel()
        {

        }
        public ItemBaseModel(Item item) : base(item)
        {

        }
        
    }
}