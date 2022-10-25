﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BoneFierApp.Components.HappyTrolling
{
    /// <summary>
    /// کلاس کمکی جهت سریالایز و دیسریالایز کردن شعی های جیسون
    /// </summary>
    internal class JsonHelper
    {
        static JavaScriptSerializer jso = new JavaScriptSerializer();

        public static string Serialize(object obj)
        {
            return jso.Serialize(obj);
        }
        public static T Deserialize<T>(string text)
        {
            return jso.Deserialize<T>(text);
        }
    }
}
