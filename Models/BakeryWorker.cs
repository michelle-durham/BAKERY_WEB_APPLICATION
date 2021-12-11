/*
 * Name: Michelle Ng // 100779006
 * File Name: BakeryWorker.cs
 * Date : 10 December 2021
 * Description: A class of a bakery worker.
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
    public class BakeryWorker
    {
        #region PROPERTIES
        [Key]
        public int workerID { get; set; }

        public string workerFirstName { get; set; }

        public string workerLastName { get; set; }

        public string workerRole { get; set; }

        public double workerHourlyWage { get; set; }

        #endregion
    }
}
