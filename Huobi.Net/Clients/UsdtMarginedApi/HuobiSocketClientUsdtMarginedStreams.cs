﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Huobi.Net.Converters;
using Huobi.Net.Enums;
using Huobi.Net.Interfaces.Clients.UsdtMargined;
using Huobi.Net.Objects;
using Huobi.Net.Objects.Internal;
using Huobi.Net.Objects.Models;
using Huobi.Net.Objects.Models.Socket;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HuobiOrderUpdate = Huobi.Net.Objects.Models.Socket.HuobiOrderUpdate;

namespace Huobi.Net.Clients.UsdtMargined
{
    /// <inheritdoc />
    public class HuobiSocketClientUsdtMarginedStreams : SocketApiClient, IHuobiSocketClientUsdtMarginedStreams
    {
        #region fields
        private readonly string baseAddressAuthenticated;
        private readonly string baseAddressMbp;

        private readonly HuobiUsdtMarginedSocketClient _baseClient;
        private readonly Log _log;
        #endregion

        #region ctor
        internal HuobiSocketClientUsdtMarginedStreams(Log log, HuobiUsdtMarginedSocketClient baseClient, HuobiUsdtMarginedSocketClientOptions options)
            : base(options, options.UsdtMarginedStreamsOptions)
        {
            _log = log;
            _baseClient = baseClient;
            baseAddressAuthenticated = options.UsdtMarginedStreamsOptions.BaseAddressAuthenticated;
            baseAddressMbp = options.UsdtMarginedStreamsOptions.BaseAddressInrementalOrderBook;
        }

        #endregion

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new HuobiAuthenticationProvider(credentials, false);

        #region methods

        ///// <inheritdoc />
        //public async Task<CallResult<HuobiOrderBook>> GetOrderBookWithMergeStepAsync(string symbol, int mergeStep)
        //{
        //    symbol = symbol.ValidateHuobiSymbol();
        //    mergeStep.ValidateIntBetween(nameof(mergeStep), 0, 5);

        //    var request = new HuobiSocketRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), $"market.{symbol}.depth.step{mergeStep}");
        //    var result = await _baseClient.QueryInternalAsync<HuobiSocketResponse<HuobiOrderBook>>(this, request, false).ConfigureAwait(false);
        //    if (!result)
        //        return new CallResult<HuobiOrderBook>(result.Error!);

        //    result.Data.Data.Timestamp = result.Data.Timestamp;
        //    return new CallResult<HuobiOrderBook>(result.Data.Data);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<HuobiIncementalOrderBook>> GetOrderBookAsync(string symbol, int levels)
        //{
        //    symbol = symbol.ValidateHuobiSymbol();
        //    levels.ValidateIntValues(nameof(levels), 5, 20, 150, 400);

        //    var request = new HuobiSocketRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), $"market.{symbol}.mbp.{levels}");
        //    var result = await _baseClient.QueryInternalAsync<HuobiSocketResponse<HuobiIncementalOrderBook>>(this, baseAddressMbp, request, false).ConfigureAwait(false);
        //    if (!result)
        //        return new CallResult<HuobiIncementalOrderBook>(result.Error!);

        //    if (result.Data.Data == null)
        //    {
        //        var info = "No data received when requesting order book. " +
        //            "Levels 5/20 are only supported for a subset of symbols, see https://huobiapi.github.io/docs/spot/v1/en/#market-by-price-incremental-update. Use 150 level instead.";
        //        _log.Write(LogLevel.Debug, info);
        //        return new CallResult<HuobiIncementalOrderBook>(new ServerError(info));
        //    }

        //    return new CallResult<HuobiIncementalOrderBook>(result.Data.Data);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<UpdateSubscription>> SubscribeToPartialOrderBookUpdates1SecondAsync(string symbol, int mergeStep, Action<DataEvent<HuobiOrderBook>> onData, CancellationToken ct = default)
        //{
        //    symbol = symbol.ValidateHuobiSymbol();
        //    mergeStep.ValidateIntBetween(nameof(mergeStep), 0, 5);

