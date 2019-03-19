using System.ComponentModel;
using System.Configuration;

namespace storm.umbraco.contrib.AppSettings
{
    public abstract class StormAppSettings
    {
        protected static T GetAppSetting<T>(string name, T defaultValue)
        {
            try
            {
                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(ConfigurationManager.AppSettings[name]);
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
