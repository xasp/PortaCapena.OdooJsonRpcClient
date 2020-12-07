﻿using Newtonsoft.Json;
using PortaCapena.OdooJsonRpcClient.Models;
using PortaCapena.OdooJsonRpcClient.Utils;

namespace PortaCapena.OdooJsonRpcClient.Tests.Models.Create
{
    [OdooTableName("product.product")]
    public class OdooCreateProduct : IOdooCreateModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uom_id")]
        public int UomId { get; set; }

        [JsonProperty("uom_po_id")]
        public int UomPoId { get; set; }
    }
}