        //    var internalHandler = new Action<DataEvent<HuobiDataEvent<HuobiOrderBook>>>(data =>
        //    {
        //        data.Data.Timestamp = data.Timestamp;
        //        onData(data.As(data.Data.Data, symbol));
        //    });

        //    var request = new HuobiSubscribeRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), $"market.{symbol}.depth.step{mergeStep}");
        //    return await _baseClient.SubscribeInternalAsync(this, request, null, false, internalHandler, ct).ConfigureAwait(false);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<UpdateSubscription>> SubscribeToPartialOrderBookUpdates100MilisecondAsync(string symbol, int levels, Action<DataEvent<HuobiOrderBook>> onData, CancellationToken ct = default)
        //{
        //    symbol = symbol.ValidateHuobiSymbol();
        //    levels.ValidateIntValues(nameof(levels), 5, 10, 20);

        //    var internalHandler = new Action<DataEvent<HuobiDataEvent<HuobiOrderBook>>>(data =>
        //    {
        //        data.Data.Timestamp = data.Timestamp;
        //        onData(data.As(data.Data.Data, symbol));
        //    });

        //    var request = new HuobiSubscribeRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), $"market.{symbol}.mbp.refresh.{levels}");
        //    return await _baseClient.SubscribeInternalAsync(this, request, null, false, internalHandler, ct).ConfigureAwait(false);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBookChangeUpdatesAsync(string symbol, int levels, Action<DataEvent<HuobiIncementalOrderBook>> onData, CancellationToken ct = default)
        //{
        //    symbol = symbol.ValidateHuobiSymbol();
        //    levels.ValidateIntValues(nameof(levels), 5, 20, 150, 400);

        //    var internalHandler = new Action<DataEvent<HuobiDataEvent<HuobiIncementalOrderBook>>>(data =>
        //    {
        //        data.Data.Timestamp = data.Timestamp;
        //        onData(data.As(data.Data.Data, symbol));
        //    });

        //    var request = new HuobiSubscribeRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), $"market.{symbol}.mbp.{levels}");
        //    return await _baseClient.SubscribeInternalAsync(this, baseAddressMbp, request, null, false, internalHandler, ct).ConfigureAwait(false);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<IEnumerable<HuobiSymbolTradeDetails>>> GetTradeHistoryAsync(string symbol)
        //{
        //    symbol = symbol.ValidateHuobiSymbol();
        //    var request = new HuobiSocketRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), $"market.{symbol}.trade.detail");
        //    var result = await _baseClient.QueryInternalAsync<HuobiSocketResponse<IEnumerable<HuobiSymbolTradeDetails>>>(this, request, false).ConfigureAwait(false);
        //    return result ? result.As(result.Data.Data) : result.AsError<IEnumerable<HuobiSymbolTradeDetails>>(result.Error!);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<HuobiSymbolTrade>> onData, CancellationToken ct = default)
        //{
        //    symbol = symbol.ValidateHuobiSymbol();
        //    var request = new HuobiSubscribeRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), $"market.{symbol}.trade.detail");
        //    var internalHandler = new Action<DataEvent<HuobiDataEvent<HuobiSymbolTrade>>>(data => onData(data.As(data.Data.Data, symbol)));
        //    return await _baseClient.SubscribeInternalAsync(this, request, null, false, internalHandler, ct).ConfigureAwait(false);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<HuobiSymbolDetails>> GetSymbolDetailsAsync(string symbol)
        //{
        //    symbol = symbol.ValidateHuobiSymbol();
        //    var request = new HuobiSocketRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), $"market.{symbol}.detail");
        //    var result = await _baseClient.QueryInternalAsync<HuobiSocketResponse<HuobiSymbolDetails>>(this, request, false).ConfigureAwait(false);
        //    if (!result)
        //        return result.AsError<HuobiSymbolDetails>(result.Error!);

