﻿using System;
using System.Collections.Generic;

namespace GideonMarket.Web.Client.Pages.IncomePage
{
    public class IncomeViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public DateTime RegDt { get; set; }

        public List<IncomeItemViewModel> IncomeItems { get; set; }
    }
}
