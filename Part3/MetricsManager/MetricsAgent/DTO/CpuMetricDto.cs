﻿using System;
using System.Collections.Generic;

namespace MetricsAgent.DTO
{
    public class CpuMetricDto
    {
        public TimeSpan Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}