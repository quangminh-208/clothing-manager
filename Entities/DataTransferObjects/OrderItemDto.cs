using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
