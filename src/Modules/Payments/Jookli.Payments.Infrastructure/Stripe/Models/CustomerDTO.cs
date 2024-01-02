using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Infrastructure.Stripe.Models
{
    internal class CustomerDTO
    {
        [JsonConstructor]
        public CustomerDTO(string id, string obj, string? address, long balance)
        {
            Id = id;
            Object = obj;
            Address = address;
            Balance = balance;
        }
        public string Id { get; set; }
        public string Object { get; set; }
        public string? Address { get; set; }
        public long Balance { get; set; }
    }
}
