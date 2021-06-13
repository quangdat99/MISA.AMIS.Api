using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Attributes
{
    /// <summary>
    /// Attribute kiểm tra required
    /// </summary>
    /// CreatedBy: dqdat (27/05/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyRequired : Attribute
    {
        public string _msgError;
        public PropertyRequired(string msgError = "")
        {
            _msgError = msgError;
        }
    }
}
