﻿using BeYourMarket.Model.Enum;
using BeYourMarket.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    [MetadataType(typeof(ItemMetaData))]
    public partial class Item
    {
        public int PriceInCents
        {
            get
            {
                return Price.HasValue ? (int)Math.Round(Price.Value, 2) * 100 : 0;
            }
        }

        public string PriceFormatted
        {
            get
            {
                return Price.HasValue ? string.Format("{0:N2} {1}", Price.Value, Currency) : string.Empty;
            }
        }

        public bool OrderAllowed
        {
            get
            {
                return Price.HasValue && Active && Enabled && ItemType.OrderTypeID != (int)Enum_ItemOrderType.None;
            }
        }
    }

    public class ItemMetaData
    {
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true, NullDisplayText = "-")]
        public Nullable<double> Price { get; set; }
    }
}
