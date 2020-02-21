namespace ProjectX.Helpers
{
    public class CacheBuster
    {
        private static string _tag;

        public static string Tag(string rootRelativePath)
        {
            if (!rootRelativePath.Contains("?"))
            {
                rootRelativePath += "?";
            }
            else
            {
                rootRelativePath += "&";
            }
            rootRelativePath += ("v=" + Tag());

            return rootRelativePath;

        }

        /// <summary>
        /// Get a numeric string which uniquely identifies the current app build.
        /// </summary>
        /// <returns></returns>
        public static string Tag()
        {
            return _tag = _tag ??
                          (
                              _tag = System.Reflection.Assembly.GetExecutingAssembly()
                                  .GetName()
                                  .Version
                                  .ToString()
                                  .Replace(".", "")
                          );
        }
    }
}