﻿using CryptoExchange.Net.CommonObjects;
using Huobi.Net.Enums;
using Huobi.Net.Objects.Models.Rest.Futures.UsdtMarginSwap.LinearSwapTrade;
using Huobi.Net.Objects.Models.Rest.Futures.UsdtMarginSwap.LinearSwapTrade.Request;
using Huobi.Net.Objects.Models.UsdtMarginSwap;

namespace Huobi.Net.Interfaces.Clients.UsdtMarginSwapApi
{
    /// <summary>
    /// Huobi usdt margin swap trading endpoints, placing and mananging orders.
    /// </summary>
    public interface IHuobiClientUsdtMarginSwapApiTrading
    {
        /// <summary>
        /// Cancel all cross margin orders fitting the parameters
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-cancel-all-orders" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="contractType">Contract type</param>
        /// <param name="side">Side</param>
        /// <param name="offset">Offset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiBatchResult>> CancelAllCrossMarginOrdersAsync(string? contractCode = null, string? symbol = null, ContractType? contractType = null, OrderSide? side = null, Offset? offset = null, CancellationToken ct = default);
        /// <summary>
        /// Cancel all isolated margin order fitting the parameters
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-cancel-all-orders" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="side">Side</param>
        /// <param name="offset">Offset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiBatchResult>> CancelAllIsolatedMarginOrdersAsync(string contractCode, OrderSide? side = null, Offset? offset = null, CancellationToken ct = default);
        /// <summary>
        /// Cancel cross margin order
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-cancel-all-orders" /></para>
        /// </summary>
        /// <param name="orderId">The order id</param>
        /// <param name="clientOrderId">The client order id</param>
        /// <param name="contractCode">Contract code</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="contractType">Contract type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiBatchResult>> CancelCrossMarginOrderAsync(long? orderId = null, long? clientOrderId = null, string? contractCode = null, string? symbol = null, ContractType? contractType = null, CancellationToken ct = default);
        /// <summary>
        /// Cancel cross margin orders
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-cancel-all-orders" /></para>
        /// </summary>
        /// <param name="orderIds">Order ids</param>
        /// <param name="clientOrderIds">Client order ids</param>
        /// <param name="contractCode">Contract code</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="contractType">Contract type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiBatchResult>> CancelCrossMarginOrdersAsync(IEnumerable<long> orderIds, IEnumerable<long> clientOrderIds, string? contractCode = null, string? symbol = null, ContractType? contractType = null, CancellationToken ct = default);
        /// <summary>
        /// Cancel isolated margin order
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-cancel-an-order" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="orderId">Order id</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiBatchResult>> CancelIsolatedMarginOrderAsync(string contractCode, long? orderId = null, long? clientOrderId = null, CancellationToken ct = default);
        /// <summary>
        /// Cancel isolated margin orders
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-cancel-an-order" /></para>
        /// </summary>
        /// <param name="contractCode">Contract  code</param>
        /// <param name="orderId">Order ids</param>
        /// <param name="clientOrderId">Client order ids</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiBatchResult>> CancelIsolatedMarginOrdersAsync(string contractCode, IEnumerable<long> orderId, IEnumerable<long> clientOrderId, CancellationToken ct = default);
        /// <summary>
        /// Change cross margin leverage
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-switch-leverage" /></para>
        /// </summary>
        /// <param name="leverageRate">Leverage rate</param>
        /// <param name="contractCode">Contract code</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="contractType">Contract type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiCrossMarginLeverageRate>> ChangeCrossMarginLeverageAsync(int leverageRate, string? contractCode = null, string? symbol = null, ContractType? contractType = null, CancellationToken ct = default);
        /// <summary>
        /// Change isolated margin leverage
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-switch-leverage" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="leverageRate">Leverage rate</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiIsolatedMarginLeverageRate>> ChangeIsolatedMarginLeverageAsync(string contractCode, int leverageRate, CancellationToken ct = default);
        /// <summary>
        /// Get cross margin closed orders
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-get-history-orders-new" /></para>
        /// </summary>
        /// <param name="tradeType">Trade type</param>
        /// <param name="allOrders">All orders</param>
        /// <param name="daysInHistory">Days in history</param>
        /// <param name="contractCode">Contract code</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="sortBy">Sort by</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiCrossMarginOrderPage>> GetCrossMarginClosedOrdersAsync(MarginTradeType tradeType, bool allOrders, int daysInHistory, string? contractCode = null, string? symbol = null, int? page = null, int? pageSize = null, string? sortBy = null, CancellationToken ct = default);
        /// <summary>
        /// Get cross margin open orders
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-current-unfilled-order-acquisition" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="sortBy">Sort by</param>
        /// <param name="tradeType">Trade type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiCrossMarginOrderPage>> GetCrossMarginOpenOrdersAsync(string? contractCode = null, string? symbol = null, int? page = null, int? pageSize = null, string? sortBy = null, MarginTradeType? tradeType = null, CancellationToken ct = default);
        /// <summary>
        /// Get cross margin order
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-get-information-of-order" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="orderId">Order id</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiCrossMarginOrder>>> GetCrossMarginOrderAsync(string? contractCode = null, string? symbol = null, long? orderId = null, long? clientOrderId = null, CancellationToken ct = default);
        /// <summary>
        /// Get cross margin order details
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-get-detail-information-of-order" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="orderId">Order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiMarginOrderDetails>> GetCrossMarginOrderDetailsAsync(string contractCode, long orderId, CancellationToken ct = default);
        /// <summary>
        /// Get cross margin orders
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-get-information-of-order" /></para>
        /// </summary>
        /// <param name="orderIds">Order ids</param>
        /// <param name="clientOrderIds">Client order ids</param>
        /// <param name="contractCode">Contract code</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiCrossMarginOrder>>> GetCrossMarginOrdersAsync(IEnumerable<long> orderIds, IEnumerable<long> clientOrderIds, string? contractCode = null, string? symbol = null, CancellationToken ct = default);
        /// <summary>
        /// Get cross margin user trades
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-get-history-match-results" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="tradeType">Trade type</param>
        /// <param name="daysInHistory">Days in history</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiCrossMarginUserTradePage>> GetCrossMarginUserTradesAsync(string contractCode, MarginTradeType tradeType, int daysInHistory, int? page = null, int? pageSize = null, CancellationToken ct = default);
        /// <summary>
        /// Get isolated margin closed orders
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-get-history-orders" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="tradeType">Trade type</param>
        /// <param name="allOrders">All orders</param>
        /// <param name="daysInHistory">Days in history</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="sortBy">Sort by</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiIsolatedMarginOrderPage>> GetIsolatedMarginClosedOrdersAsync(string contractCode, MarginTradeType tradeType, bool allOrders, int daysInHistory, int? page = null, int? pageSize = null, string? sortBy = null, CancellationToken ct = default);
        /// <summary>
        /// Get isolated margin open orders
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-current-unfilled-order-acquisition" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="sortBy">Sort by</param>
        /// <param name="tradeType">Trade type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiIsolatedMarginOrderPage>> GetIsolatedMarginOpenOrdersAsync(string contractCode, int? page = null, int? pageSize = null, string? sortBy = null, MarginTradeType? tradeType = null, CancellationToken ct = default);
        /// <summary>
        /// Get isoalted margin order
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-get-information-of-an-order" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="orderId">Order id</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiIsolatedMarginOrder>>> GetIsolatedMarginOrderAsync(string contractCode, long? orderId = null, long? clientOrderId = null, CancellationToken ct = default);
        /// <summary>
        /// Get isolated margin order details
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-order-details-acquisition" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="orderId">Order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiMarginOrderDetails>> GetIsolatedMarginOrderDetailsAsync(string contractCode, long orderId, CancellationToken ct = default);
        /// <summary>
        /// Get isolated margin orders
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-get-information-of-an-order" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="orderIds">Order ids</param>
        /// <param name="clientOrderIds">Client order ids</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<HuobiIsolatedMarginOrder>>> GetIsolatedMarginOrdersAsync(string contractCode, IEnumerable<long> orderIds, IEnumerable<long> clientOrderIds, CancellationToken ct = default);
        /// <summary>
        /// Get isolated margin user trades
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-acquire-history-match-results-new" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="tradeType">Trade type</param>
        /// <param name="daysInHistory">Days in history</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiIsolatedMarginUserTradePage>> GetIsolatedMarginUserTradesAsync(string contractCode, MarginTradeType tradeType, int daysInHistory, int? page = null, int? pageSize = null, CancellationToken ct = default);
        /// <summary>
        /// Place a new cross margin order
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#cross-place-an-order" /></para>
        /// </summary>
        /// <param name="quantity">Order quantity</param>
        /// <param name="side">Order side</param>
        /// <param name="leverageRate">Leverage rate</param>
        /// <param name="contractCode">Contract code</param>
        /// <param name="symbol">Symbol</param>
        /// <param name="contractType">Contract type</param>
        /// <param name="price">Price</param>
        /// <param name="offset">Offset</param>
        /// <param name="orderPriceType">Order price type</param>
        /// <param name="takeProfitTriggerPrice">Take profit trigger price</param>
        /// <param name="takeProfitOrderPrice">Take profit order price</param>
        /// <param name="takeProfitOrderPriceType">Take profit order price type</param>
        /// <param name="stopLossTriggerPrice">Stop loss trigger price</param>
        /// <param name="stopLossOrderPrice">Stop loss order price</param>
        /// <param name="stopLossOrderPriceType">Stop loss order price type</param>
        /// <param name="reduceOnly">Reduce only</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiPlacedOrderId>> PlaceCrossMarginOrderAsync(decimal quantity, OrderSide side, decimal leverageRate, string? contractCode = null, string? symbol = null, ContractType? contractType = null, decimal? price = null, Offset? offset = null, OrderPriceType? orderPriceType = null, decimal? takeProfitTriggerPrice = null, decimal? takeProfitOrderPrice = null, OrderPriceType? takeProfitOrderPriceType = null, decimal? stopLossTriggerPrice = null, decimal? stopLossOrderPrice = null, OrderPriceType? stopLossOrderPriceType = null, bool? reduceOnly = null, long? clientOrderId = null, CancellationToken ct = default);
        /// <summary>
        /// Place a new isolated margin order
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/en/#isolated-place-an-order" /></para>
        /// </summary>
        /// <param name="contractCode">Contract code</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="side">Order side</param>
        /// <param name="leverageRate">Leverage rate</param>
        /// <param name="price">Price</param>
        /// <param name="offset">Offset</param>
        /// <param name="orderPriceType">Order price type</param>
        /// <param name="takeProfitTriggerPrice">Take profit trigger price</param>
        /// <param name="takeProfitOrderPrice">Take profit order price</param>
        /// <param name="takeProfitOrderPriceType">Take profit order price type</param>
        /// <param name="stopLossTriggerPrice">Stop loss trigger price</param>
        /// <param name="stopLossOrderPrice">Stop loss order price</param>
        /// <param name="stopLossOrderPriceType">Stop loss order price type</param>
        /// <param name="reduceOnly">Reduce only</param>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<HuobiPlacedOrderId>> PlaceIsolatedMarginOrderAsync(string contractCode, decimal quantity, OrderSide side, decimal leverageRate, decimal? price = null, Offset? offset = null, OrderPriceType? orderPriceType = null, decimal? takeProfitTriggerPrice = null, decimal? takeProfitOrderPrice = null, OrderPriceType? takeProfitOrderPriceType = null, decimal? stopLossTriggerPrice = null, decimal? stopLossOrderPrice = null, OrderPriceType? stopLossOrderPriceType = null, bool? reduceOnly = null, long? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// 【全仓】查询系统交易权限(PrivateData)
        /// <para><a href="GET /linear-swap-api/v1/swap_cross_trade_state"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#a7dff164a9"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码	永续："BTC-USDT"... ，交割："BTC-USDT-210625"...</param>
        /// <param name="Pair">交易对	BTC-USDT</param>
        /// <param name="contractType">合约类型	swap（永续）、this_week（当周）、next_week（次周）、quarter（当季）、next_quarter（次季）</param>
        /// <param name="businessType">业务类型，不填默认永续	futures：交割、swap：永续、all：全部</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<WWTHuobiUsdtMarginedMarketSwapCrossTradeState>>> GetLinearSwapCrossTradeStateAsync(string? contractCode = null, string? Pair = null, string? contractType = null, string? businessType = null, CancellationToken ct = default);

