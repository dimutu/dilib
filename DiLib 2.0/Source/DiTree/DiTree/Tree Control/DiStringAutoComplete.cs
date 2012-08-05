using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace DiTree
{
    class DiStringAutoComplete : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            //true means show a combobox
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }


        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<string> kClassList = new List<string>();
            DiTask temp = context.Instance as DiTask;
            DataRow[] dr = temp.DataHandler.GetRows(temp.ClassType, temp.TemplateClass);

            foreach (DataRow row in dr)
            {
                kClassList.Add(row[DiDataHanlder.DATAFIELD_CLASSNAME].ToString());

            }
            

            return new StandardValuesCollection(kClassList);
        }
    }
}
