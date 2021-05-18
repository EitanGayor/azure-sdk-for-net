// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    [JsonConverter(typeof(NotebookCellConverter))]
    public partial class NotebookCell : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("cell_type");
            writer.WriteStringValue(CellType);
            writer.WritePropertyName("metadata");
            writer.WriteObjectValue(Metadata);
            writer.WritePropertyName("source");
            writer.WriteStartArray();
            foreach (var item in Source)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(Attachments))
            {
                if (Attachments != null)
                {
                    writer.WritePropertyName("attachments");
                    writer.WriteObjectValue(Attachments);
                }
                else
                {
                    writer.WriteNull("attachments");
                }
            }
            if (Optional.IsCollectionDefined(Outputs))
            {
                writer.WritePropertyName("outputs");
                writer.WriteStartArray();
                foreach (var item in Outputs)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
        }

        internal static NotebookCell DeserializeNotebookCell(JsonElement element)
        {
            string cellType = default;
            object metadata = default;
            IList<string> source = default;
            Optional<object> attachments = default;
            Optional<IList<NotebookCellOutputItem>> outputs = default;
            IDictionary<string, object> additionalProperties = default;
            Dictionary<string, object> additionalPropertiesDictionary = new Dictionary<string, object>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("cell_type"))
                {
                    cellType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("metadata"))
                {
                    metadata = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("source"))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    source = array;
                    continue;
                }
                if (property.NameEquals("attachments"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        attachments = null;
                        continue;
                    }
                    attachments = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("outputs"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<NotebookCellOutputItem> array = new List<NotebookCellOutputItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(NotebookCellOutputItem.DeserializeNotebookCellOutputItem(item));
                    }
                    outputs = array;
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, property.Value.GetObject());
            }
            additionalProperties = additionalPropertiesDictionary;
            return new NotebookCell(cellType, metadata, source, attachments.Value, Optional.ToList(outputs), additionalProperties);
        }

        internal partial class NotebookCellConverter : JsonConverter<NotebookCell>
        {
            public override void Write(Utf8JsonWriter writer, NotebookCell model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override NotebookCell Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeNotebookCell(document.RootElement);
            }
        }
    }
}