        /// <summary>
        /// 
        /// 【逐仓】切换持仓模式(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_switch_position_mode"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#af9b5163ad"/></para>
        /// </summary>
        /// <param name="marginAccount">保证金账户	比如： "BTC-USDT"，"ETH-USDT" ...</param>
        /// <param name="positionMode">持仓模式	single_side：单向持仓；dual_side：双向持仓</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapIsolatedSwitchPositionMode>> LinearSwapSwitchPositionModeAsync(string marginAccount, string positionMode, CancellationToken ct = default);

        /// <summary>
        /// 
        /// 【全仓】切换持仓模式(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_cross_switch_position_mode"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#aa6585618a"/></para>
        /// </summary>
        /// <param name="marginAccount">保证金账户	比如： "BTC-USDT"，"ETH-USDT" ...</param>
        /// <param name="positionMode">持仓模式	single_side：单向持仓；dual_side：双向持仓</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapCrossSwitchPositionMode>> LinearSwapCrossSwitchPositionModeAsync(string marginAccount, string positionMode, CancellationToken ct = default);

        /// <summary>
        /// 
        /// 【逐仓】合约下单(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_order"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#0a9b6ea149"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码 "BTC-USDT"...</param>
        /// <param name="direction">仓位方向 "buy":买 "sell":卖</param>
        /// <param name="offset">开平方向 "open":开 "close":平 “both”:单向持仓</param>
        /// <param name="price">价格</param>
        /// <param name="leverRate">杠杆倍数[“开仓”若有10倍多单，就不能再下20倍多单;高倍杠杆风险系数较大，请谨慎使用。	</param>
        /// <param name="volume">委托数量(张)</param>
        /// <param name="orderPriceType">订单报价类型	"limit":限价，"opponent":对手价 ，"post_only":只做maker单,post only下单只受用户持仓数量限制,"optimal_5"：最优5档，"optimal_10"：最优10档，"optimal_20"：最优20档，"ioc":IOC订单，"fok"：FOK订单, "opponent_ioc": 对手价-IOC下单，"optimal_5_ioc": 最优5档-IOC下单，"optimal_10_ioc": 最优10档-IOC下单，"optimal_20_ioc"：最优20档-IOC下单，"opponent_fok"： 对手价-FOK下单，"optimal_5_fok"：最优5档-FOK下单，"optimal_10_fok"：最优10档-FOK下单，"optimal_20_fok"：最优20档-FOK下单</param>
        /// <param name="tpTriggerPrice">止盈触发价格</param>
        /// <param name="tpOrderPrice">止盈委托价格（最优N档委托类型时无需填写价格）</param>
        /// <param name="tpOrderPriceType">止盈委托类型	不填默认为limit; 限价：limit ，最优5档：optimal_5，最优10档：optimal_10，最优20档：optimal_20</param>
        /// <param name="slTriggerPrice">止损触发价格</param>
        /// <param name="slOrderPrice">止损委托价格（最优N档委托类型时无需填写价格）</param>
        /// <param name="slOrderPriceType">止损委托类型	不填默认为limit; 限价：limit ，最优5档：optimal_5，最优10档：optimal_10，最优20档：optimal_20</param>
        /// <param name="reduceOnly">是否为只减仓订单（该字段在双向持仓模式下无效，在单向持仓模式下不填默认为0。）	0:表示为非只减仓订单，1:表示为只减仓订单</param>
        /// <param name="clientOrderId">客户自己填写和维护，必须为数字	[1-9223372036854775807]</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapIsolatedOrder>> LinearSwapOrderAsync(
            string contractCode,
            UmDirection direction,
            UmOffset? offset,
            decimal? price,
            UmLeverRate leverRate,
            long volume,
            UmOrderPriceType orderPriceType,
            decimal? tpTriggerPrice,
            decimal? tpOrderPrice,
            UmOrderPriceType? tpOrderPriceType,
            decimal? slTriggerPrice,
            decimal? slOrderPrice,
            UmOrderPriceType? slOrderPriceType,
            int? reduceOnly = null,
            long? clientOrderId = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【全仓】合约下单(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_cross_order"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#fe3db69b44"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码 Contract code. Case-Insenstive.Both uppercase and lowercase are supported.e.g. "BTC-USDT"</param>
        /// <param name="direction">仓位方向 "buy":买 "sell":卖</param>
        /// <param name="offset">开平方向	"open":开 "close":平 “both”:单向持仓</param>
        /// <param name="price">价格 The price of the order, only for limit orders</param>
        /// <param name="leverRate">杠杆倍数[“开仓”若有10倍多单，就不能再下20倍多单;高倍杠杆风险系数较大，请谨慎使用。</param>
        /// <param name="volume">委托数量(张)</param>
        /// <param name="orderPriceType">订单报价类型 "limit":限价，"opponent":对手价 ，"post_only":只做maker单,post only下单只受用户持仓数量限制,"optimal_5"：最优5档，"optimal_10"：最优10档，"optimal_20"：最优20档，"ioc":IOC订单，"fok"：FOK订单, "opponent_ioc": 对手价-IOC下单，"optimal_5_ioc": 最优5档-IOC下单，"optimal_10_ioc": 最优10档-IOC下单，"optimal_20_ioc"：最优20档-IOC下单，"opponent_fok"： 对手价-FOK下单，"optimal_5_fok"：最优5档-FOK下单，"optimal_10_fok"：最优10档-FOK下单，"optimal_20_fok"：最优20档-FOK下单</param>
        /// <param name="tpTriggerPrice">止盈触发价格</param>
        /// <param name="tpOrderPrice">止盈委托价格（最优N档委托类型时无需填写价格）</param>
        /// <param name="tpOrderPriceType">止盈委托类型 不填默认为limit; 限价：limit ，最优5档：optimal_5，最优10档：optimal_10，最优20档：optimal_20</param>
        /// <param name="slTriggerPrice">止损触发价格</param>
        /// <param name="slOrderPrice">止损委托价格（最优N档委托类型时无需填写价格）</param>
        /// <param name="slOrderPriceType">止损委托类型	不填默认为limit; 限价：limit ，最优5档：optimal_5，最优10档：optimal_10，最优20档：optimal_20</param>
        /// <param name="pair">交易对	BTC-USDT</param>
        /// <param name="contractType">合约类型	swap（永续）、this_week（当周）、next_week（次周）、quarter（当季）、next_quarter（次季）</param>
        /// <param name="reduceOnly">是否为只减仓订单（该字段在双向持仓模式下无效，在单向持仓模式下不填默认为0。）	0:表示为非只减仓订单，1:表示为只减仓订单</param>
        /// <param name="clientOrderId">用户自定义单号</param>
        /// <param name="ct">[Optional] Cancellation token for cancelling the request</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapCrossOrder>> LinearSwapCrossOrderAsync(
            string contractCode,
            UmDirection direction,
            UmOffset? offset,
            decimal? price,
            UmLeverRate? leverRate,
            long volume,
            UmOrderPriceType orderPriceType,
            decimal? tpTriggerPrice,
            decimal? tpOrderPrice,
            UmOrderPriceType? tpOrderPriceType,
            decimal? slTriggerPrice,
            decimal? slOrderPrice,
            UmOrderPriceType? slOrderPriceType,
            string? pair = null,
            UmContractType? contractType = null,
            UmReduceOnly? reduceOnly = null,
            long? clientOrderId = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【逐仓】合约批量下单(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_batchorder"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#0da150a45a"/></para>
        /// </summary>
        /// <param name="huobiUsdtMarginedIsolatedOrderList">逐仓合约批量下单参数列表</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapIsolatedBatchOrder>> LinearSwapBatchorderAsync(IEnumerable<WWTHuobiUsdtMarginedIsolatedOrder> huobiUsdtMarginedIsolatedOrderList, CancellationToken ct = default);

        /// <summary>
        /// 
        /// 【全仓】合约批量下单(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_cross_batchorder"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#d6b14b4cdb"/></para>
        /// </summary>
        /// <param name="huobiUsdtMarginedCrossOrderList">全仓合约批量下单参数列表</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapCrossBatchOrder>> LinearSwapCrossBatchorderAsync(IEnumerable<WWTHuobiUsdtMarginedCrossOrder> huobiUsdtMarginedCrossOrderList, CancellationToken ct = default);

        /// <summary>
        /// 
        /// 【逐仓】撤销合约订单(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_cancel"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#7f144bc6d5"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码	"BTC-USDT" ...</param>
        /// <param name="orderIdList">订单ID(多个订单ID中间以","分隔,一次最多允许撤消10个订单)	</param>
        /// <param name="clientOrderIdList">客户订单ID(多个订单ID中间以","分隔,一次最多允许撤消10个订单)</param>
        /// order_id和client_order_id都可以用来撤单，至少要填写一个,同时只可以设置其中一种，如果设置了两种，默认以order_id来撤单。
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapIsolatedCancel>> LinearSwapCancelAsync(
            string contractCode,
            IEnumerable<long>? orderIdList = null,
            IEnumerable<long>? clientOrderIdList = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【全仓】撤销合约订单(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_cross_cancel"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#b031d94ff9"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码	"BTC-USDT" ...</param>
        /// <param name="orderIdList">订单ID(多个订单ID中间以","分隔,一次最多允许撤消10个订单)	</param>
        /// <param name="clientOrderIdList">客户订单ID(多个订单ID中间以","分隔,一次最多允许撤消10个订单)</param>
        /// order_id和client_order_id都可以用来撤单，至少要填写一个,同时只可以设置其中一种，如果设置了两种，默认以order_id来撤单。
        /// <param name="pair">交易对 BTC-USDT</param>
        /// <param name="contractType">合约类型 swap（永续）、this_week（当周）、next_week（次周）、quarter（当季）、next_quarter（次季）</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapCrossCancel>> LinearSwapCrossCancelAsync(
            string contractCode,
            IEnumerable<long>? orderIdList = null,
            IEnumerable<long>? clientOrderIdList = null,
            string? pair = null,
            string? contractType = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【逐仓】撤销全部合约单(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_cancelall"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#78ea900d9a"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码	"BTC-USDT" ...</param>
        /// <param name="direction">买卖方向（不填默认全部）	"buy":买 "sell":卖</param>
        /// <param name="offset">开平方向（不填默认全部）	"open":开 "close":平</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapIsolatedCancel>> LinearSwapCancelAllAsync(
            string contractCode,
            string? direction = null,
            string? offset = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【全仓】撤销全部合约单(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_cross_cancelall"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#fe509bd6b7"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码	"BTC-USDT" ...</param>
        /// <param name="pair">交易对 BTC-USDT</param>
        /// <param name="contractType">合约类型 swap（永续）、this_week（当周）、next_week（次周）、quarter（当季）、next_quarter（次季）</param>
        /// <param name="direction">买卖方向（不填默认全部）	"buy":买 "sell":卖</param>
        /// <param name="offset">开平方向（不填默认全部）	"open":开 "close":平</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapCrossCancel>> LinearSwapCrossCancelAllAsync(
            string contractCode,
            string? pair = null,
            string? contractType = null,
            string? direction = null,
            string? offset = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【逐仓】切换杠杆(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_switch_lever_rate"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#b006b3d147"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码	比如“BTC-USDT”</param>
        /// <param name="leverRate">要切换的杠杆倍数；高倍杠杆风险系数较大，请谨慎使用。</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapIsolatedSwitchLeverRate>> LinearSwapSwitchLeverRateAsync(
            string contractCode,
            int leverRate,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【全仓】切换杠杆(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_cross_switch_lever_rate"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#477e49bfc2"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码	永续："BTC-USDT"... , 交割："BTC-USDT-210625"...</param>
        /// <param name="leverRate">要切换的杠杆倍数；高倍杠杆风险系数较大，请谨慎使用。</param>
        /// <param name="pair">BTC-USDT</param>
        /// <param name="contractType">合约类型	swap（永续）、this_week（当周）、next_week（次周）、quarter（当季）、next_quarter（次季）</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapCrossSwitchLeverRate>> LinearSwapCrossSwitchLeverRateAsync(
            string contractCode,
            int leverRate,
            string? pair = null,
            string? contractType = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【逐仓】获取用户的合约订单信息(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_order_info"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#630c0b679f"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码	永续："BTC-USDT"... ，交割："BTC-USDT-210625"...</param>
        /// <param name="orderIdList">订单ID(多个订单ID中间以","分隔,一次最多允许查询50个订单)</param>
        /// <param name="clientOrderIdList">客户订单ID(多个订单ID中间以","分隔,一次最多允许查询50个订单)</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<WWTHuobiUsdtMarginedMarketSwapIsolatedOrderInfo>>> GetLinearSwapOrderInfoAsync(
            string contractCode,
            IEnumerable<long>? orderIdList = null,
            IEnumerable<long>? clientOrderIdList = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【全仓】获取用户的合约订单信息(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_cross_order_info"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#7fd98f1561"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码	永续："BTC-USDT"... ，交割："BTC-USDT-210625"...</param>
        /// <param name="orderIdList">订单ID(多个订单ID中间以","分隔,一次最多允许查询50个订单)</param>
        /// <param name="clientOrderIdList">客户订单ID(多个订单ID中间以","分隔,一次最多允许查询50个订单)</param>
        /// <param name="pair">交易对 BTC-USDT</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<WWTHuobiUsdtMarginedMarketSwapCrossOrderInfo>>> GetLinearSwapCrossOrderInfoAsync(
            string? contractCode = null,
            IEnumerable<long>? orderIdList = null,
            IEnumerable<long>? clientOrderIdList = null,
            string? pair = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【逐仓】获取用户的合约订单明细信息(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_order_detail"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#1fbc3d0734"/></para>
        /// </summary>
        /// <param name="orderId">订单id</param>
        /// <param name="contractCode">合约代码	"BTC-USDT"...</param>
        /// <param name="createdTimestamp">下单时间戳</param>
        /// <param name="orderType">订单类型 1:报单 、 2:撤单 、 3:强平 、4:交割 、22:ADL减仓单</param>
        /// <param name="pageIndex">第几页,不填第一页</param>
        /// <param name="pageSize">不填默认20，不得多于50</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapIsolatedOrderDetail>> GetLinearSwapOrderDetailAsync(
            long orderId,
            string contractCode,
            long? createdTimestamp = null,
            int? orderType = null,
            int? pageIndex = null,
            int? pageSize = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【全仓】获取用户的合约订单明细信息(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_cross_order_detail"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#361d5e2049"/></para>
        /// </summary>
        /// <param name="orderId">订单id</param>
        /// <param name="contractCode">合约代码	"BTC-USDT"...</param>
        /// <param name="pair">交易对	BTC-USDT</param>
        /// <param name="createdTimestamp">下单时间戳</param>
        /// <param name="orderType">订单类型 1:报单 、 2:撤单 、 3:强平 、4:交割 、22:ADL减仓单</param>
        /// <param name="pageIndex">第几页,不填第一页</param>
        /// <param name="pageSize">不填默认20，不得多于50</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapCrossOrderDetail>> GetLinearSwapCrossOrderDetailAsync(
            long orderId,
            string? contractCode = null,
            string? pair = null,
            long? createdTimestamp = null,
            int? orderType = null,
            int? pageIndex = null,
            int? pageSize = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【逐仓】获取用户的合约当前未成交委托(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_openorders"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#136259e73a"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码	"BTC-USDT"...</param>
        /// <param name="pageIndex">第几页,不填第一页</param>
        /// <param name="pageSize">不填默认20，不得多于50</param>
        /// <param name="sortBy">排序字段，不填默认按创建时间倒序	“created_at”(按照创建时间倒序)，“update_time”(按照更新时间倒序)</param>
        /// <param name="tradeType">交易类型，不填默认查询全部	0:全部, 1:买入开多, 2: 卖出开空, 3: 买入平空, 4: 卖出平多, 17：买入（单向持仓）, 18：卖出（单向持仓）</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapIsolatedOpenOrders>> GetLinearSwapOpenordersAsync(
            string contractCode,
            int? pageIndex = null,
            int? pageSize = null,
            string? sortBy = null,
            int? tradeType = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【全仓】获取用户的合约当前未成交委托(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_cross_openorders"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#49d96ae2a4"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码	"BTC-USDT"...</param>
        /// <param name="pair">交易对	BTC-USDT</param>
        /// <param name="pageIndex">第几页,不填第一页</param>
        /// <param name="pageSize">不填默认20，不得多于50</param>
        /// <param name="sortBy">排序字段，不填默认按创建时间倒序	“created_at”(按照创建时间倒序)，“update_time”(按照更新时间倒序)</param>
        /// <param name="tradeType">交易类型，不填默认查询全部	0:全部, 1:买入开多, 2: 卖出开空, 3: 买入平空, 4: 卖出平多, 17：买入（单向持仓）, 18：卖出（单向持仓）</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapCrossOpenOrders>> GetLinearSwapCrossOpenordersAsync(
            string? contractCode = null,
            string? pair = null,
            int? pageIndex = null,
            int? pageSize = null,
            string? sortBy = null,
            int? tradeType = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【逐仓】获取用户的合约历史委托(PrivateData)
        /// <para><a href="POST /linear-swap-api/v3/swap_hisorders"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#419ab006eb"/></para>
        /// </summary>
        /// <param name="tradeType">交易类型 0:全部, 1:买入开多, 2:卖出开空, 3:买入平空, 4:卖出平多, 5:卖出强平, 6:买入强平, 17：买入（单向持仓）, 18：卖出（单向持仓）</param>
        /// <param name="type">类型	1:所有订单,2:结束状态的订单	</param>
        /// <param name="status">订单状态 可查询多个状态，"3,4,5" , 0:全部,3:未成交, 4: 部分成交,5: 部分成交已撤单,6: 全部成交,7:已撤单	</param>
        /// <param name="contractCode">合约代码 contract_code</param>
        /// <param name="startTime">查询开始时间, 以数据按创建时间进行查询	(now) – 48h	取值范围 [((end-time) – 48h), (end-time)] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="endTime">查询结束时间, 以数据按创建时间进行查询	now	取值范围 [(present-90d), present] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="direct">查询方向, 方向为next时，数据按照时间正序排列返回，方向为prev时，数据按照时间倒序返回	next	prev表示向前查询，next表示向后查询。</param>
        /// <param name="fromId">如果是向前(prev)查询，则赋值为上一次查询结果中得到的最小query_id ；如果是向后(next)查询，则赋值为上一次查询结果中得到的最大query_id	</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<WWTHuobiUsdtMarginedMarketSwapIsolatedHisOrder>>> GetLinearSwapHisordersAsync(
            int tradeType,
            int type,
            string status,
            string? contractCode = null,
            long? startTime = null,
            long? endTime = null,
            string? direct = null,
            long? fromId = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【全仓】获取用户的合约历史委托(PrivateData)
        /// <para><a href="POST /linear-swap-api/v3/swap_cross_hisorders"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#c0bfb4f832"/></para>
        /// </summary>
        /// <param name="tradeType">交易类型 0:全部, 1:买入开多, 2:卖出开空, 3:买入平空, 4:卖出平多, 5:卖出强平, 6:买入强平, 17：买入（单向持仓）, 18：卖出（单向持仓）</param>
        /// <param name="type">类型	1:所有订单,2:结束状态的订单	</param>
        /// <param name="status">订单状态 可查询多个状态，"3,4,5" , 0:全部,3:未成交, 4: 部分成交,5: 部分成交已撤单,6: 全部成交,7:已撤单	</param>
        /// <param name="contractCode">合约代码 contract_code</param>
        /// <param name="pair">交易对 BTC-USDT</param>
        /// <param name="startTime">查询开始时间, 以数据按创建时间进行查询	(now) – 48h	取值范围 [((end-time) – 48h), (end-time)] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="endTime">查询结束时间, 以数据按创建时间进行查询	now	取值范围 [(present-90d), present] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="direct">查询方向, 方向为next时，数据按照时间正序排列返回，方向为prev时，数据按照时间倒序返回	next	prev表示向前查询，next表示向后查询。</param>
        /// <param name="fromId">如果是向前(prev)查询，则赋值为上一次查询结果中得到的最小query_id ；如果是向后(next)查询，则赋值为上一次查询结果中得到的最大query_id	</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<WWTHuobiUsdtMarginedMarketSwapCrossHisOrder>>> GetLinearSwapCrossHisordersAsync(
            int tradeType,
            int type,
            string status,
            string? contractCode = null,
            string? pair = null,
            long? startTime = null,
            long? endTime = null,
            string? direct = null,
            long? fromId = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【逐仓】组合查询合约历史委托(PrivateData)
        /// <para><a href="POST /linear-swap-api/v3/swap_hisorders_exact"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#af7b8dd177"/></para>
        /// </summary>
        /// <param name="tradeType">交易类型		0:全部, 1:买入开多, 2:卖出开空, 3:买入平空, 4:卖出平多, 5:卖出强平, 6:买入强平, 17：买入（单向持仓）, 18：卖出（单向持仓）</param>
        /// <param name="type">类型	1:所有订单,2:结束状态的订单</param>
        /// <param name="status">订单状态	可查询多个状态，"3,4,5" , 0:全部,3:未成交, 4: 部分成交,5: 部分成交已撤单,6: 全部成交,7:已撤单	</param>
        /// <param name="contractCode">合约代码			contract_code</param>
        /// <param name="pair">交易对		BTC-USDT</param>
        /// <param name="startTime">查询开始时间, 以数据按创建时间进行查询	(now) – 48h	取值范围 [((end-time) – 48h), (end-time)] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="endTime">查询结束时间, 以数据按创建时间进行查询	now	取值范围 [(present-90d), present] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="direct">查询方向, 方向为next时，数据按照时间正序排列返回，方向为prev时，数据按照时间倒序返回	next	prev表示向前查询，next表示向后查询。	</param>
        /// <param name="fromId">如果是向前(prev)查询，则赋值为上一次查询结果中得到的最小query_id ；如果是向后(next)查询，则赋值为上一次查询结果中得到的最大query_id	</param>
        /// <param name="priceType">订单报价类型	订单报价类型 "limit":限价，"opponent":对手价 ，"post_only":只做maker单,post only下单只受用户持仓数量限制,"optimal_5"：最优5档，"optimal_10"：最优10档，"optimal_20"：最优20档，"ioc":IOC订单，"fok"：FOK订单, "opponent_ioc"： 对手价-IOC下单，"optimal_5_ioc"：最优5档-IOC下单，"optimal_10_ioc"：最优10档-IOC下单，"optimal_20_ioc"：最优20档-IOC下单,"opponent_fok"： 对手价-FOK下单，"optimal_5_fok"：最优5档-FOK下单，"optimal_10_fok"：最优10档-FOK下单，"optimal_20_fok"：最优20档-FOK下单		order_price_type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<WWTHuobiUsdtMarginedMarketSwapIsolatedHisOrder>>> GetLinearSwapHisordersExactAsync(
            int tradeType,
            int type,
            string status,
            string? contractCode = null,
            string? pair = null,
            long? startTime = null,
            long? endTime = null,
            string? direct = null,
            long? fromId = null,
            string? priceType = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【全仓】组合查询合约历史委托(PrivateData)
        /// <para><a href="POST /linear-swap-api/v3/swap_cross_hisorders_exact"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#2e2b4d2c3f"/></para>
        /// </summary>
        /// <param name="tradeType">交易类型		0:全部, 1:买入开多, 2:卖出开空, 3:买入平空, 4:卖出平多, 5:卖出强平, 6:买入强平, 17：买入（单向持仓）, 18：卖出（单向持仓）</param>
        /// <param name="type">类型	1:所有订单,2:结束状态的订单</param>
        /// <param name="status">订单状态	可查询多个状态，"3,4,5" , 0:全部,3:未成交, 4: 部分成交,5: 部分成交已撤单,6: 全部成交,7:已撤单	</param>
        /// <param name="contractCode">合约代码			contract_code</param>
        /// <param name="pair">交易对		BTC-USDT</param>
        /// <param name="startTime">查询开始时间, 以数据按创建时间进行查询	(now) – 48h	取值范围 [((end-time) – 48h), (end-time)] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="endTime">查询结束时间, 以数据按创建时间进行查询	now	取值范围 [(present-90d), present] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="direct">查询方向, 方向为next时，数据按照时间正序排列返回，方向为prev时，数据按照时间倒序返回	next	prev表示向前查询，next表示向后查询。	</param>
        /// <param name="fromId">如果是向前(prev)查询，则赋值为上一次查询结果中得到的最小query_id ；如果是向后(next)查询，则赋值为上一次查询结果中得到的最大query_id	</param>
        /// <param name="priceType">订单报价类型	订单报价类型 "limit":限价，"opponent":对手价 ，"post_only":只做maker单,post only下单只受用户持仓数量限制,"optimal_5"：最优5档，"optimal_10"：最优10档，"optimal_20"：最优20档，"ioc":IOC订单，"fok"：FOK订单, "opponent_ioc"： 对手价-IOC下单，"optimal_5_ioc"：最优5档-IOC下单，"optimal_10_ioc"：最优10档-IOC下单，"optimal_20_ioc"：最优20档-IOC下单,"opponent_fok"： 对手价-FOK下单，"optimal_5_fok"：最优5档-FOK下单，"optimal_10_fok"：最优10档-FOK下单，"optimal_20_fok"：最优20档-FOK下单		order_price_type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<WWTHuobiUsdtMarginedMarketSwapCrossHisOrder>>> GetLinearSwapCrossHisordersExactAsync(
            int tradeType,
            int type,
            string status,
            string? contractCode = null,
            string? pair = null,
            long? startTime = null,
            long? endTime = null,
            string? direct = null,
            long? fromId = null,
            string? priceType = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【逐仓】获取用户的合约历史成交记录(PrivateData)
        /// <para><a href="POST /linear-swap-api/v3/swap_matchresults"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#3d3462611f"/></para>
        /// </summary>
        /// <param name="tradeType">交易类型		0:全部, 1:买入开多, 2:卖出开空, 3:买入平空, 4:卖出平多, 5:卖出强平, 6:买入强平, 17：买入（单向持仓）, 18：卖出（单向持仓）</param>
        /// <param name="contractCode">合约代码			contract_code</param>
        /// <param name="pair">交易对		BTC-USDT</param>
        /// <param name="startTime">查询开始时间, 以数据按创建时间进行查询	(now) – 48h	取值范围 [((end-time) – 48h), (end-time)] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="endTime">查询结束时间, 以数据按创建时间进行查询	now	取值范围 [(present-90d), present] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="direct">查询方向, 方向为next时，数据按照时间正序排列返回，方向为prev时，数据按照时间倒序返回	next	prev表示向前查询，next表示向后查询。	</param>
        /// <param name="fromId">如果是向前(prev)查询，则赋值为上一次查询结果中得到的最小query_id ；如果是向后(next)查询，则赋值为上一次查询结果中得到的最大query_id	</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<WWTHuobiUsdtMarginedMarketSwapIsolatedMatchResults>>> GetLinearSwapMatchresultsAsync(
            int tradeType,
            string? contractCode = null,
            string? pair = null,
            long? startTime = null,
            long? endTime = null,
            string? direct = null,
            long? fromId = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【全仓】获取用户的合约历史成交记录(PrivateData)
        /// <para><a href="POST /linear-swap-api/v3/swap_cross_matchresults"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#1988305944"/></para>
        /// </summary>
        /// <param name="tradeType">交易类型		0:全部, 1:买入开多, 2:卖出开空, 3:买入平空, 4:卖出平多, 5:卖出强平, 6:买入强平, 17：买入（单向持仓）, 18：卖出（单向持仓）</param>
        /// <param name="contractCode">合约代码			contract_code</param>
        /// <param name="pair">交易对		BTC-USDT</param>
        /// <param name="startTime">查询开始时间, 以数据按创建时间进行查询	(now) – 48h	取值范围 [((end-time) – 48h), (end-time)] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="endTime">查询结束时间, 以数据按创建时间进行查询	now	取值范围 [(present-90d), present] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="direct">查询方向, 方向为next时，数据按照时间正序排列返回，方向为prev时，数据按照时间倒序返回	next	prev表示向前查询，next表示向后查询。	</param>
        /// <param name="fromId">如果是向前(prev)查询，则赋值为上一次查询结果中得到的最小query_id ；如果是向后(next)查询，则赋值为上一次查询结果中得到的最大query_id	</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<WWTHuobiUsdtMarginedMarketSwapCrossMatchResults>>> GetLinearSwapCrossMatchresultsAsync(
            int tradeType,
            string? contractCode = null,
            string? pair = null,
            long? startTime = null,
            long? endTime = null,
            string? direct = null,
            long? fromId = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【逐仓】组合查询用户历史成交记录(PrivateData)
        /// <para><a href="POST /linear-swap-api/v3/swap_matchresults_exact"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#a67a844403"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码			contract_code</param>
        /// <param name="tradeType">交易类型		0:全部, 1:买入开多, 2:卖出开空, 3:买入平空, 4:卖出平多, 5:卖出强平, 6:买入强平, 17：买入（单向持仓）, 18：卖出（单向持仓）</param>
        /// <param name="startTime">查询开始时间, 以数据按创建时间进行查询	(now) – 48h	取值范围 [((end-time) – 48h), (end-time)] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="endTime">查询结束时间, 以数据按创建时间进行查询	now	取值范围 [(present-90d), present] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="direct">查询方向, 方向为next时，数据按照时间正序排列返回，方向为prev时，数据按照时间倒序返回	next	prev表示向前查询，next表示向后查询。	</param>
        /// <param name="fromId">如果是向前(prev)查询，则赋值为上一次查询结果中得到的最小query_id ；如果是向后(next)查询，则赋值为上一次查询结果中得到的最大query_id	</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<WWTHuobiUsdtMarginedMarketSwapIsolatedMatchResults>>> GetLinearSwapMatchresultsExactAsync(
            string contractCode,
            int tradeType,
            long? startTime = null,
            long? endTime = null,
            string? direct = null,
            long? fromId = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【全仓】组合查询用户历史成交记录(PrivateData)
        /// <para><a href="POST /linear-swap-api/v3/swap_cross_matchresults_exact"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#f2189d089d"/></para>
        /// </summary>
        /// <param name="tradeType">交易类型		0:全部, 1:买入开多, 2:卖出开空, 3:买入平空, 4:卖出平多, 5:卖出强平, 6:买入强平, 17：买入（单向持仓）, 18：卖出（单向持仓）</param>
        /// <param name="contractCode">合约代码			contract_code</param>
        /// <param name="pair">交易对		BTC-USDT</param>
        /// <param name="startTime">查询开始时间, 以数据按创建时间进行查询	(now) – 48h	取值范围 [((end-time) – 48h), (end-time)] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="endTime">查询结束时间, 以数据按创建时间进行查询	now	取值范围 [(present-90d), present] ，查询窗口最大为48小时，窗口平移范围为最近90天。</param>
        /// <param name="direct">查询方向, 方向为next时，数据按照时间正序排列返回，方向为prev时，数据按照时间倒序返回	next	prev表示向前查询，next表示向后查询。	</param>
        /// <param name="fromId">如果是向前(prev)查询，则赋值为上一次查询结果中得到的最小query_id ；如果是向后(next)查询，则赋值为上一次查询结果中得到的最大query_id	</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<WWTHuobiUsdtMarginedMarketSwapCrossMatchResults>>> GetLinearSwapCrossMatchresultsExactAsync(
            int tradeType,
            string? contractCode = null,
            string? pair = null,
            long? startTime = null,
            long? endTime = null,
            string? direct = null,
            long? fromId = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【逐仓】合约闪电平仓下单(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_lightning_close_position"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#26f085577d"/></para>
        /// </summary>
        /// <param name="contractCode">合约代码	"BTC-USDT"...</param>
        /// <param name="volume">委托数量（张）</param>
        /// <param name="direction">买卖方向	“buy”:买，“sell”:卖</param>
        /// <param name="clientOrderId">（API）客户自己填写和维护，必须为数字	[1-9223372036854775807]</param>
        /// <param name="orderPriceType">订单报价类型	不填，默认为“闪电平仓”，"lightning"：闪电平仓，"lightning_ioc"：闪电平仓-IOC，"lightning_fok"：闪电平仓-FOK</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapIsolatedOrder>> LinearSwapLightningClosePositionAsync(
            string contractCode,
            long volume,
            string direction,
            long? clientOrderId = null,
            string? orderPriceType = null,
            CancellationToken ct = default
            );

        /// <summary>
        /// 
        /// 【全仓】合约闪电平仓下单(PrivateData)
        /// <para><a href="POST /linear-swap-api/v1/swap_cross_lightning_close_position"/></para>
        /// <para><a href="https://huobiapi.github.io/docs/usdt_swap/v1/cn/#5fa03808b7"/></para>
        /// </summary>
        /// <param name="volume">委托数量（张）</param>
        /// <param name="direction">买卖方向	“buy”:买，“sell”:卖</param>
        /// <param name="contractCode">合约代码	"BTC-USDT"...</param>
        /// <param name="pair">交易对	BTC-USDT</param>
        /// <param name="contractType">合约类型	swap（永续）、this_week（当周）、next_week（次周）、quarter（当季）、next_quarter（次季）</param>
        /// <param name="clientOrderId">（API）客户自己填写和维护，必须为数字	[1-9223372036854775807]</param>
        /// <param name="orderPriceType">订单报价类型	不填，默认为“闪电平仓”，"lightning"：闪电平仓，"lightning_ioc"：闪电平仓-IOC，"lightning_fok"：闪电平仓-FOK</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<WWTHuobiUsdtMarginedMarketSwapCrossOrder>> LinearSwapCrossLightningClosePositionAsync(
            long volume,
            string direction,
            string? contractCode = null,
            string? pair = null,
            string? contractType = null,
            long? clientOrderId = null,
            string? orderPriceType = null,
            CancellationToken ct = default
            );
    }
}