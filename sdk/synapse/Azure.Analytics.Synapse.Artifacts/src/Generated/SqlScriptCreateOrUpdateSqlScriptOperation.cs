// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.Artifacts
{
    /// <summary> Creates or updates a Sql Script. </summary>
    public partial class SqlScriptCreateOrUpdateSqlScriptOperation : Operation<SqlScriptResource>, IOperationSource<SqlScriptResource>
    {
        private readonly OperationInternals<SqlScriptResource> _operation;

        /// <summary> Initializes a new instance of SqlScriptCreateOrUpdateSqlScriptOperation for mocking. </summary>
        protected SqlScriptCreateOrUpdateSqlScriptOperation()
        {
        }

        internal SqlScriptCreateOrUpdateSqlScriptOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<SqlScriptResource>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "SqlScriptCreateOrUpdateSqlScriptOperation");
        }
        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override SqlScriptResource Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<SqlScriptResource>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<SqlScriptResource>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        SqlScriptResource IOperationSource<SqlScriptResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return SqlScriptResource.DeserializeSqlScriptResource(document.RootElement);
        }

        async ValueTask<SqlScriptResource> IOperationSource<SqlScriptResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return SqlScriptResource.DeserializeSqlScriptResource(document.RootElement);
        }
    }
}
