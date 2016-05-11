using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace DiTree
{
    internal class DiTaskTypeConverter : TypeConverter
    {

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            //true shows the drop down icon
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true; // drop-down vs combo
        }
      
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<string> kList = new List<string>();

            DiCondition temp = context.Instance as DiCondition;

            if (temp.TaskElement1 != null)
            {
                kList.Add(temp.TaskElement1.ClassName);
            }

            if (temp.TaskElement2 != null)
            {
                kList.Add(temp.TaskElement2.ClassName);
            }
            
            
            // note you can also look at context etc to build list
            return new StandardValuesCollection(kList);
        }
    }
}
