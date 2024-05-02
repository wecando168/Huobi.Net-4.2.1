﻿namespace Huobi.Net.Objects.Models.Rest.Futures.UsdtMarginSwap.LinearSwapMarketData
{
    /// <summary>
    /// 【通用】获取标记价格的K线数据
    /// </summary>
    public class WWTHuobiUsdtMarginedMarketHistoryMarkKline
    {
        /// <summary>
        /// K线ID,也就是K线时间戳，K线起始时间
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = default;

        /// <summary>
        /// 开盘价
        /// </summary>
        [JsonProperty("open", NullValueHandling = NullValueHandling.Ignore)]
        public string Open { get; set; } = string.Empty;

        /// <summary>
        /// 收盘价,当K线为最晚的一根时，是最新成交价
        /// </summary>
        [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
        public string Close { get; set; } = string.Empty;

        /// <summary>
        /// 最低价
        /// </summary>
        [JsonProperty("low", NullValueHandling = NullValueHandling.Ignore)]
        public string Low { get; set; } = string.Empty;

        /// <summary>
        /// 最高价
        /// </summary>
        [JsonProperty("high", NullValueHandling = NullValueHandling.Ignore)]
        public string High { get; set; } = string.Empty;

        /// <summary>
        /// 成交量(币), 即 (成交量(张) * 单张合约面值)。 值是买卖双边之和	
        /// </summary>
        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public string Amount { get; set; } = string.Empty;

        /// <summary>
        /// 成交量(张)。 值是买卖双边之和
        /// </summary>
        [JsonProperty("vol", NullValueHandling = NullValueHandling.Ignore)]
        public string Vol { get; set; } = string.Empty;

        /// <summary>
        /// 成交额，即 sum（每一笔成交张数 * 合约面值 * 成交价格）。 值是买卖双边之和
        /// </summary>
        [JsonProperty("trade_turnover", NullValueHandling = NullValueHandling.Ignore)]
        public string TradeTurnover { get; set; } = string.Empty;

        /// <summary>
        /// 成交笔数。 值是买卖双边之和
        /// </summary>
        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public string Count { get; set; } = string.Empty;
    }
}