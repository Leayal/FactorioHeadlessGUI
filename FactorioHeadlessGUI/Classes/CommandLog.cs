using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace FactorioHeadlessGUI.Classes
{
    public class CommandLog
    {
        private List<string> innerList;

        public CommandLog()
        {
            this.Limit = 20;
            this.innerList = new List<string>();
            this.lastIndex = -1;
        }

        public void ResetPosition()
        {
            Interlocked.Exchange(ref this.lastIndex, -1);
        }

        public void Clear()
        {
            this.innerList.Clear();
        }

        public void Log(string cmd)
        {
            int index = this.innerList.IndexOf(cmd);
            if (index > -1)
                this.innerList.RemoveAt(index);
            this.innerList.Add(cmd);
            while (this.innerList.Count > this.Limit)
                this.innerList.RemoveAt(this.innerList.Count - 1);
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
            while (this.innerList.Count > this.Limit)
                this.innerList.RemoveAt(this.innerList.Count - 1);
        }

        int lastIndex;
        public string GetAt(int index)
        {
            if (this.innerList.Count == 0 || this.innerList.Count <= index)
                return string.Empty;
            else
            {
                if (index < 0)
                {
                    this.ResetPosition();
                    return string.Empty;
                }
                else
                {
                    Interlocked.Exchange(ref this.lastIndex, index);
                    return this.innerList[index];
                }
            }
        }

        public string GetNext()
        {
            if (this.innerList.Count == 0)
                return null;
            else
            {
                if (this.lastIndex < (this.innerList.Count - 1))
                {
                    Interlocked.Increment(ref this.lastIndex);
                    return this.innerList[this.lastIndex];
                }
                else
                    return null;
            }
        }

        public string GetPrevious()
        {
            if (this.innerList.Count == 0)
                return null;
            else
            {
                if (this.lastIndex > -1)
                    Interlocked.Decrement(ref this.lastIndex);
                if (this.lastIndex == -1)
                    return string.Empty;
                else
                    return this.innerList[this.lastIndex];
            }
        }

        [DefaultValue(20)]
        public int Limit { get; set; }
    }
}