        //    result.Data.Data.Timestamp = result.Data.Timestamp;
        //    return result.As(result.Data.Data);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<UpdateSubscription>> SubscribeToSymbolDetailUpdatesAsync(string symbol, Action<DataEvent<HuobiSymbolDetails>> onData, CancellationToken ct = default)
        //{
        //    symbol = symbol.ValidateHuobiSymbol();
        //    var request = new HuobiSubscribeRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), $"market.{symbol}.detail");
        //    var internalHandler = new Action<DataEvent<HuobiDataEvent<HuobiSymbolDetails>>>(data =>
        //    {
        //        data.Data.Timestamp = data.Timestamp;
        //        onData(data.As(data.Data.Data, symbol));
        //    });
        //    return await _baseClient.SubscribeInternalAsync(this, request, null, false, internalHandler, ct).ConfigureAwait(false);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(Action<DataEvent<HuobiSymbolDatas>> onData, CancellationToken ct = default)
        //{
        //    var request = new HuobiSubscribeRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), "market.tickers");
        //    var internalHandler = new Action<DataEvent<HuobiDataEvent<IEnumerable<HuobiSymbolTicker>>>>(data =>
        //    {
        //        var result = new HuobiSymbolDatas { Timestamp = data.Timestamp, Ticks = data.Data.Data };
        //        onData(data.As(result));
        //    });
        //    return await _baseClient.SubscribeInternalAsync(this, request, null, false, internalHandler, ct).ConfigureAwait(false);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<HuobiSymbolTick>> onData, CancellationToken ct = default)
        //{
        //    var request = new HuobiSubscribeRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), $"market.{symbol}.ticker");
        //    var internalHandler = new Action<DataEvent<HuobiDataEvent<HuobiSymbolTick>>>(data =>
        //    {
        //        data.Data.Data.Symbol = symbol;
        //        onData(data.As(data.Data.Data));
        //    });
        //    return await _baseClient.SubscribeInternalAsync(this, request, null, false, internalHandler, ct).ConfigureAwait(false);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<UpdateSubscription>> SubscribeToBestOfferUpdatesAsync(string symbol, Action<DataEvent<HuobiBestOffer>> onData, CancellationToken ct = default)
        //{
        //    var request = new HuobiSubscribeRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), $"market.{symbol}.bbo");
        //    var internalHandler = new Action<DataEvent<HuobiDataEvent<HuobiBestOffer>>>(data =>
        //    {
        //        onData(data.As(data.Data.Data, symbol));
        //    });
        //    return await _baseClient.SubscribeInternalAsync(this, request, null, false, internalHandler, ct).ConfigureAwait(false);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(
        //    string? symbol = null,
        //    Action<DataEvent<HuobiSubmittedOrderUpdate>>? onOrderSubmitted = null,
        //    Action<DataEvent<HuobiMatchedOrderUpdate>>? onOrderMatched = null,
        //    Action<DataEvent<HuobiCanceledOrderUpdate>>? onOrderCancelation = null,
        //    Action<DataEvent<HuobiTriggerFailureOrderUpdate>>? onConditionalOrderTriggerFailure = null,
        //    Action<DataEvent<HuobiOrderUpdate>>? onConditionalOrderCanceled = null,
        //    CancellationToken ct = default)
        //{
        //    symbol = symbol?.ValidateHuobiSymbol();
        //    var request = new HuobiAuthenticatedSubscribeRequest($"orders#{symbol ?? "*"}");
        //    var internalHandler = new Action<DataEvent<JToken>>(data =>
        //    {
        //        if (data.Data["data"] == null || data.Data["data"]!["eventType"] == null)
        //        {
        //            _log.Write(LogLevel.Warning, "Invalid order update data: " + data);
        //            return;
        //        }

        //        var eventType = data.Data["data"]!["eventType"]?.ToString();
        //        var symbol = data.Data["data"]!["symbol"]?.ToString();
        //        if (eventType == "trigger")
        //            DeserializeAndInvoke(data, onConditionalOrderTriggerFailure, symbol);

