using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.Data.Sqlite;
namespace Winui3aot.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {

        }
        [ObservableProperty]
        public string output = "输出信息";

        [ObservableProperty]
        public string command = "";


        [RelayCommand]
        private void Start()
        {
            exec(Command);
        }

        private void exec(string cmd)
        {
            _ = Task.Run(() =>
            {
                string preCmd = @".\Assets\BBDown.exe";
                string resultCmd = $"{preCmd} {cmd}&exit";
                Process p = new();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;            //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;       //接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;      //由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;       //重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;              //不显示程序窗口
                _ = p.Start();                                      //启动程序

                p.StandardInput.WriteLine(resultCmd);       //向cmd窗口发送输入信息

                //p.StandardInput.WriteLine("exit");
                //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
                //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令

                p.StandardInput.AutoFlush = true;

                string output = p.StandardOutput.ReadToEnd();   //获取cmd窗口的输出信息     

                p.WaitForExit();                                //等待程序执行完退出进程
                p.Close();
                _ = App.dispatcherQueue.TryEnqueue(() =>
                {
                    Output = output;
                });
            });
        }
    }
}
