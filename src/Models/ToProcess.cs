using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models
{
    public class ToProcess
    {
        public string FieldId { get; set; }
        public string Type { get; set; }
        public int AmountToProcess { get; set; }

    }
}