        //        else if (eventType == "deletion")
        //            DeserializeAndInvoke(data, onConditionalOrderCanceled, symbol);

        //        else if (eventType == "creation")
        //            DeserializeAndInvoke(data, onOrderSubmitted, symbol);

        //        else if (eventType == "trade")
        //            DeserializeAndInvoke(data, onOrderMatched, symbol);

        //        else if (eventType == "cancellation")
        //            DeserializeAndInvoke(data, onOrderCancelation, symbol);
        //        else
        //        {
        //            _log.Write(LogLevel.Warning, "Unknown order event type: " + eventType);
        //        }
        //    });
        //    return await _baseClient.SubscribeInternalAsync(this, baseAddressAuthenticated, request, null, true, internalHandler, ct).ConfigureAwait(false);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<HuobiAccountUpdate>> onAccountUpdate, int? updateMode = null, CancellationToken ct = default)
        //{
        //    if (updateMode != null && (updateMode > 2 || updateMode < 0))
        //        throw new ArgumentException("UpdateMode should be either 0, 1 or 2");

        //    var request = new HuobiAuthenticatedSubscribeRequest("accounts.update#" + (updateMode ?? 1));
        //    var internalHandler = new Action<DataEvent<JToken>>(data =>
        //    {
        //        DeserializeAndInvoke(data, onAccountUpdate);
        //    });
        //    return await _baseClient.SubscribeInternalAsync(this, baseAddressAuthenticated, request, null, true, internalHandler, ct).ConfigureAwait(false);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<UpdateSubscription>> SubscribeToOrderDetailsUpdatesAsync(string? symbol = null, Action<DataEvent<HuobiTradeUpdate>>? onOrderMatch = null, Action<DataEvent<HuobiOrderCancelationUpdate>>? onOrderCancel = null, CancellationToken ct = default)
        //{
        //    var request = new HuobiAuthenticatedSubscribeRequest($"trade.clearing#{symbol ?? "*"}#1");
        //    var internalHandler = new Action<DataEvent<JToken>>(data =>
        //    {
        //        if (data.Data["data"] == null || data.Data["data"]!["eventType"] == null)
        //        {
        //            _log.Write(LogLevel.Warning, "Invalid order update data: " + data);
        //            return;
        //        }

        //        var eventType = data.Data["data"]!["eventType"]?.ToString();
        //        var symbol = data.Data["data"]!["symbol"]?.ToString();
        //        if (eventType == "trade")
        //            DeserializeAndInvoke(data, onOrderMatch, symbol);
        //        else if (eventType == "cancellation")
        //            DeserializeAndInvoke(data, onOrderCancel, symbol);
        //        else
        //        {
        //            _log.Write(LogLevel.Warning, "Unknown order details event type: " + eventType);
        //        }
        //    });
        //    return await _baseClient.SubscribeInternalAsync(this, baseAddressAuthenticated, request, null, true, internalHandler, ct).ConfigureAwait(false);
        //}

        ///// <inheritdoc />
        //public async Task<CallResult<IEnumerable<HuobiSpecifiedTimeKLine>>> GetSpecifiedTimeKLinesAsync(string symbol, KlineInterval period, long startTimeStamp, long endTimeStamp)
        //{
        //    symbol = symbol.ValidateHuobiSymbol();
        //    var request = new HuobiSocketRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), $"market.{symbol}.kline.{JsonConvert.SerializeObject(period, new PeriodConverter(false))}", startTimeStamp, endTimeStamp);
        //    CallResult<HuobiSocketResponse<IEnumerable<HuobiSpecifiedTimeKLine>>>? result = await _baseClient.QueryInternalAsync<HuobiSocketResponse<IEnumerable<HuobiSpecifiedTimeKLine>>>(this, request, false).ConfigureAwait(false);
        //    return result ? result.As(result.Data.Data) : result.AsError<IEnumerable<HuobiSpecifiedTimeKLine>>(result.Error!);
        //}

