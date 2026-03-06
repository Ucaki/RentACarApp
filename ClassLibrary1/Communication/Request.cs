using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    [Serializable]
    public class Request
    {
        public OperationType Operation { get; set; }
        public object Argument { get; set; }
    }
}
