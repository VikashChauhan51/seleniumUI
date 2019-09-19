using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SeleniumUITest.Core
{
    public class PageFactory
    {
        private static ConcurrentDictionary<string, Page> _pages = new ConcurrentDictionary<string, Page>();
        private readonly Browser _browser;
        public PageFactory(Browser browser)
        {
            this._browser = browser;
        }

        public void Reset() => _pages.Clear();
        public T GetPage<T>() where T : Page
        {
            var key = nameof(T);
            if (!_pages.TryGetValue(key, out Page page))
            {
                Type pageType = typeof(T);
                List<Type> constructorArgTypeList = new List<Type>
                {
                    typeof(Browser)
                };
                ConstructorInfo ctorInfo = pageType.GetConstructor(constructorArgTypeList.ToArray());
                if (ctorInfo != null)
                    page = (T)ctorInfo.Invoke(new object[] { _browser });
                else
                    page = (T)Activator.CreateInstance(pageType);

                _pages.AddOrUpdate(key, page, (oldKey, oldValue) => page);
            }
            return (T)page;

        }
        public T GetNewPage<T>() where T : Page
        {
            var key = nameof(T);
            _pages.TryRemove(key, out Page page);
            Type pageType = typeof(T);
            List<Type> constructorArgTypeList = new List<Type>
                {
                    typeof(Browser)
                };
            ConstructorInfo ctorInfo = pageType.GetConstructor(constructorArgTypeList.ToArray());
            if (ctorInfo != null)
                page = (T)ctorInfo.Invoke(new object[] { _browser });
            else
                page = (T)Activator.CreateInstance(pageType);

            _pages.AddOrUpdate(key, page, (oldKey, oldValue) => page);

            return (T)page;

        }
    }
}
