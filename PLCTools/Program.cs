using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCTools
{
    static class Program
    {       
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    // only for 觀音自動倉
    static class Constants_GUAN_YING
    {        
        public const int _MAX_COMMAND_CNT = 1; // km per sec.
        public const int _MAX_LAYER = 18;      // 最高樓層數
        public const int _MAX_POS = 60;        // 最多庫格數
        public const int _2012 = 2012;
        public const int _2013 = 2013;
        public const int _GuanYin = 1;          // 觀音廠
    }

}
