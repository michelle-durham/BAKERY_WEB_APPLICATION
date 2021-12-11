/*
 * Name: Michelle Ng // 100779006
 * File Name: ErrorViewModel.cs
 * Date : 10 December 2021
 * Description: A class of an error message.
 *       
 */

using System;

namespace BAKERY_WEB_APPLICATION.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
