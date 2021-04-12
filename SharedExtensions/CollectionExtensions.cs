using System.Collections.Specialized;
using System.Linq;

namespace SharedExtensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nvc"></param>
        /// <param name="itemSeparator"></param>
        /// <param name="nameValueSeparator"></param>
        /// <returns></returns>
        public static string CollectionToString(this NameValueCollection nvc, string itemSeparator, string nameValueSeparator)
        {
            return string.Join(itemSeparator, nvc.AllKeys.Select(key => string.Format("{0}{1}{2}", key, nameValueSeparator, nvc[key])));
        }

    }
}
