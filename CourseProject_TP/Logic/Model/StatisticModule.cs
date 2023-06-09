using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class StatisticModule
    {
        private static Lazy<StatisticModule> _instance = new Lazy<StatisticModule>(() => new StatisticModule());
        public static StatisticModule Instance
        {
            get => _instance.Value;
        }
        StatisticModule()
        {

        }
        
    }
}
