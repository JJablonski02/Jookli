using Jookli.Games.Application.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Application.Features.Games.AyeTStudios.Callback
{
    public class AyetCallbackCommand : CommandBase
    {
        [JsonProperty("transaction_id")]
        public string? TransactionId { get; set; }
        [JsonProperty("payout_usd")]
        public float PayoutUSD { get; set; }
        [JsonProperty("currency_amount")]
        public float CurrencyAmount { get; set; }
        [JsonProperty("external_identifier")]
        public string? ExternalIdentifier { get; set; }
        [JsonProperty("user_id")]
        public int UserId { get; set; }
        [JsonProperty("placement_identifier")]
        public string? PlacementIdentifier { get; set; }
        [JsonProperty("adslot_id")]
        public int? AdlostId { get; set; }
        [JsonProperty("sub_id")]
        public string? SubId { get; set; }
        [JsonProperty("ip")]
        public string? IpAddress { get; set; }
        [JsonProperty("offer_id")]
        public int? OfferId { get; set; }
        [JsonProperty("offer_name")]
        public string? OfferName { get; set; }
        [JsonProperty("device_uuid")]
        public string? DeviceUUID { get; set; }
        [JsonProperty("device_make")]
        public string? DeviceMake { get; set; }
        [JsonProperty("device_model")]
        public string? DeviceModel { get; set; }
        [JsonProperty("advertising_id")]
        public string? AdvertisingId { get; set; }
        [JsonProperty("sha1_android_id")]
        public string? Sha1AndroidId { get; set; }
        [JsonProperty("sha1_imei")]
        public string? Sha1Imei { get; set; }
        [JsonProperty("is_chargeback")]
        public int? IsChargeack { get; set; }
        [JsonProperty("chargeback_reason")]
        public string? ChargebackReason { get; set; }
        [JsonProperty("chargeback_date")]
        public string? ChargebackDate { get; set; }
        [JsonProperty("task_name")]
        public string? TaskName { get; set; }
        [JsonProperty("task_uuid")]
        public string? TaskUUID { get; set; }
        [JsonProperty("currency_conversion_rate")]
        public decimal CurrencyConversionRate { get; set; }
        [JsonProperty("custom_1")]
        public string? Custom1 { get; set; }
        [JsonProperty("custom_2")]
        public string? Custom2 { get; set; }
        [JsonProperty("custom_3")]
        public string? Custom3 { get; set; }
        [JsonProperty("custom_4")]
        public string? Custom4 { get; set; }
        [JsonProperty("custom_5")]
        public string? Custom5 { get; set; }
    }
}
