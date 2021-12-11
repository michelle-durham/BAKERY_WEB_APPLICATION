/*
 * Name: Michelle Ng // 100779006
 * File Name: CustomerOrder.cs
 * Date : 10 December 2021
 * Description: A class of a customer order.
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
    public class CustomerOrder
    {
        #region PROPERTIES
        [Key]
        public int orderID { get; set; }

        public string customerName { get; set; }

        public string description { get; set; }

        public string customerPhoneNumber { get; set; }

        public double orderAmount { get; set; }

        public bool completedOrNot { get; set; }

        #endregion
    }
}
