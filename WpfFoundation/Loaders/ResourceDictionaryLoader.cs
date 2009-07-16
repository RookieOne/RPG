using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows;

namespace WpfFoundation.Loaders
{
    /// <summary>
    /// Loads all Page Xaml files in the given assembly into the Merged Dictionary 
    /// collection for the application
    /// </summary>
    public class ResourceDictionaryLoader
    {
        /// <summary>
        /// Creates an instance of a Resource Dictionary Loader.
        /// </summary>
        /// <returns></returns>
        public static ResourceDictionaryLoader Create()
        {
            return new ResourceDictionaryLoader();
        }

        /// <summary>
        /// Loads the resource dictionaries from the assembly.
        /// </summary>
        public ResourceDictionaryLoader LoadResourceDictionaries(Assembly assembly)
        {
            string assemblyName = assembly.GetName().Name;
            Stream stream = assembly.GetManifestResourceStream(assemblyName + ".g.resources");

            using (var reader = new ResourceReader(stream))
            {
                foreach (DictionaryEntry entry in reader)
                {
                    var key = (string) entry.Key;
                    key = key.Replace(".baml", ".xaml");

                    string uriString = String.Format("pack://application:,,,/{0};Component/{1}", assemblyName, key);

                    var dictionary = new ResourceDictionary
                                         {
                                             Source = new Uri(uriString)
                                         };

                    Application.Current.Resources.MergedDictionaries.Add(dictionary);
                }
            }

            return this;
        }
    }
}