using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Revisi_Stegano_Audio.Lib
{
    class FileSizeValidation
    {
        private long messageSize;
        private long mediaSize;
        private long space;
        private long req;

        public FileSizeValidation(long messageSize, long mediaSize)
        {
            this.mediaSize = mediaSize;
            this.messageSize = messageSize;
        }

        public string messageValid()
        {
            if (messageSize == 0)
                return "Message file is zero size!";

            if (mediaSize == 0)
                return "Media file is zero size!";

            if (messageSize * Pattern.patternTolerance * Pattern.patternBase > mediaSize)
                return "Message file is to big!";

            return "Message can be embedded.";
        }

        public string spaceEmpty()
        {
            //messageSize *= Pattern.patternSize * Pattern.patternBase;
            //space = mediaSize - messageSize;
            space = mediaSize - Pattern.patternPositionStart * 2;
            return space.ToString();
        }

        public string requirement()
        {
            messageSize *= Pattern.patternTolerance * Pattern.patternBase;
            req = messageSize;
            return string.Format("{0}"+ req.ToString(), "Around ");
        }
    }
}
