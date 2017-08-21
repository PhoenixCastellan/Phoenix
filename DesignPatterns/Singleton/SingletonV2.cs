using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    public class SingletonV2
    {
        private SingletonV2() { }
        private static object _lock=new object();

        private static SingletonV2 _singleton;

        public static SingletonV2 GetInstance()
        {
            if (_singleton == null)
            {
                lock (_lock)
                {
                    _singleton = new SingletonV2();
                }
            }
            return _singleton;
        }
    }
}
