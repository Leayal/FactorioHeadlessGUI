using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FactorioHeadlessGUI.Classes
{
    public class CommandLog
    {
        private List<string> innerList;

        public CommandLog()
        {
            this.innerList = new List<string>();
            this.lastIndex = 0;
        }

        public void Log(string cmd)
        {
            int index = this.innerList.IndexOf(cmd);
            if (index > -1)
                this.innerList.RemoveAt(index);
            this.innerList.Add(cmd);
        }

        public void Log(string cmd, int index)
        {
            int findex = this.innerList.IndexOf(cmd);
            if (findex > -1)
            {
                if (findex == index) return;
                this.innerList.RemoveAt(findex);
            }
            this.innerList.Insert(index, cmd);
        }

        int lastIndex;
        public string GetAt(int index)
        {
            if (this.innerList.Count == 0 || this.innerList.Count <= index)
                return string.Empty;
            else
                return this.innerList[index];
        }

        /*public string GetNext()
        {
            if (this.innerList.Count == 0)
                return string.Empty;
            else
            {
                return this.innerList[index];
            }
        }

        public string GetPrevious()
        {
            if (this.innerList.Count == 0)
                return string.Empty;
            else
            {
                return this.innerList[index];
            }
        }//*/

        [DefaultValue(20)]
        public int Limit { get; set; }
    }
}
