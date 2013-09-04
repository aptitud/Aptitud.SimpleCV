﻿namespace Aptitud.SimpleCV.Web.Helpers
{
    public class IndexViewModel
    {
        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrWhiteSpace(ErrorMessage); }
        }
    }
}