using System.Collections.Specialized;
using System.Linq;

public static class CollectionExtension
{
    public static string CollectionToString(this NameValueCollection nvc, string itemSeparator, string nameValueSeparator)
    {
        return string.Join(itemSeparator, nvc.AllKeys.Select(key => string.Format("{0}{1}{2}", key, nameValueSeparator, nvc[key])));
    }

}
