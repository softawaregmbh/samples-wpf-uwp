﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace SwaggerClient.Models
{
    public partial class CurrencyQuery
    {
        private string _country;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Country
        {
            get { return this._country; }
            set { this._country = value; }
        }
        
        private int? _maxCount;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? MaxCount
        {
            get { return this._maxCount; }
            set { this._maxCount = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the CurrencyQuery class.
        /// </summary>
        public CurrencyQuery()
        {
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type CurrencyQuery
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            if (this.Country != null)
            {
                outputObject["Country"] = this.Country;
            }
            if (this.MaxCount != null)
            {
                outputObject["MaxCount"] = this.MaxCount.Value;
            }
            return outputObject;
        }
    }
}
