/*
 * Name: Michelle Ng // 100779006
 * File Name: BakedGood.cs
 * Date : 10 December 2021
 * Description: A class of a baked good.
 *       
 */

#region USING STATEMENTS
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace BAKERY_WEB_APPLICATION.Models
{
    public class BakedGood
    {
        #region PROPERTIES
        [Key]
        public int bakedGoodID { get; set; }

        public string bakedGoodName { get; set; }

        public string typeOfPastry { get; set; }

        public double pricePerUnit { get; set; }

        public bool availableOrNot { get; set; }

        #endregion
    }
}
