﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Graficos
{
    public class DesempenhoModel
    {
        public string Id { get; set; }
        public string NomeTeste { get; set; }
        public double TempoExecucao { get; set; }
        public DateTime Data { get; set; }
    }
}
