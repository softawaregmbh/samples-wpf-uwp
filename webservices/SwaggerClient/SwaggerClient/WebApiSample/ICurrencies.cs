﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using SwaggerClient.Models;

namespace SwaggerClient
{
    public partial interface ICurrencies
    {
        /// <param name='amount'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<IList<CurrencyData>>> GetAllWithOperationResponseAsync(int amount, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='symbol'>
        /// Required. Currency symbol in upper case
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<CurrencyData>> GetBySymbolWithOperationResponseAsync(string symbol, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='data'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<string>> InsertWithOperationResponseAsync(CurrencyData data, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='query'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<IList<CurrencyData>>> SearchWithOperationResponseAsync(CurrencyQuery query, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='data'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> UpdateWithOperationResponseAsync(CurrencyData data, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
}
