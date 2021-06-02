﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.Communication.Calling.Server.Tests
{
    public class CallingServerClientsTests
    {
        [TestCaseSource(nameof(TestData_CreateCall))]
        public async Task CreateCallAsyncOverload_Passes(CommunicationIdentifier expectedSource, IEnumerable<CommunicationIdentifier> expectedTargets, CreateCallOptions expectedOptions)
        {
            Mock<CallClient> mockClient = new Mock<CallClient>() { CallBase = true };
            Response<CreateCallResponse>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.CreateCallAsync(It.IsAny<CommunicationIdentifier>(), It.IsAny<IEnumerable<CommunicationIdentifier>>(), It.IsAny<CreateCallOptions>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .ReturnsAsync((CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions options, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedSource, source);
                    Assert.AreEqual(expectedTargets, targets);
                    Assert.AreEqual(expectedOptions, options);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response<CreateCallResponse>>().Object;
                });

            Response<CreateCallResponse> actualResponse = await mockClient.Object.CreateCallAsync(expectedSource, expectedTargets, expectedOptions, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData_CommonOperationWithCallId))]
        public async Task DeleteCallAsyncOverload_Passes(string expectedCallLegId)
        {
            Mock<CallClient> mockClient = new Mock<CallClient>() { CallBase = true };
            Response? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.DeleteCallAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .ReturnsAsync((string callLegId, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedCallLegId, callLegId);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response>().Object;
                });

            Response actualResponse = await mockClient.Object.DeleteCallAsync(expectedCallLegId, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData_CommonOperationWithCallId))]
        public async Task HangupCallAsyncOverload_Passes(string expectedCallLegId)
        {
            Mock<CallClient> mockClient = new Mock<CallClient>() { CallBase = true };
            Response? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.HangupCallAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .ReturnsAsync((string callLegId, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedCallLegId, callLegId);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response>().Object;
                });

            Response actualResponse = await mockClient.Object.HangupCallAsync(expectedCallLegId, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData_CancelMediaOperations))]
        public async Task CancelMediaOperationsAsyncOverload_Passes(string expectedCallLegId)
        {
            Mock<CallClient> mockClient = new Mock<CallClient>() { CallBase = true };
            Response<CancelMediaOperationsResponse>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.CancelMediaOperationsAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .ReturnsAsync((string callLegId, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedCallLegId, callLegId);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response<CancelMediaOperationsResponse>>().Object;
                });

            Response<CancelMediaOperationsResponse> actualResponse = await mockClient.Object.CancelMediaOperationsAsync(expectedCallLegId, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData_PlayAudioWithRequest))]
        public async Task PlayAudioAsyncOverload_Passes(string expectedCallLegId, PlayAudioOptions expectedRequest)
        {
            Mock<CallClient> mockClient = new Mock<CallClient>() { CallBase = true };
            Response<PlayAudioResponse>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.PlayAudioAsync(It.IsAny<string>(), It.IsAny<PlayAudioOptions>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .ReturnsAsync((string callLegId, PlayAudioOptions request, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedCallLegId, callLegId);
                    Assert.AreEqual(expectedRequest, request);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response<PlayAudioResponse>>().Object;
                });

            Response<PlayAudioResponse> actualResponse = await mockClient.Object.PlayAudioAsync(expectedCallLegId, expectedRequest, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData_PlayAudioWithoutRequest))]
        public async Task PlayAudioAsyncOverload_Passes(string expectedCallLegId, Uri expectedAudioFileUri, bool expectedLoop, string expectedAudioFileId, Uri expectedCallbackUri, string expectedOperationContext)
        {
            Mock<CallClient> mockClient = new Mock<CallClient>() { CallBase = true };
            Response<PlayAudioResponse>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.PlayAudioAsync(It.IsAny<string>(), It.IsAny<Uri>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .ReturnsAsync((string callLegId, Uri audioFileUri, bool loop, string operationContext, string audioFileId, Uri callbackUri, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedCallLegId, callLegId);
                    Assert.AreEqual(expectedAudioFileUri, audioFileUri);
                    Assert.AreEqual(expectedLoop, loop);
                    Assert.AreEqual(expectedOperationContext, operationContext);
                    Assert.AreEqual(expectedAudioFileId, audioFileId);
                    Assert.AreEqual(expectedCallbackUri, callbackUri);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response<PlayAudioResponse>>().Object;
                });

            Response<PlayAudioResponse> actualResponse = await mockClient.Object.PlayAudioAsync(expectedCallLegId, expectedAudioFileUri, expectedLoop, expectedAudioFileId, expectedCallbackUri, expectedOperationContext, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData_InviteParticipants))]
        public async Task InviteParticipantsAsyncOverload_Passes(string expectedCallLegId, IEnumerable<CommunicationIdentifier> expectedParticipants, string expectedOperationContext, string? expectedAlternateCallerId = null)
        {
            Mock<CallClient> mockClient = new Mock<CallClient>() { CallBase = true };
            Response? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.InviteParticipantsAsync(It.IsAny<string>(), It.IsAny<IEnumerable<CommunicationIdentifier>>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .ReturnsAsync((string callLegId, IEnumerable<CommunicationIdentifier> participants, string operationContext, string alternateCallerId, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedCallLegId, callLegId);
                    Assert.AreEqual(expectedParticipants, participants);
                    Assert.AreEqual(expectedOperationContext, operationContext);
                    Assert.AreEqual(expectedAlternateCallerId, alternateCallerId);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response>().Object;
                });

            Response actualResponse = await mockClient.Object.InviteParticipantsAsync(expectedCallLegId, expectedParticipants, expectedOperationContext, expectedAlternateCallerId, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData_RemoveParticipant))]
        public async Task RemoveParticipantAsyncOverload_Passes(string expectedCallLegId, string expectedParticipantId)
        {
            Mock<CallClient> mockClient = new Mock<CallClient>() { CallBase = true };
            Response? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.RemoveParticipantAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .ReturnsAsync((string callLegId, string participantId, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedCallLegId, callLegId);
                    Assert.AreEqual(expectedParticipantId, participantId);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response>().Object;
                });

            Response actualResponse = await mockClient.Object.RemoveParticipantAsync(expectedCallLegId, expectedParticipantId, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        private static IEnumerable<object?[]> TestData_CreateCall()
        {
            return new List<object?[]>(){
                new object?[] {
                    new CommunicationUserIdentifier("50125645-5dca-4193-877d-4608ed2a0bc2"),
                    new List<CommunicationIdentifier>() { new PhoneNumberIdentifier("+14052882361") },
                    new CreateCallOptions(new Uri($"https://dummy.ngrok.io/api/incident/callback?secret=h3llowW0rld"), new List<CallModalityModel> { CallModalityModel.Audio }, new List<EventSubscriptionTypeModel> { EventSubscriptionTypeModel.ParticipantsUpdated, EventSubscriptionTypeModel.DtmfReceived })
                },
            };
        }

        private static IEnumerable<object?[]> TestData_CancelMediaOperations()
        {
            return new List<object?[]>(){
                new object?[] {
                    "4ab31d78-a189-4e50-afaa-f9610975b6cb",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_PlayAudioWithRequest()
        {
            return new List<object?[]>(){
                new object?[] {
                    "4ab31d78-a189-4e50-afaa-f9610975b6cb",
                    new PlayAudioOptions()
                    {
                        AudioFileUri = new Uri("https://av.ngrok.io/audio/sample-message.wav"),
                        OperationContext = Guid.NewGuid().ToString(),
                        Loop = true,
                        AudioFileId = Guid.NewGuid().ToString()
                    }
                }
            };
        }

        private static IEnumerable<object?[]> TestData_PlayAudioWithoutRequest()
        {
            return new List<object?[]>(){
                new object?[] {
                    "4ab31d78-a189-4e50-afaa-f9610975b6cb",
                    new Uri("https://av.ngrok.io/audio/sample-message.wav"),
                    true,
                    "af82480b-6df3-4f4c-a58c-a6a78b614b36",
                    "b76993e4-1906-4967-9a9b-feecbbccc60e",
                    new Uri("http://foo.com/bar")
                }
            };
        }

        private static IEnumerable<object?[]> TestData_CommonOperationWithCallId()
        {
            return new List<object?[]>(){
                new object?[] {
                    "4ab31d78-a189-4e50-afaa-f9610975b6cb",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_InviteParticipants()
        {
            return new List<object?[]>(){
                new object?[] {
                    "4ab31d78-a189-4e50-afaa-f9610975b6cb",
                    new List<CommunicationIdentifier>() { new PhoneNumberIdentifier("+14052882361"),  new CommunicationUserIdentifier("50125645-5dca-4193-877d-4608ed2a0bc2"), },
                    "af82480b-6df3-4f4c-a58c-a6a78b614b36",
                    "+14052882362"
                },
                 new object?[] {
                    "4ab31d78-a189-4e50-afaa-f9610975b6cb",
                    new List<CommunicationIdentifier>() { new PhoneNumberIdentifier("+14052882361"),  new CommunicationUserIdentifier("50125645-5dca-4193-877d-4608ed2a0bc2"), },
                    "af82480b-6df3-4f4c-a58c-a6a78b614b36",
                    null
                },
            };
        }

        private static IEnumerable<object?[]> TestData_RemoveParticipant()
        {
            return new List<object?[]>(){
                new object?[] {
                    "4ab31d78-a189-4e50-afaa-f9610975b6cb",
                    "bb00cdef-9f34-408d-ae95-81bce082fff5"
                }
            };
        }

        private static Expression<Func<CallClient, TResult>> BuildExpression<TResult>(Expression<Func<CallClient, TResult>> expression)
            => expression;
    }
}
