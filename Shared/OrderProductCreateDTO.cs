﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class OrderProductCreateDTO
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public long ProductsCount { get; set; }
        public long? CreatorId { get; set; }

    }
}
