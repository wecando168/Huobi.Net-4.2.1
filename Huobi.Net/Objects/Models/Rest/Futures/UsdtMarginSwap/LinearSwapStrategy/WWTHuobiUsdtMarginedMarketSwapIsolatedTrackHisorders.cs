﻿namespace Huobi.Net.Objects.Models.Rest.Futures.UsdtMarginSwap.LinearSwapStrategy
{
    /// <summary>
    /// 【逐仓】跟踪委托订单历史委托
    /// </summary>
    public class WWTHuobiUsdtMarginedMarketSwapIsolatedTrackHisorders
    {
        /// <summary>
        /// 总页数
        /// </summary>
        [JsonProperty("total_page", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalPage { get; set; } = default;

        /// <summary>
        /// 当前页
        /// </summary>
        [JsonProperty("current_page", NullValueHandling = NullValueHandling.Ignore)]
        public int CurrentPage { get; set; } = default;

        /// <summary>
        /// 总条数
        /// </summary>
        [JsonProperty("total_size", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalSize { get; set; } = default;

        /// <summary>
        /// 【逐仓】跟踪委托订单历史委托集合
        /// </summary>
        [JsonProperty("orders", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<HuobiUsdtMarginedIsolatedTrackHisorder> HuobiUsdtMarginedIsolatedTrackHisorders { get; set; } = Array.Empty<HuobiUsdtMarginedIsolatedTrackHisorder>();
    }

    /// <summary>
    /// 【逐仓】跟踪委托订单历史委托
    /// </summary>
    public class HuobiUsdtMarginedIsolatedTrackHisorder
    {
        /// <summary>
        /// 品种代码
        /// </summary>
        [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
        public string? Symbol { get; set; } = string.Empty;

        /// <summary>
        /// 合约代码
        /// </summary>
        [JsonProperty("contract_code", NullValueHandling = NullValueHandling.Ignore)]
        public string? ContractCode { get; set; } = string.Empty;

        /// <summary>
        /// 被触发时的价格
        /// </summary>
        [JsonProperty("triggered_price", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TriggeredPrice { get; set; } = default;

        /// <summary>
        /// 委托数量
        /// </summary>
        [JsonProperty("volume", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Volume { get; set; } = default;

        /// <summary>
        /// 订单类型 1:报单 、 2:撤单 、 3:强平、4:交割
        /// </summary>
        [JsonProperty("order_type", NullValueHandling = NullValueHandling.Ignore)]
        public int? OrderType { get; set; } = default;

        /// <summary>
        /// 买卖方向 "buy":买 "sell":卖
        /// </summary>
        [JsonProperty("direction", NullValueHandling = NullValueHandling.Ignore)]
        public string? Direction { get; set; } = string.Empty;

        /// <summary>
        /// 开平方向	"open":开 "close":平 "both":单向持仓
        /// </summary>
        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public string? Offset { get; set; } = string.Empty;

        /// <summary>
        /// 杠杆倍数
        /// </summary>
        [JsonProperty("lever_rate", NullValueHandling = NullValueHandling.Ignore)]
        public int? LeverRate { get; set; } = default;

        /// <summary>
        /// 订单ID
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderId { get; set; } = default(long);

        /// <summary>
        /// 字符串类型的订单ID
        /// </summary>
        [JsonProperty("order_id_str", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderIdStr { get; set; } = default(long);

        /// <summary>
        /// 订单来源（system:系统、web:用户网页、api:用户API、m:用户M站、risk:风控系统、settlement:交割结算、ios：ios客户端、android：安卓客户端、windows：windows客户端、mac：mac客户端、trigger：计划委托触发、tpsl:止盈止损触发 ）
        /// </summary>
        [JsonProperty("order_source", NullValueHandling = NullValueHandling.Ignore)]
        public string? OrderSource { get; set; } = string.Empty;

        /// <summary>
        /// 订单创建时间	
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public long CreatedTimestamp { get; set; }

        /// <summary>
        /// 订单更新时间，单位：毫秒
        /// </summary>
        [JsonProperty("update_time", NullValueHandling = NullValueHandling.Ignore)]
        public long? UpdateTimestamp { get; set; } = default(long);

        /// <summary>
        /// 订单报价类型 限价：limit ，最优5档：optimal_5，最优10档：optimal_10，最优20档：optimal_20
        /// </summary>
        [JsonProperty("order_price_type", NullValueHandling = NullValueHandling.Ignore)]
        public string? OrderPriceType { get; set; } = string.Empty;

        /// <summary>
        /// 1:准备提交、2:已提交、3:报单中、8：撤单未找到、9：撤单中、10：失败
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public int? Status { get; set; } = default;

        /// <summary>
        /// 下order单时间	
        /// </summary>
        [JsonProperty("canceled_at", NullValueHandling = NullValueHandling.Ignore)]
        public long? CanceledTimestamp { get; set; }

        /// <summary>
        /// 被触发时下order单失败错误码
        /// </summary>
        [JsonProperty("fail_code", NullValueHandling = NullValueHandling.Ignore)]
        public int? FailCode { get; set; }

        /// <summary>
        /// 被触发时下order单失败原因	
        /// </summary>
        [JsonProperty("fail_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string? FailReason { get; set; }

        /// <summary>
        /// 回调幅度	如：0.01 表示1%
        /// </summary>
        [JsonProperty("callback_rate", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? CallbackRate { get; set; } = default;

        /// <summary>
        /// 激活价格
        /// </summary>
        [JsonProperty("active_price", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ActivePrice { get; set; } = default;

        /// <summary>
        /// 激活价格是否已激活	1：已激活；0：未激活
        /// </summary>
        [JsonProperty("is_active", NullValueHandling = NullValueHandling.Ignore)]
        public int? IsActive { get; set; } = default;

        /// <summary>
        /// 市场最低/最高价（买入则为市场最低价、卖出则为市场最高价）
        /// </summary>
        [JsonProperty("market_limit_price", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MarketLimitPrice { get; set; } = default;

        /// <summary>
        /// 理论价格（市场最低（最高）价的（1 ± 回调幅度））
        /// </summary>
        [JsonProperty("formula_price", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? FormulaPrice { get; set; } = default;

        /// <summary>
        /// 实际委托数量
        /// </summary>
        [JsonProperty("real_volume", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? RealVolume { get; set; } = default;

        /// <summary>
        /// 该字段为关联限价单的关联字段，未触发前数值为-1
        /// </summary>
        [JsonProperty("relation_order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string? RelationOrderId { get; set; }

        /// <summary>
        /// 保证金模式   isolated：逐仓模式
        /// </summary>
        [JsonProperty("margin_mode", NullValueHandling = NullValueHandling.Ignore)]
        public string? MarginMode { get; set; } = string.Empty;

        /// <summary>
        /// 保证金账户   比如“BTC-USDT”
        /// </summary>
        [JsonProperty("margin_account", NullValueHandling = NullValueHandling.Ignore)]
        public string? MarginAccount { get; set; } = string.Empty;

        /// <summary>
        /// 是否为只减仓订单	0:表示为非只减仓订单，1:表示为只减仓订单
        /// </summary>
        [JsonProperty("reduce_only", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReduceOnly { get; set; } = default;

        /// <summary>
        /// 成交分区 如 USDT
        /// </summary>
        [JsonProperty("trade_partition", NullValueHandling = NullValueHandling.Ignore)]
        public string TradePartition { get; set; } = string.Empty;
    }
}