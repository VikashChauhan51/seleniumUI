using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumUITest.Utilities
{
    public static class EnvironmentHelper
    {
        public static string GetEnvironmentVariableOrDefault(string envVar, string defaultValue)
        {
            string environmentVariable = Environment.GetEnvironmentVariable(envVar);
            return !string.IsNullOrEmpty(environmentVariable) ? environmentVariable : defaultValue;

        }



        public static IEnumerable<string> GetEnvironmentVariableWithValueList(string envVar, char delimiter = ';')
        {

            string environmentVariable = Environment.GetEnvironmentVariable(envVar);
            if (environmentVariable == null)
                return Enumerable.Empty<string>();

            string str = environmentVariable;
            char[] chArray = new char[1];
            int index = 0;
            int num = (int)delimiter;
            chArray[index] = (char)num;
            return Enumerable.ToList(str.Split(chArray));
        }

        public static Dictionary<string, object> GetEnvironmentVariables()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (DictionaryEntry dictionaryEntry in Environment.GetEnvironmentVariables())
                dictionary.Add((string)dictionaryEntry.Key, dictionaryEntry.Value);
            return dictionary;
        }

        private static Dictionary<string, object> FilterAndTrimDictionaryKeysByPrefix(Dictionary<string, object> dictionary, string prefix)
        {
            return Enumerable.ToDictionary(Enumerable.Where(dictionary, i => i.Key.ToLower().StartsWith(prefix.ToLower())), i => i.Key.Remove(i.Key.ToLower().IndexOf(prefix.ToLower()), prefix.Length), i => i.Value);
        }

        public static Dictionary<string, object> GetEnvVarsByPrefixTrimmed(string prefix)
        {
            return FilterAndTrimDictionaryKeysByPrefix(GetEnvironmentVariables(), prefix);
        }


        private static Dictionary<string, object> CombineDictionaryTypes(Dictionary<string, bool> _dictBool, Dictionary<string, int> _dictInt, Dictionary<string, string> _dictStr)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (KeyValuePair<string, bool> keyValuePair in _dictBool)
                dictionary.Add(keyValuePair.Key, (object)(keyValuePair.Value ? 1 : 0));
            foreach (KeyValuePair<string, int> keyValuePair in _dictInt)
                dictionary.Add(keyValuePair.Key, (object)keyValuePair.Value);
            foreach (KeyValuePair<string, string> keyValuePair in _dictStr)
                dictionary.Add(keyValuePair.Key, (object)keyValuePair.Value);
            return dictionary;
        }

        public static string ObjectDictToString(Dictionary<string, object> dictionary)
        {
            string str = "";
            foreach (KeyValuePair<string, object> keyValuePair in dictionary)
                str += string.Format("[Key = {0}, Value = {1}, Type = {2}] ", (object)keyValuePair.Key, keyValuePair.Value, (object)keyValuePair.Value.GetType());
            return str;
        }

        public static string StringListToString(List<string> list, string separator = " ")
        {
            return string.Join(separator, list);
        }
    }
}