        #region WebSocket市场行情接口
        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeMarketContractCodeKlineAsync(string contractCode, KlineInterval period, string clientId, Action<DataEvent<HuobiContractCodeKlineTick>> onData, CancellationToken ct = default)
        {
            contractCode = contractCode.ValidateHuobiContractCode();
            HuobiSubscribeRequest? request = new HuobiSubscribeRequest
                (
                _baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture),
                $"market.{contractCode}.kline.{JsonConvert.SerializeObject(period, new PeriodConverter(false))}"
                );
            Action<DataEvent<HuobiDataEvent<HuobiContractCodeKlineTick>>>? internalHandler = new Action<DataEvent<HuobiDataEvent<HuobiContractCodeKlineTick>>>
                (
                data =>
                onData(data.As(data.Data.Data, contractCode))
                );
            return await _baseClient.SubscribeInternalAsync(this, request, null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<IEnumerable<HuobiContractCodeKlineTick>>> GetMarketContractCodeKlineAsync(string contractCode, KlineInterval period, string clientId, long from, long to)
        {
            contractCode = contractCode.ValidateHuobiContractCode();
            var request = new HuobiSocketRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), $"market.{contractCode}.kline.{JsonConvert.SerializeObject(period, new PeriodConverter(false))}", from, to);
            var result = await _baseClient.QueryInternalAsync<HuobiSocketResponse<IEnumerable<HuobiContractCodeKlineTick>>>(this, request, false).ConfigureAwait(false);
            return result ? result.As(result.Data.Data) : result.AsError<IEnumerable<HuobiContractCodeKlineTick>>(result.Error!);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeMarketContractCodeDepthAsync(string contractCode, string type, string clientId, Action<DataEvent<HuobiContractCodeDepthTick>> onData, CancellationToken ct = default)
        {
            contractCode = contractCode.ValidateHuobiContractCode();
            HuobiSubscribeRequest? request = new HuobiSubscribeRequest
                (
                _baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture),
                $"market.{contractCode}.depth.{type}"
                );
            Action<DataEvent<HuobiDataEvent<HuobiContractCodeDepthTick>>>? internalHandler = new Action<DataEvent<HuobiDataEvent<HuobiContractCodeDepthTick>>>
                (
                data =>
                onData(data.As(data.Data.Data, contractCode))
                );
            return await _baseClient.SubscribeInternalAsync(this, request, null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeMarketContractCodeIncrementalDepthAsync(string contractCode, string size, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            contractCode = contractCode.ValidateHuobiContractCode();
            HuobiSubscribeRequest? request = new HuobiSubscribeRequest
                (
                _baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture),
                $"market.{contractCode}.depth.size_{size}.high_freq"
                );
            Action<DataEvent<HuobiDataEvent<object>>>? internalHandler = new Action<DataEvent<HuobiDataEvent<object>>>
                (
                data =>
                onData(data.As(data.Data.Data, contractCode))
                );
            return await _baseClient.SubscribeInternalAsync(this, request, null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeMarketContractCodeDetailAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeMarketContractCodeBboAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            contractCode = contractCode.ValidateHuobiContractCode();
            HuobiSubscribeRequest? request = new HuobiSubscribeRequest
                (
                _baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture),
                $"market.{contractCode}.bbo"
                );
            Action<DataEvent<HuobiDataEvent<object>>>? internalHandler = new Action<DataEvent<HuobiDataEvent<object>>>
                (
                data =>
                onData(data.As(data.Data.Data, contractCode))
                );
            return await _baseClient.SubscribeInternalAsync(this, request, null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<IEnumerable<object>>> GetMarketContractCodeTradeDetailAsync(string contractCode, string clientId, int size = 50)
        {
            contractCode = contractCode.ValidateHuobiContractCode();
            var request = new HuobiSocketRequest(_baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture), $"market.{contractCode}.trade.detail");
            var result = await _baseClient.QueryInternalAsync<HuobiSocketResponse<IEnumerable<object>>>(this, request, false).ConfigureAwait(false);
            return result ? result.As(result.Data.Data) : result.AsError<IEnumerable<object>>(result.Error!);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeMarketContractCodeTradeDetailAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            contractCode = contractCode.ValidateHuobiContractCode();
            HuobiSubscribeRequest? request = new HuobiSubscribeRequest
                (
                _baseClient.NextIdInternal().ToString(CultureInfo.InvariantCulture),
                $"market.{contractCode}.trade.detail"
                );
            Action<DataEvent<HuobiDataEvent<object>>>? internalHandler = new Action<DataEvent<HuobiDataEvent<object>>>
                (
                data =>
                onData(data.As(data.Data.Data, contractCode))
                );
            return await _baseClient.SubscribeInternalAsync(this, request, null, false, internalHandler, ct).ConfigureAwait(false);
            
        }
        #endregion

        #region WebSocket指数与基差数据接口
        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeMarketContractCodeIndexAsync(string contractCode, KlineInterval period, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<IEnumerable<object>>> GetMarketContractCodeIndexAsync(string contractCode, KlineInterval period, string clientId, long from, long to)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeMarketContractCodePremiumIndexAsync(string contractCode, KlineInterval period, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<IEnumerable<object>>> GetMarketContractCodePremiumIndexAsync(string contractCode, KlineInterval period, string clientId, long from, long to)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeMarketContractCodeEstimatedRateAsync(string contractCode, KlineInterval period, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<IEnumerable<object>>> GetMarketContractCodeEstimatedRateAsync(string contractCode, KlineInterval period, string clientId, long from, long to)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeMarketContractBasisAsync(string contractCode, KlineInterval period, string basisPriceType, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<IEnumerable<object>>> GetMarketContractBasisAsync(string contractCode, KlineInterval period, string basisPriceType, string clientId, long from, long to)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeMarketContractCodeMarkPriceAsync(string contractCode, KlineInterval period, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<IEnumerable<object>>> GetMarketContractCodeMarkPriceAsync(string contractCode, KlineInterval period, string clientId, long from, long to)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region WebSocket订单和用户数据接口
        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeOrderContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> UnsubscribeOrderContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
        #endregion

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeOrderCrossContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> UnsubscribeOrderCrossContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeAccountsContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> UnsubscribeAccountsContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeAccountsCrossContractCodeAsync(string marginAccount, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> UnsubscribeAccountsCrossContractCodeAsync(string marginAccount, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribePositionsContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> UnsubscribePositionsContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribePositionsCrossContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> UnsubscribePositionsCrossContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeMatchOrdersContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> UnsubscribeMatchOrdersContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeMatchOrdersCrossContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> UnsubscribeMatchOrdersCrossContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribePublicContractCodeLiquidationOrdersAsync(string contractCode, string businessType, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> UnsubscribePublicContractCodeLiquidationOrdersAsync(string contractCode, string businessType, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribePublicContractCodeFundingRateAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> UnsubscribePublicContractCodeFundingRateAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribePublicContractCodeContractInfoAsync(string contractCode, string businessType, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> UnsubscribePublicContractCodeContractInfoAsync(string contractCode, string businessType, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribetRiggerOrderContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> UnsubscribeRiggerOrderContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribetRiggerOrderCrossContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> UnsubscribeRiggerOrderCrossContractCodeAsync(string contractCode, string clientId, Action<DataEvent<object>> onData, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        #region private

        private void DeserializeAndInvoke<T>(DataEvent<JToken> data, Action<DataEvent<T>>? action, string? symbol = null)
        {
            var obj = _baseClient.DeserializeInternal<T>(data.Data["data"]!);
            if (!obj)
            {
                _log.Write(LogLevel.Error, $"Failed to deserialize {typeof(T).Name}: " + obj.Error);
                return;
            }
            action?.Invoke(data.As(obj.Data, symbol));
        }
        #endregion
        #endregion

    }
}