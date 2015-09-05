using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tale
{
    // type for storage information about event
    class NewWishEventArgs : EventArgs
    {
        private int leafIndex; // index of leaf that you want to use
        private string wish;   // wish that you want come true =))

        public int LeafIndex
        {
            get { return leafIndex; }
        }

        public string Wish
        {
            get { return wish; }
        }

        public NewWishEventArgs(string wish, int leafIndex)
        {
            this.wish = wish;
            this.leafIndex = leafIndex;
        }
    }
}
