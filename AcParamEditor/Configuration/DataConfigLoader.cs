using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace AcParamEditor.Configuration
{
    /// <summary>
    /// A data config loader.
    /// </summary>
    internal static class DataConfigLoader
    {
        /// <summary>
        /// Loads a data config from the specified path.
        /// </summary>
        /// <typeparam name="TValue">The data config type.</typeparam>
        /// <param name="dataPath">The data file path to load from.</param>
        /// <param name="jsonTypeInfo">The json type info of the data config type.</param>
        /// <returns>A newly read data config.</returns>
        /// <exception cref="FileNotFoundException">The data config couldn't be found.</exception>
        /// <exception cref="Exception">The data config failed to load.</exception>
        internal static TValue Load<TValue>(string dataPath, JsonTypeInfo<TValue> jsonTypeInfo)
        {
            TValue config;
            if (!File.Exists(dataPath))
            {
                throw new FileNotFoundException($"Could not find data config json at path: \"{dataPath}\"", dataPath);
            }

            config = JsonSerializer.Deserialize(File.ReadAllText(dataPath), jsonTypeInfo) ?? throw new Exception($"Failed to load data config at: \"{dataPath}\"");
            return config;
        }

        /// <summary>
        /// Saves a data config to the specified path.
        /// </summary>
        /// <typeparam name="TValue">The data config type.</typeparam>
        /// <param name="config">The data config.</param>
        /// <param name="dataPath">The data file path to save to.</param>
        /// <param name="jsonTypeInfo">The json type info of the data config type.</param>
        internal static void Save<TValue>(TValue config, string dataPath, JsonTypeInfo<TValue> jsonTypeInfo)
        {
            string json = JsonSerializer.Serialize(config, jsonTypeInfo);
            File.WriteAllText(dataPath, json);
        }

        /// <summary>
        /// Loads a data config from the specified path if possible.
        /// </summary>
        /// <typeparam name="TValue">The data config type.</typeparam>
        /// <param name="dataPath">The data file path to load from.</param>
        /// <param name="jsonTypeInfo">The json type info of the data config type.</param>
        /// <param name="config">A newly read data config.</param>
        /// <returns>Whether or not the data config could be loaded.</returns>
        internal static bool TryLoad<TValue>(string dataPath, JsonTypeInfo<TValue> jsonTypeInfo, [NotNullWhen(true)] out TValue? config)
        {
            if (!File.Exists(dataPath))
            {
                config = default;
                return false;
            }

            config = JsonSerializer.Deserialize(File.ReadAllText(dataPath), jsonTypeInfo);
            return config != null;
        }
    }
}
