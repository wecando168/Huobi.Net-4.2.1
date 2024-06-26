﻿namespace Huobi.Net.Objects.Models.Rest.Futures.UsdtMarginSwap.LinearSwapStrategy
{
    /// <summary>
    /// 【逐仓】撤销止盈止损订单
    /// </summary>
    public class WWTHuobiUsdtMarginedMarketSwapIsolatedTpslCancel
    {
        /// <summary>
        /// 撤销止盈止损订单信息列表
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<IsolatedCancelTpslOrderErrors> ErrorsList { get; set; } = Array.Empty<IsolatedCancelTpslOrderErrors>();

        /// <summary>
        /// 撤销成功止盈止损订单信息列表
        /// </summary>
        [JsonProperty("successes", NullValueHandling = NullValueHandling.Ignore)]
        public string Successes { get; set; } = string.Empty;
    }

    /// <summary>
    /// 逐仓撤销失败止盈止损订单信息
    /// </summary>
    public class IsolatedCancelTpslOrderErrors
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderId { get; set; } = default(long);

        /// <summary>
        /// 错误码
        /// </summary>
        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public int? ErrCode { get; set; } = default;

        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string? ErrMsg { get; set; } = string.Empty;
    }
}