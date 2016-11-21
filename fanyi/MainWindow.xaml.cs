using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fanyi
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public string src { get; set; }//原文
        public string det { get; set; }//译文

        public string salt;
        public long appid = 20161114000031737;
        public string key = "DjaFZydYrgehVzJj00UT";
        public MainWindow()
        {
            InitializeComponent();
        }
        //http://api.fanyi.baidu.com/api/trans/vip/translate


        MD5 getmd5 = MD5.Create();//一个md5计算的实例
        public string getrandom ()
        {
            Random r = new Random(int.MaxValue);
            salt = r.ToString();
            return salt;          
        }
        public void getmd( string q)//q是需要翻译的文本，带参方法
        {
           
            string mds = appid +q+getrandom()+key;//马丹百度搞MD5加密作肾啊
            byte[] py = getmd5.ComputeHash(Encoding.UTF8.GetBytes(mds)); // 将输入字符串转换为字节数组并计算哈希数据 
        }
        public enum from //语言枚举
        {
            zh, //中
            en, // 英
            jp, //日
        }
    }
}
