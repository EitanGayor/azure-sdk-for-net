// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.CognitiveServices.Vision.Face
{
    using Microsoft.Rest;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// PersonGroupOperations operations.
    /// </summary>
    public partial interface IPersonGroupOperations
    {
        /// <summary>
        /// Create a new person group with specified personGroupId, name,
        /// user-provided userData and recognitionModel.
        /// &lt;br /&gt; A person group is the container of the uploaded person
        /// data, including face recognition features.
        /// &lt;br /&gt; After creation, use [PersonGroup Person -
        /// Create](https://docs.microsoft.com/rest/api/faceapi/persongroupperson/create)
        /// to add persons into the group, and then call [PersonGroup -
        /// Train](https://docs.microsoft.com/rest/api/faceapi/persongroup/train)
        /// to get this group ready for [Face -
        /// Identify](https://docs.microsoft.com/rest/api/faceapi/face/identify).
        /// &lt;br /&gt; No image will be stored. Only the person's extracted
        /// face features and userData will be stored on server until
        /// [PersonGroup Person -
        /// Delete](https://docs.microsoft.com/rest/api/faceapi/persongroupperson/delete)
        /// or [PersonGroup -
        /// Delete](https://docs.microsoft.com/rest/api/faceapi/persongroup/delete)
        /// is called.
        /// &lt;br/&gt;'recognitionModel' should be specified to associate with
        /// this person group. The default value for 'recognitionModel' is
        /// 'recognition_01', if the latest model needed, please explicitly
        /// specify the model you need in this parameter. New faces that are
        /// added to an existing person group will use the recognition model
        /// that's already associated with the collection. Existing face
        /// features in a person group can't be updated to features extracted
        /// by another version of recognition model.
        ///
        /// Person group quota:
        /// * Free-tier subscription quota: 1,000 person groups. Each holds up
        /// to 1,000 persons.
        /// * S0-tier subscription quota: 1,000,000 person groups. Each holds
        /// up to 10,000 persons.
        /// * to handle larger scale face identification problem, please
        /// consider using
        /// [LargePersonGroup](https://docs.microsoft.com/rest/api/faceapi/largepersongroup).
        /// </summary>
        /// <param name='personGroupId'>
        /// Id referencing a particular person group.
        /// </param>
        /// <param name='name'>
        /// User defined name, maximum length is 128.
        /// </param>
        /// <param name='userData'>
        /// User specified data. Length should not exceed 16KB.
        /// </param>
        /// <param name='recognitionModel'>
        /// Possible values include: 'recognition_01', 'recognition_02',
        /// 'recognition_03', 'recognition_04'
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="APIErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse> CreateWithHttpMessagesAsync(string personGroupId, string name = default(string), string userData = default(string), string recognitionModel = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete an existing person group. Persisted face features of all
        /// people in the person group will also be deleted.
        /// </summary>
        /// <param name='personGroupId'>
        /// Id referencing a particular person group.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="APIErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse> DeleteWithHttpMessagesAsync(string personGroupId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Retrieve person group name, userData and recognitionModel. To get
        /// person information under this personGroup, use [PersonGroup Person
        /// -
        /// List](https://docs.microsoft.com/rest/api/faceapi/persongroupperson/list).
        /// </summary>
        /// <param name='personGroupId'>
        /// Id referencing a particular person group.
        /// </param>
        /// <param name='returnRecognitionModel'>
        /// A value indicating whether the operation should return
        /// 'recognitionModel' in response.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="APIErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<PersonGroup>> GetWithHttpMessagesAsync(string personGroupId, bool? returnRecognitionModel = false, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update an existing person group's display name and userData. The
        /// properties which does not appear in request body will not be
        /// updated.
        /// </summary>
        /// <param name='personGroupId'>
        /// Id referencing a particular person group.
        /// </param>
        /// <param name='name'>
        /// User defined name, maximum length is 128.
        /// </param>
        /// <param name='userData'>
        /// User specified data. Length should not exceed 16KB.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="APIErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse> UpdateWithHttpMessagesAsync(string personGroupId, string name = default(string), string userData = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Retrieve the training status of a person group (completed or
        /// ongoing).
        /// </summary>
        /// <param name='personGroupId'>
        /// Id referencing a particular person group.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="APIErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<TrainingStatus>> GetTrainingStatusWithHttpMessagesAsync(string personGroupId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// List person groups’ personGroupId, name, userData and
        /// recognitionModel.&lt;br /&gt;
        /// * Person groups are stored in alphabetical order of personGroupId.
        /// * "start" parameter (string, optional) is a user-provided
        /// personGroupId value that returned entries have larger ids by string
        /// comparison. "start" set to empty to indicate return from the first
        /// item.
        /// * "top" parameter (int, optional) specifies the number of entries
        /// to return. A maximal of 1000 entries can be returned in one call.
        /// To fetch more, you can specify "start" with the last returned
        /// entry’s Id of the current call.
        /// &lt;br /&gt;
        /// For example, total 5 person groups: "group1", ..., "group5".
        /// &lt;br /&gt; "start=&amp;top=" will return all 5 groups.
        /// &lt;br /&gt; "start=&amp;top=2" will return "group1", "group2".
        /// &lt;br /&gt; "start=group2&amp;top=3" will return "group3",
        /// "group4", "group5".
        ///
        /// </summary>
        /// <param name='start'>
        /// List person groups from the least personGroupId greater than the
        /// "start".
        /// </param>
        /// <param name='top'>
        /// The number of person groups to list.
        /// </param>
        /// <param name='returnRecognitionModel'>
        /// A value indicating whether the operation should return
        /// 'recognitionModel' in response.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="APIErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<IList<PersonGroup>>> ListWithHttpMessagesAsync(string start = default(string), int? top = 1000, bool? returnRecognitionModel = false, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Queue a person group training task, the training task may not be
        /// started immediately.
        /// </summary>
        /// <param name='personGroupId'>
        /// Id referencing a particular person group.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="APIErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse> TrainWithHttpMessagesAsync(string personGroupId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
