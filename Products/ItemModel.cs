﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Products
{
    public class ItemModel : ItemBaseModel
    {
        public ItemModel()
        {

        }
        public ItemModel(Item item) : base(item)
        {

        }

    }
}