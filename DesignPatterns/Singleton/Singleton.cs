using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    public class Singleton
    {
        private Singleton() { }

        private static Singleton _singleton;
        private static readonly object _obj = new object();

        /// <summary>
        /// 线程不安全
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstance()
        {
            if (_singleton == null)
            {
                _singleton=new Singleton();
            }
            return _singleton;
        }

        /// <summary>
        /// 线程不安全
        /// A、B两个线程，A和B都执行到Lock，然后A执行完了之后，B继续执行的时候会再生成一个对象
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstanceV1()
        {
            if (_singleton != null) return _singleton;
            lock (_obj)
            {
                _singleton = new Singleton();
            }
            return _singleton;
        }

        public static Singleton GetInstanceV2()
        {
            if (_singleton != null) return _singleton;
            lock (_obj)
            {
                if (_singleton == null)
                {
                    _singleton = new Singleton();
                }
            }
            return _singleton;
        }
    }
}
